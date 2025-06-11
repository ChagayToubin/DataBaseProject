using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DATA.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SecretCode { get; set; }


        public string Type { get; set; }//להגביל את הערכים נשאר לעושת

        public int NumReports { get; set; } = 0;

        public int NumMentions { get; set; } = 0;
        public void PrintPersonInfo()
        {
            Console.WriteLine($"ID: {this.Id}");
            Console.WriteLine($"First Name: {this.FirstName}");
            Console.WriteLine($"Last Name: {this.LastName}");
            Console.WriteLine($"Secret Code: {this.SecretCode}");
            Console.WriteLine($"Type: {this.Type}");
            Console.WriteLine($"Number of Reports: {this.NumReports}");
            Console.WriteLine($"Number of Mentions: {this.NumMentions}");
        }



        public class Builder
        {
            private Person _person = new Person();

            public Builder SetId(int id)
            {
                _person.Id = id;
                return this;
            }

            public Builder SetFirstName(string firstName)
            {
                _person.FirstName = firstName;
                return this;
            }

            public Builder SetLastName(string lastName)
            {
                _person.LastName = lastName;
                return this;
            }

            public Builder SetSecretCode(string secretCode)
            {
                _person.SecretCode = secretCode;
                return this;
            }

            public Builder SetType(string type)
            {
                _person.Type = type; 
                return this;
            }

            public Builder SetNumReports(int numReports)
            {
                _person.NumReports = numReports;
                return this;
            }

            public Builder SetNumMentions(int numMentions)
            {
                _person.NumMentions = numMentions;
                return this;
            }

            public Person Build()
            {
                return _person;
            }
        }
    }
}
