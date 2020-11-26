/***************************************************************
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
                    "\n2. Insert Contact \n3. Edit Contact \n4. Delete Contact \n5. Exit");
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
                        Console.WriteLine("Enter the person details to be added in the address book");
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
                        addressBookRepo.EditContact(FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email);
                        break;
                    case 4:
                        Console.WriteLine("Enter FirstName of contact to be deleted");
                        string name = Console.ReadLine();
                        addressBookRepo.DeleteContact(name);
                        break;
                    case 5:
                        loop = 0;
                        break;
                }
            }
        }
    }    
}
