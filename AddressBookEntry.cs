using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Relearning
{
    public class AddressBookEntry
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Company { set; get; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

        public void SaveNew(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO [AddressBook]([Name],[Phone],[Company],[Address 1],[Address 2],[City],[State],[Zip],[Country]) " +
                                    "VALUES (@Name,@Phone,@Company,@Address1,@Address2,@City,@State,@Zip,@Country)";
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Company", Company);
            command.Parameters.AddWithValue("@Address1", Address1);
            command.Parameters.AddWithValue("@Address2", Address2);
            command.Parameters.AddWithValue("@City", City);
            command.Parameters.AddWithValue("@State", State);
            command.Parameters.AddWithValue("@Zip", Zip);
            command.Parameters.AddWithValue("@Country", Country);
            command.ExecuteNonQuery();
        }

        public static AddressBookEntry Load(int ID, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [AddressBook] WHERE [ID] = @ID", connection);
            SqlDataReader reader = command.ExecuteReader();
            AddressBookEntry entry = new AddressBookEntry();
            entry.ID = ID;
            entry.Name = reader["Name"].ToString();
            entry.Phone = reader["Phone"].ToString();
            entry.Company = reader["Company"].ToString();
            entry.Address1 = reader["Address 1"].ToString();
            entry.Address2 = reader["Address 2"].ToString();
            entry.City = reader["City"].ToString();
            entry.State = reader["State"].ToString();
            entry.Zip = reader["Zip"].ToString();
            entry.Country = reader["Country"].ToString();
            reader.Close();
            return entry;
        }

        public static List<AddressBookEntry> LoadAll(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [AddressBook]", connection);
            SqlDataReader reader = command.ExecuteReader();
            var addresses = new List<AddressBookEntry>();
            while (reader.Read())
            {
                AddressBookEntry entry = new AddressBookEntry();
                entry.ID = (int)reader["ID"];
                entry.Name = reader["Name"].ToString();
                entry.Phone = reader["Phone"].ToString();
                entry.Company = reader["Company"].ToString();
                entry.Address1 = reader["Address 1"].ToString();
                entry.Address2 = reader["Address 2"].ToString();
                entry.City = reader["City"].ToString();
                entry.State = reader["State"].ToString();
                entry.Zip = reader["Zip"].ToString();
                entry.Country = reader["Country"].ToString();
                addresses.Add(entry);
            }
            reader.Close();
            return addresses;
        }
    }
}