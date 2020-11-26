using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AddressBookLINQ
{
    class AddressBookRepo
    {
        /// <summary>
        /// UC1 The data table
        /// </summary>
        DataTable dataTable = new DataTable();
        /// <summary>
        /// UC2 Creates the data table.
        /// </summary>
        public void CreateDataTable()
        {
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("ZipCode", typeof(string));
            dataTable.Columns.Add("PhoneNumber", typeof(string));
            dataTable.Columns.Add("EmailID", typeof(string));

            dataTable.Rows.Add("Runal", "Khadse", "Saki Vihar", "Delhi", "Delhi", "110009", "9876778434", "runal@yahoo.com");
            dataTable.Rows.Add("Rhoit", "Patil", "Ghansoli", "Navi Mumbai", "Maharashtra", "4000356", "7458658925", "rohit@gmail.com");
            dataTable.Rows.Add("Priyanka", "Patil", "Sangvi", "Bangalore", "Karnataka", "520147", "9821118267", "priyanka@gmail.com");
            dataTable.Rows.Add("Shubham", "Dubey", "Ram Nagar", "Bhopal", "Madhya Pradesh", "652412", "8998965896", "shubham@yahoo.com");
            dataTable.Rows.Add("Aditya", "Saitwal", "NavyNagar", "Bangalore", "Karnataka", "520147", "8659876734", "aditya@gmail.com");
            dataTable.Rows.Add("Durgesh", "Jage", "Ghantali", "Thane", "Maharashtra", "400082", "9756387459", "jage@gmail.com");
            dataTable.Rows.Add("Omakar", "Yadav", "Rajiv", "Jaipur", "Rajasthan", "600001", "8987224534", "yadav@gmail.com");            
        }
        /// <summary>
        /// Display address book data table
        /// </summary>
        public void DisplayAddressBook()
        {
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
