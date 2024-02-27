using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Organization:IStaff
    {
        public int id
        {
            get;
            private set;
        }
        public string name
        {
            get;
            protected set;
        }
        public Type shortName
        {
            get;
            protected set;
        }
        public string address
        {
            get;
            protected set;
        }
        private DateTime _timeStamp;
        public DateTime timeStamp
        {
            get;
            protected set;
        }
        public Organization() { }
        public Organization(Organization organization)
        {
            this.id = organization.id;
            this.name = organization.name;
            this.shortName = organization.shortName;
            this.address = organization.address;
            this.timeStamp = organization.timeStamp;
        }
        public Organization(string name, Type shortName, string address)
        {
            this.name = name;
            this.shortName = shortName;
            this.address = address;

        }
        public virtual void printinfo() => Console.WriteLine(this.id + " " + this.name + " " + this.shortName + " " + this.timeStamp + " " + this.address);
        public List<JobVacancy> getJobVacancies() => new List<JobVacancy>();
        public List<Employee> getEmployees() => new List<Employee>();
        public List<JobTitle> getJobTitles() => new List<JobTitle>();
        public virtual int addJobTitle(JobTitle jobTitle) => 0;
        public string printJobVacancies() => "Job";
        public bool delJobTitle(int ch) => true;
        public void openJobVacancy(JobVacancy jobvacancy) => Console.WriteLine(2);
        public bool closeJobVacancy(int ch) => false;
        public Employee recruit(JobVacancy jobVacancy, Person person) => new Employee();
        public bool dismiss(int ch, Reason reason) => true;
    }
}
