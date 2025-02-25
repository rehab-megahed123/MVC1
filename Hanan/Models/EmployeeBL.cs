namespace Hanan.Models
{
    public class EmployeeBL
    {
        List<Employee> list = new List<Employee>();
        public EmployeeBL()
        {
           
            list.Add(new Employee(1, "Rehab", 60_000));
            list.Add(new Employee(2, "Hanan", 60_000));
            list.Add(new Employee(1, "Tasneem", 60_000));

        }
        public List<Employee> ShowAll()
        {
            EmployeeBL emp = new EmployeeBL();
            return emp.list ;
        }
        public Employee GetById(int id)
        {
            EmployeeBL emp = new EmployeeBL();
            var employee = emp.list.FirstOrDefault(em => em.Id == id);
            return employee;

        }
        
      
        
        
        
    }

}
