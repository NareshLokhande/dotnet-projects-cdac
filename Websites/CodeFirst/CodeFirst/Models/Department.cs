namespace CodeFirst.Models
{
    public class Department
    {
        public int DeptNo { get; set; }

        public string DeptName { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    }
}
