using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Reflection;
using System.Data;
namespace Example3
{
    class ContactDB : DataAccessLayer, IDisposable
    {
        SQLiteConnection con = default(SQLiteConnection);
        string cs = @"URI=file:test.db";
        public ContactDB()
        {
            con = new SQLiteConnection(cs);
            con.Open();
            PrepareDB();
        }

        public void Dispose()
        {
            con.Close();
        }

        private void ExecuteNonQuery(string commandText)
        {
            var cmd = new SQLiteCommand(con);
            cmd.CommandText = commandText;
            cmd.ExecuteNonQuery();
        }
        private void PrepareDB()
        {
            //SQLiteConnection.CreateFile("test.db");
            ExecuteNonQuery("DROP TABLE IF EXISTS contacts");
            ExecuteNonQuery("CREATE TABLE contacts(id STRING PRIMARY KEY, name TEXT, phone TEXT, address TEXT)");
        }

        public string CreateContact(ContactDTO contact)
        {
            string text = string.Format("INSERT INTO contacts(id, name, phone, address) VALUES('{0}', '{1}', '{2}', '{3}')"
                , contact.Id,
                contact.Name,
                contact.Phone,
                contact.Addr);

            ExecuteNonQuery(text);
            return contact.Id;
        }

        public void DeleteContactById(string id)
        {
            string text = "DELETE FROM contacts WHERE id = '"+id+"'";
            ExecuteNonQuery(text);
        }

        public void UpdateContactById(string id, ContactDTO contact)
        {
            string text = string.Format("UPDATE contacts SET name='{0}', phone='{1}', address='{2}' WHERE id = '"+id+"'"
                , contact.Name,
                contact.Phone,
                contact.Addr);
            ExecuteNonQuery(text);
        }

        public List<ContactDTO> GetAllContacts()
        {
            List<ContactDTO> res = new List<ContactDTO>();

            string selectSql = @"select * from contacts";
            using (SQLiteCommand command = new SQLiteCommand(selectSql, con))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new ContactDTO
                    {
                        Id = reader.GetString(0),
                        Name = reader.GetString(1),
                        Phone = reader.GetString(2),
                        Addr = reader.GetString(3)
                    };

                    res.Add(item);
                }
            }
            return res;
        }

        public ContactDTO GetContactById(string id)
        {
            return null;
        }

        public List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }


    }
}
