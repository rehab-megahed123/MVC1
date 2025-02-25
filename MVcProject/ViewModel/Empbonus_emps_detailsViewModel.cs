namespace MVcProject.ViewModel
{
    public class Empbonus_emps_detailsViewModel
    {
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        
        public decimal bonus { get; set; }
        public string image { get; set; }
        public decimal  Salary { get; set; }
        public decimal SalaryAfterBonus { get; set; }
        public  string Color { get; set; }

        public decimal defineBonus(int Deptid)
        {
            if (Deptid == 1)
            {
                bonus = 5000;
            }
            else if (Deptid==2)
            {
                bonus = 4000;
            }
            else if(Deptid==3) {
                bonus = 3000;
            }
            else
            {
                bonus = 1500;
            }
            return bonus;
        }

        public decimal CalculateSalaryAfterBonus(decimal salary,decimal bonus1)
        {
            SalaryAfterBonus = salary + bonus1;
            return SalaryAfterBonus;

        }
    }
}
