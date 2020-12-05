using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookLINQ
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public DateTime DateAdded { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Contact() { }
        /// <summary>
        /// Contact class for storing contact details using parameterised constructor
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        public Contact(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNumber, string email, string type, DateTime dateAdded)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Type = type;
            this.DateAdded = dateAdded;
        }
        override
        public string ToString()
        {
            return $"First Name: {FirstName}, Last Name: {LastName}, Address: {Address}, City: {City}, State: {State}, Zip: {ZipCode}, MobileNumber: {PhoneNumber}, Email: {Email}, Type: {Type}, DateAdded: {DateAdded}";
        }
    }
}
