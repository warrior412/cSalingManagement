using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyService
{
    [DataContract]
    public class Employee
    {
        private string id;
        [DataMember]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
         [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string age;
         [DataMember]
        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        private string gender;
         [DataMember]
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        
    }

    public class Employees
    {
        private static readonly Employees _instance = new Employees();

        public static Employees Instance
        {
            get { return Employees._instance; }
        } 

        private List<Employee> employees = new List<Employee>()
        {
            new Employee(){Id = "1", Name = "Hieu" , Age="25", Gender= "Male"},
            new Employee(){Id = "2", Name = "Phuong" , Age="25", Gender= "Female"},
            new Employee(){Id = "3", Name = "Khi Con" , Age="0", Gender= "Male"},
            new Employee(){Id = "3", Name = "Heo Con" , Age="0", Gender= "Female"}
        };


        public List<Employee> ArrEmployees
        {
            get { return employees; }
            set { employees = value; }
        }
    }
}