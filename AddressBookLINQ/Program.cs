﻿/***************************************************************
 *  Purpose: This problem implements address book using LINQ.
 *
 *
 *  @author  Chetan Rote
 *  @version 1.0
 *  @since   26-11-2020
 ****************************************************************/
using System;

namespace AddressBookLINQ
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book using LINQ.");
            AddressBookRepo addressBookRepo = new AddressBookRepo();
            int loop = 1;
            addressBookRepo.CreateDataTable();
            while (loop == 1)
            {
                Console.WriteLine("Make choice according to your desired operation \n1.Display Address book " +
                    "\n2. Insert Contact \n3. Edit Contact \n4. Delete Contact \n5. Retrieve contacts by city " +
                    "\n6. Retrieve Contacts by state \n7. Retrieve count of contacts by city and state " +
                    "\n8. Display contacts alphabetically for a city \n9. Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addressBookRepo.DisplayAddressBook();
                        break;
                    case 2:
                        Contact contact = new Contact();
                        Console.WriteLine("Enter the person details to be added in the address book");
                        Console.WriteLine("First Name");
                        contact.FirstName = Console.ReadLine();
                        Console.WriteLine("Last Name");
                        contact.LastName = Console.ReadLine();
                        Console.WriteLine("Address");
                        contact.Address = Console.ReadLine();
                        Console.WriteLine("City");
                        contact.City = Console.ReadLine();
                        Console.WriteLine("State");
                        contact.State = Console.ReadLine();
                        Console.WriteLine("Zip code");
                        contact.ZipCode = Console.ReadLine();
                        Console.WriteLine("Phone Number");
                        contact.PhoneNumber = Console.ReadLine();
                        Console.WriteLine("Email");
                        contact.Email = Console.ReadLine();
                        addressBookRepo.InsertContacts(contact);
                        break;
                    case 3:
                        Contact contacts = new Contact();
                        Console.WriteLine("Enter the person details to be updated in the address book");
                        Console.WriteLine("First Name");
                        string FirstName = Console.ReadLine();
                        Console.WriteLine("Last Name");
                        string LastName = Console.ReadLine();
                        Console.WriteLine("Address");
                        string Address = Console.ReadLine();
                        Console.WriteLine("City");
                        string City = Console.ReadLine();
                        Console.WriteLine("State");
                        string State = Console.ReadLine();
                        Console.WriteLine("Zip code");
                        string ZipCode = Console.ReadLine();
                        Console.WriteLine("Phone Number");
                        string PhoneNumber = Console.ReadLine();
                        Console.WriteLine("Email");
                        string Email = Console.ReadLine();
                        addressBookRepo.EditContact(contacts);
                        break;
                    case 4:
                        Console.WriteLine("Enter FirstName of contact to be deleted");
                        string name = Console.ReadLine();
                        addressBookRepo.DeleteContact(name);
                        break;
                    case 5:
                        Console.WriteLine("Enter City");
                        string city = Console.ReadLine();
                        addressBookRepo.RetrieveContactsByCity(city);
                        break;
                    case 6:
                        Console.WriteLine("Enter State");
                        string state = Console.ReadLine();
                        addressBookRepo.RetrieveContactsByState(state);
                        break;
                    case 7:
                        addressBookRepo.CountByCityAndState();
                        break;
                    case 8:
                        Console.WriteLine("Enter City");
                        string cityName = Console.ReadLine();
                        addressBookRepo.SortContactsAlphabeticalyForACity(cityName);
                        break;                   
                    case 9:
                        loop = 0;
                        break;
                }
            }
        }
    }    
}
