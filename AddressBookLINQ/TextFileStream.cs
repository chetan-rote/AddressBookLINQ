using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;

namespace AddressBookLINQ
{
    class TextFileStream
    {
        /// <summary>
        /// Reads the text file.
        /// </summary>
        public void ReadFile()
        {
            string path = @"C:\Users\Chetan\source\repos\AddressBookLINQ\AddressBookLINQ\Files\AddressBookData.txt";
            if (File.Exists(path))
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    string fileData = "";
                    while ((fileData = reader.ReadLine()) != null)
                        Console.WriteLine(fileData);
                }
            }
            else
            {
                Console.WriteLine("File does not exists.");
            }
        }
        /// <summary>
        /// Writes text the file.
        /// </summary>
        /// <param name="contacts">The contacts.</param>
        public void WriteFile(List<Contact> contacts)
        {
            string path = @"C:\Users\Chetan\source\repos\AddressBookLINQ\AddressBookLINQ\Files\AddressBookData.txt";
            if (File.Exists(path))
            {
                using (StreamWriter writer = File.AppendText(path))
                {
                    foreach (Contact contact in contacts)
                    {
                        writer.WriteLine(contact.FirstName + "\t" + contact.LastName + "\t" + contact.Address + "\t" + contact.City + "\t" + contact.State + "\t" + contact.ZipCode + "\t" + contact.PhoneNumber + "\t" + contact.Email);
                    }
                    writer.Close();
                }
            }
            else
            {
                Console.WriteLine("File does not exists.");
            }
        }

        public void ReadCSVFile()
        {
            string path = @"C:\Users\Chetan\source\repos\AddressBookLINQ\AddressBookLINQ\Files\AddressBook.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ",";
                var records = csv.GetRecords<Contact>();
                foreach (Contact contact in records)
                {
                    Console.WriteLine(contact.FirstName, contact.LastName, contact.Address, contact.City, contact.State, contact.PhoneNumber, contact.Email);
                }
            }
        }

        public void WriteCSVFile(List<Contact> contacts)
        {
            string path = @"C:\Users\Chetan\source\repos\AddressBookLINQ\AddressBookLINQ\Files\AddressBook.csv";
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(contacts);
            }
        }
    }
}
