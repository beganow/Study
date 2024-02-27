using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class University:Organization
    {

        protected List<Faculty> faculties = new List<Faculty>();
        public University() { }
        public University(University university)
        {
            this.name = university.name;
            this.address = university.address;
            this.timeStamp = university.timeStamp;
        }
        public University(string name, Type shortName, string address)
        {
            this.name = name;
            this.shortName = shortName;
            this.address = address;

        }
        public int addFaculty(Faculty Faculty)
        {
            faculties.Add(Faculty);
            return 0;
        }
        public bool delFaculty(Faculty Faculty)
        {
            faculties.Remove(Faculty);
            return true;
        }
        public bool upgFaculty(Faculty Faculty)
        {
            int index = faculties.IndexOf(Faculty);
            return true;
        }
        private bool verFaculty(int ch)
        {
            return true;
        }
        public List<Faculty> getFaculty()
        {
            return this.faculties;
        }
        public override void printinfo() => Console.WriteLine(this.name + " " + this.shortName + " " + this.address + " It s univer");
        public int addJobTitle(JobTitle jobTitle) => 1;
        public bool delJobTitle(int ch) => false;
        public void openJobVacancy(JobVacancy jobvacancy) => Console.WriteLine(1);
        public bool closeJobVacancy(int ch) => true;
        public Employee recruit(JobVacancy jobVacancy, Person person) => new Employee();
        public bool dismiss(int ch, Reason reason) => false;

    }
}
