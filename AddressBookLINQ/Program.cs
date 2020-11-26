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
            addressBookRepo.CreateDataTable();
            addressBookRepo.DisplayAddressBook();
        }
    }
}
