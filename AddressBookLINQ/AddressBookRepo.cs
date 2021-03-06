﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AddressBookLINQ
{
    class AddressBookRepo
    {
        /// <summary>
        /// UC1 The data table
        /// </summary>
        public DataTable dataTable = new DataTable();
        public List<Contact> contactList = new List<Contact>();

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBook_DB;Integrated Security=True";
        SqlConnection connection;

        public void ContactList()
        {
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("ZipCode", typeof(string));
            dataTable.Columns.Add("PhoneNumber", typeof(string));
            dataTable.Columns.Add("EmailID", typeof(string));
            /// UC3 Insert Data.
            dataTable.Rows.Add("Runal", "Khadse", "Saki Vihar", "Delhi", "Delhi", "110009", "9876778434", "runal@yahoo.com");
            dataTable.Rows.Add("Rhoit", "Patil", "Ghansoli", "Navi Mumbai", "Maharashtra", "4000356", "7458658925", "rohit@gmail.com");
            dataTable.Rows.Add("Priyanka", "Patil", "Sangvi", "Bangalore", "Karnataka", "520147", "9821118267", "priyanka@gmail.com");
            dataTable.Rows.Add("Shubham", "Dubey", "Ram Nagar", "Bhopal", "Madhya Pradesh", "652412", "8998965896", "shubham@yahoo.com");
            dataTable.Rows.Add("Aditya", "Saitwal", "NavyNagar", "Bangalore", "Karnataka", "520147", "8659876734", "aditya@gmail.com");
            dataTable.Rows.Add("Durgesh", "Jage", "Ghantali", "Thane", "Maharashtra", "400082", "9756387459", "jage@gmail.com");
            dataTable.Rows.Add("Omakar", "Yadav", "Rajiv", "Jaipur", "Rajasthan", "600001", "8987224534", "yadav@gmail.com");
            contactList = (from DataRow dataRow in dataTable.Rows
                           select new Contact()
                           {
                               FirstName = dataRow["FirstName"].ToString(),
                               LastName = dataRow["LastName"].ToString(),
                               Address = dataRow["Address"].ToString(),
                               City = dataRow["City"].ToString(),
                               State = dataRow["State"].ToString(),
                               ZipCode = dataRow["ZipCode"].ToString(),
                               PhoneNumber = dataRow["PhoneNumber"].ToString(),
                               Email = dataRow["EmailID"].ToString()
                           }).ToList();
        }
        /// <summary>
        /// Display address book data table
        /// </summary>
        public void DisplayAddressBook()
        {
            foreach (var display in contactList)
            {
                Console.WriteLine(display);
            }
            //foreach (DataRow row in dataTable.Rows)
            //{
            //    foreach (DataColumn col in dataTable.Columns)
            //    {
            //        Console.Write(row[col] + " ");
            //    }
            //    Console.WriteLine();
            //}
        }
        /// <summary>
        /// Insert Contacts in a the addressBook
        /// </summary>
        /// <param name="contact"></param>
        public void InsertContacts(Contact contact)
        {
            dataTable.Rows.Add(contact.FirstName, contact.LastName, contact.Address, contact.City, contact.State, contact.ZipCode, contact.PhoneNumber, contact.Email);
            Console.WriteLine("Contact inserted successfully");
        }
        /// <summary>
        /// UC4 Edits the existing contact in datatable
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipcode"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        public void EditContact(Contact contact, string firstName)
        {
            var recordedData = dataTable.AsEnumerable().Where(x => x.Field<string>("FirstName") == firstName).FirstOrDefault();
            if (recordedData != null)
            {
                recordedData.SetField("LastName", contact.LastName);
                recordedData.SetField("Address", contact.Address);
                recordedData.SetField("City", contact.City);
                recordedData.SetField("State", contact.State);
                recordedData.SetField("ZipCode", contact.ZipCode);
                recordedData.SetField("EmailID", contact.Email);
                Console.WriteLine("Contact edited successfully");
            }
            else
            {
                Console.WriteLine("No Contact Found");
            }
        }
        /// <summary>
        /// UC5 Delete contact from table
        /// </summary>
        /// <param name="name"></param>
        public void DeleteContact(string name)
        {
            var deleteRow = dataTable.AsEnumerable().Where(a => a.Field<string>("FirstName").Equals(name)).FirstOrDefault();
            if (deleteRow != null)
            {
                deleteRow.Delete();
                Console.WriteLine("Contact deleted successfully");
            }
        }
        /// <summary>
        /// UC6 Retrieve contacts of a particular city
        /// </summary>
        /// <param name="city"></param>
        public void RetrieveContactsByCity(string city)
        {
            var cityResults = dataTable.AsEnumerable().Where(dr => dr.Field<string>("City") == city);
            foreach (DataRow row in cityResults)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col] + " ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// UC6 Retrieves contact of a particular state
        /// </summary>
        /// <param name="state"></param>
        public void RetrieveContactsByState(string state)
        {
            var stateResults = dataTable.AsEnumerable().Where(dr => dr.Field<string>("State") == state);
            foreach (DataRow row in stateResults)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col] + " ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// UC7 Displays count of contacts city and state wise
        /// </summary>
        public void CountByCityAndState()
        {
            var countByCityAndState = from row in dataTable.AsEnumerable()
                                      group row by new { City = row.Field<string>("City"), State = row.Field<string>("State") } into grp
                                      select new
                                      {
                                          City = grp.Key.City,
                                          State = grp.Key.State,
                                          Count = grp.Count()
                                      };
            foreach (var row in countByCityAndState)
            {
                Console.WriteLine(row.City + "\t" + row.State + "\t" + row.Count);
            }
        }
        /// <summary>
        /// UC8 Retrieves Contacts alphabetically in a city
        /// </summary>
        /// <param name="city"></param>
        public void SortContactsAlphabeticalyForACity(string city)
        {
            var records = dataTable.AsEnumerable().Where(x => x.Field<string>("city") == city).OrderBy(x => x.Field<string>("FirstName")).ThenBy(x => x.Field<string>("LastName"));
            foreach (DataRow row in records)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    Console.Write(row[column] + " ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Retrieves Contacts sorted alphabetically for given state.
        /// </summary>
        /// <param name="state"></param>
        public void SortContactsAlphabeticallyForState(string state)
        {
            var records = dataTable.AsEnumerable().Where(sortedState => sortedState.Field<string>("state") == state).OrderBy(firstName => firstName.Field<string>("FirstName")).ThenBy(lastName => lastName.Field<string>("LastName"));
            foreach (DataRow row in records)
            {
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    Console.WriteLine(row[dataColumn] + " ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Retrieves the contacts sorted for given zipcode.
        /// </summary>
        /// <param name="zipCode"></param>
        public void SortContactsByZipcode(string zipCode)
        {
            var records = dataTable.AsEnumerable().Where(sort => sort.Field<string>("zipCode") == zipCode).OrderBy(firstName => firstName.Field<string>("FirstName")).ThenBy(lastName => lastName.Field<string>("LastName"));
            foreach (DataRow dataRow in records)
            {
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    Console.WriteLine(dataRow[dataColumn] + " ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Retrieves all contacts from database.
        /// </summary>
        /// <returns></returns>
        public bool RetrieveAllContacts()
        {
            connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    /// Impementing the command on the connection fetched database table.
                    SqlCommand sqlCommand = new SqlCommand("spGetData", this.connection);
                    /// Opening the connection to start mapping.
                    this.connection.Open();
                    /// executing the sql data reader to fetch the records.
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Contact contact = new Contact();
                            contact.Type = reader.GetString(0);
                            contact.FirstName = reader.GetString(1);
                            contact.LastName = reader.GetString(2);
                            contact.Address = reader.GetString(3);
                            contact.ZipCode = reader.GetString(4);
                            contact.PhoneNumber = reader.GetString(5);
                            contact.Email = reader.GetString(6);
                            contact.City = reader.GetString(7);
                            contact.State = reader.GetString(8);

                            contactList.Add(contact);

                            Console.WriteLine(contact.Type + "  " + contact.FirstName + "  " + contact.LastName + "  " + contact.Address + "  " + contact.ZipCode + "  " +
                                contact.City + "  " + contact.State + "  " + contact.PhoneNumber + "  " + contact.Email);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Table is empty.");
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            /// Always ensuring the closing of the connection.
            finally
            {
                connection.Close();
            }
            return false;
        }
    }
}
