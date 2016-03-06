using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Rest" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Rest.svc or Rest.svc.cs at the Solution Explorer and start debugging.
    public class Rest : IRest
    {
        public List<Employee> GetEmployees()
        {
            return Employees.Instance.ArrEmployees;
        }
        public Employee GetEmployee(string Id)
        {
            IEnumerable<Employee> rs = Employees.Instance.ArrEmployees.Where(x=>x.Id == Id);
            return rs==null?null:rs.First<Employee>();
        }
        public void AddEmployee(Employee newEmp)
        {
            Employees.Instance.ArrEmployees.Add(newEmp);
        }
    }
}
