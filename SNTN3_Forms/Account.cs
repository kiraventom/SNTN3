using System.Drawing;

namespace SNTN3_Forms.Accounts
{
    public class Account
    {
        public Account(string token, string name, string id, Bitmap profilePic)
        {
            Token = token;
            Name = name;
            ID = id;
            ProfilePic = profilePic;
        }

        public string Token { get; }
        public string Name { get; }
        public string ID { get; }
        public Bitmap ProfilePic { get; }
    }
}
