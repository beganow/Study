using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department();
            Faculty faculty = new Faculty();
            Faculty faculty2 = new Faculty();
            faculty.addDepartment(department);
            faculty2.delDepartment(department);
            faculty.printinfo();
            University univer = new University();
            univer.addFaculty(faculty);
            univer.delFaculty(faculty2);
            univer.upgFaculty(faculty);
            univer.printinfo();
            Console.WriteLine(faculty.delJobTitle(10));
            Console.WriteLine(faculty.closeJobVacancy(7));
            Organization organization = faculty;
            organization.printinfo(); 
           JobTitle jobtitle = new JobTitle(); 
            Console.WriteLine(organization.addJobTitle(jobtitle));
            organization = new Organization();
            organization.printinfo();
            Console.WriteLine( organization.getJobVacancies());
            Console.WriteLine( organization.getEmployees() );
            Console.WriteLine( organization.getJobTitles() );
            Console.WriteLine( organization.printJobVacancies() );
             organization.openJobVacancy(new JobVacancy()-);
           
        }
    }
}
