using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    interface IStaff
    {
        List<JobVacancy> getJobVacancies();
        List<Employee> getEmployees();
        List<JobTitle> getJobTitles();
        int addJobTitle(JobTitle jobTitle);
        string printJobVacancies();
        bool delJobTitle(int ch);
        void  openJobVacancy(JobVacancy  jobVacancy);
        bool closeJobVacancy(int ch);
        Employee recruit(JobVacancy jobVacancy, Person person);
        bool dismiss(int number, Reason reason);
    }
}
