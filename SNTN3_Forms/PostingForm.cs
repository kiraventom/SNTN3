using SNTN3_Forms.PictureEdit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using VkNet;

namespace SNTN3_Forms
{
    public partial class PostingForm : Form
    {
        public PostingForm(VkApi api, string[] pathsToPictures, PictureEditParams[] pictureEditParams)
        {
            InitializeComponent();
            Api = api;
            Groups = new ObservableCollection<VkNet.Model.Group>();
            Groups.CollectionChanged += Groups_CollectionChanged;
            PathsToPictures = pathsToPictures;
            PictureEditParams = pictureEditParams;
            Rnd = new Random();
        }

        private VkApi Api { get; }
        private ObservableCollection<VkNet.Model.Group> Groups { get; }
        private string[] PathsToPictures { get; }
        private PictureEditParams[] PictureEditParams { get; }
        private Random Rnd { get; }

        private void PostingForm_Load(object sender, EventArgs e)
        {
            var groups = Api.Groups.Get(new VkNet.Model.RequestParams.GroupsGetParams
            {
                Filter = VkNet.Enums.Filters.GroupsFilters.Moderator,
                Extended = true
            });
            foreach (var group in groups)
            {
                Groups.Add(group);
            }

            StartingDateDP.MinDate = DateTime.Today;
            StartingDateDP.Value = Properties.Settings.Default.StartingDateTime.Date;
            StartingTimeNUD.Value = Properties.Settings.Default.StartingDateTime.Hour;
            PostsCountNUD.Value = Properties.Settings.Default.PostsCount;
            PostsCountNUD.Minimum = 1;
            TimeBetweenNUD.Value = Properties.Settings.Default.TimeBetween;
            TimeBetweenNUD.Minimum = 1;
        }

        private void Groups_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                for (int i = 0; i < e.NewItems.Count; ++i)
                {
                    GroupsCB.Items.Add(((VkNet.Model.Group)e.NewItems[i]).Name);
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                for (int i = 0; i < e.OldItems.Count; ++i)
                {
                    GroupsCB.Items.Remove(GroupsCB.Items.Cast<string>().Select(name => ((VkNet.Model.Group)e.OldItems).Name == name));
                }
            }
        }

        private void PostsCountNUD_ValueChanged(object sender, EventArgs e)
        {
            UpdateLimits();
        }

        private void TimeBetweenNUD_ValueChanged(object sender, EventArgs e)
        {
            UpdateLimits();
        }

        private void UpdateLimits()
        {
            PostsCountNUD.Maximum = 24 / TimeBetweenNUD.Value;
            TimeBetweenNUD.Maximum = 24 / PostsCountNUD.Value;
        }

        private void SaveChanges()
        {
            Properties.Settings.Default.SelectedGroupIndex = GroupsCB.SelectedIndex;
            Properties.Settings.Default.StartingDateTime = new DateTime(
                year: StartingDateDP.Value.Year,
                month: StartingDateDP.Value.Month,
                day: StartingDateDP.Value.Day,
                hour: (int)StartingTimeNUD.Value,
                minute: 0,
                second: 0);
            Properties.Settings.Default.PostsCount = (int)PostsCountNUD.Value;
            Properties.Settings.Default.TimeBetween = (int)TimeBetweenNUD.Value;
            Properties.Settings.Default.Save();
        }

        private void StartingTimeNUD_ValueChanged(object sender, EventArgs e)
        {
            if (StartingTimeNUD.Value == 1 || StartingTimeNUD.Value == 21)
            {
                HoursL.Text = "час";
            }
            else if (StartingTimeNUD.Value < 5 || StartingTimeNUD.Value > 21)
            {
                HoursL.Text = "часа";
            }
            else if (StartingTimeNUD.Value < 21)
            {
                HoursL.Text = "часов";
            }
        }

        private void SaveSettingsBt_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void PostBt_Click(object sender, EventArgs e)
        {
            if (GroupsCB.SelectedIndex < 0)
            {
                return;
            }

            var dr = MessageBox.Show("Начать публикацию постов? Это действие нельзя будет отменить!",
                                     "Внимание",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Warning);
            if (dr == DialogResult.No)
            {
                return;
            }

            SaveChanges();

            var dateTimes = new List<DateTime>();
            int daysCount = (int)Math.Ceiling((double)PathsToPictures.Length / Properties.Settings.Default.PostsCount);
            int postsAmount = PathsToPictures.Length;

            for (int i = 0; i < daysCount; ++i)
            {
                DateTime date = Properties.Settings.Default.StartingDateTime.AddDays(i);
                for (int j = 0; postsAmount > 0 && j < Properties.Settings.Default.PostsCount; ++j)
                {
                    dateTimes.Add(date.AddMinutes(Rnd.Next(-7, 7)));
                    date = date.AddHours(Properties.Settings.Default.TimeBetween);
                    --postsAmount;
                }
            };

            if /*somehow*/(dateTimes.Count != PathsToPictures.Length)
            {
                throw new Exception($"Количество вычисленных дат не совпадает с количеством постов." +
                                    $"Количество дат: {dateTimes.Count}. Количество постов: {PathsToPictures.Length}");
            }

            long groupId = Groups[GroupsCB.SelectedIndex].Id;
            
            Hide();
            var loadingForm = new LoadingForm(Api, dateTimes.ToArray(), groupId, PathsToPictures, PictureEditParams);
            loadingForm.ShowDialog();
            if (loadingForm.DialogResult == DialogResult.No)
            {
                Show();
            }
            else
            {
                Close();
            }
        }

        private void PrevStepBt_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(
                        "Вернуться к изменению картинок? Все настройки будут утеряны!",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }
    }
}
