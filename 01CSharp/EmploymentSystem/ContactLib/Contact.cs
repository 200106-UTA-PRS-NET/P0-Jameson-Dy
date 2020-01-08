using System;

namespace ContactLib
{
    public class Contact
    {
        // variables
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public long id { get; set; }

        public bool isFullTime { get; set; }

        public Contact() { }

        public Contact(string firstName, string lastName, int age, string phone, string email, long id)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.phone = phone;
            this.email = email;
            this.id = id;
        }

        public string GetContact()
        {
            return $"Name - {firstName} {lastName} \n Age - {age} \n Phone - {phone} \n Email - {email} \n ID - {id}";
        }

        // properties - smart fields which are used to provide public access to private variables
        
    }
}
