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
        }
    }
}
