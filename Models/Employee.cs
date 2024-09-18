using System.ComponentModel.DataAnnotations;

namespace BordoProject.Models
{
    public class Employee
    {
        public string Name { get; set; }

        public string Email { get; set; }

        [Key]
        public int EmployeeId { get; internal set; }

        public Guid UniqueId { get; set; } = Guid.NewGuid();


    }
}
