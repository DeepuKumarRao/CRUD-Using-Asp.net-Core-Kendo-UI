using System.ComponentModel.DataAnnotations;

namespace Tablebindcore.Models
{
    public class EmpClass
    {
        [Key]
        public int Id { get; set; }
        public string  EmployeeName { get; set; }
        public string Designation{ get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }

    }
}
