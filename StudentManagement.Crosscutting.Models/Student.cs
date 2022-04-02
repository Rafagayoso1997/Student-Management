using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Crosscutting.Models
{
    public class Student
    {
        
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }

        public Student()
        {
            Guid = Guid.NewGuid();
        }

        public Student(int id, string name, string surname, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Age = CalculateAge();
        }

        private int CalculateAge()
        {
            var today = DateTime.Today;
            int age = DateTime.Now.Year - BirthDate.Year;
            if (BirthDate.Date > today.AddYears(-age)) age--;

            return age;
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   Id == student.Id &&
                   Name == student.Name &&
                   Surname == student.Surname &&
                   BirthDate == student.BirthDate &&
                   Age == student.Age;
        }

        public override int GetHashCode()
        {
            int hashCode = 946127122;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
            hashCode = hashCode * -1521134295 + BirthDate.GetHashCode();
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            return hashCode;
        }
    }
}
