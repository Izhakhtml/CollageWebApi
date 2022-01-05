using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollageWebApi.Models
{
    public class Lecturer
    {
        public string firstName;
        public string lastName;
        public string domain;
        public string email;
        public int salary;
        public Lecturer(string firstName, string lastName, string domain, string email, int salary)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.domain = domain;
            this.email = email;
            this.salary = salary;
        }
        public Lecturer() { }
    }
}