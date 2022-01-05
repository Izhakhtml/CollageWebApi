using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollageWebApi.Models
{
    public class Student
    {
        public string firstName;
        public string lastName;
        public DateTime birthday;
        public string email;
        public int schoolYear;
        public Student(string firstName, string lastName, DateTime birthday, string email, int schoolYear)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthday = birthday;
            this.email = email;
            this.schoolYear = schoolYear;
        }
    }
}