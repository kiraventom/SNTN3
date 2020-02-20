using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data.SQLite;
using System.Data;

namespace SNTN3_Forms.Accounts
{
    public class AccountsDB
    {
        private SQLiteConnection Connection { get; set; }
        private SQLiteCommand Command { get; set; }
        public AccountsDB()
        {
            const string filename = "accounts.db";
            if (!File.Exists(filename))
            {
                SQLiteConnection.CreateFile(filename);
            }

            Connection = new SQLiteConnection($"Data Source={filename};Version=3;");

            Connection.Open();
            Command = new SQLiteCommand("create table if not exists [Accounts] ([ID] text, [Token] text)", Connection);
            Command.ExecuteNonQuery();
            Connection.Close();
        }   

        public void Add(string id, string token)
        {
            Connection.Open();
            Command = new SQLiteCommand($"insert into [Accounts] values ('{id}', '{token}')", Connection);
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public void Remove(string id)
        {
            Connection.Open();
            Command.CommandText = $"delete from [Accounts] where [ID] = {id}";
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public KeyValuePair<string, string> ReadLine(string id)
        {
            Connection.Open();
            DataTable dataTable = new DataTable();
            string sqlQuery = $"select * from [Accounts] where [ID] = {id}";
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, Connection))
            {
                adapter.Fill(dataTable);
            }
            Connection.Close();
            string token = dataTable.Rows[0].ItemArray[1].ToString();
            return new KeyValuePair<string, string>(id, token);
        }

        public Dictionary<string, string> ReadAll()
        {
            Connection.Open();
            DataTable dataTable = new DataTable();
            string sqlQuery = "select * from [Accounts]";
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, Connection))
            {
                adapter.Fill(dataTable);
            }
            Connection.Close();
            var dict = new Dictionary<string, string>();
            foreach (DataRow row in dataTable.Rows)
            {
                dict.Add(row.ItemArray[0].ToString(), row.ItemArray[1].ToString());
            }
            return dict;
        }
    }
}
