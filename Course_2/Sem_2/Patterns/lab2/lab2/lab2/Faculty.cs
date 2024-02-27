using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Faculty:Organization
    {
        protected List<Department> departments = new List<Department>();
        public Faculty() { }
        public Faculty(Faculty faculty)
        {
            this.name = faculty.name;
            this.address = faculty.address;
            this.timeStamp = faculty.timeStamp;
        }
        public Faculty(string name, Type shortName, string address)
        {
            this.name = name;
            this.shortName = shortName;
            this.address = address;

        }
        public int addDepartment(Department department)
        {
            departments.Add(department);
            return 0;
        }
        public bool delDepartment(Department department)
        {
            departments.Remove(department);
            return true;
        }
        public bool upgDepartment(Department department)
        {
            int index = departments.IndexOf(department);
            return true;
        }
        private bool verDepartment(int ch)
        {
            return true;
        }
        public List<Department> getDepartment()
        {
            return this.departments;
        }
        public override void printinfo() => Console.WriteLine(this.name + " " + this.shortName + " " + this.address + " It s Faculty");

        public int addJobTitle(JobTitle jobTitle) => 1;
        public bool delJobTitle(int ch) => false;
        public void openJobVacancy(JobVacancy jobacancy) => Console.WriteLine(3);
        public bool closeJobVacancy(int ch) => true;
        public Employee recruit(JobVacancy jobVacancy, Person person) => new Employee();
        public bool dismiss(int ch, Reason reason) => false;

    }
}
