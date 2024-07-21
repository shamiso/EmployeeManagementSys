using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSys.Models
{
    public class SystemCode:UserActivity
    { 
        [Key]
        public int Id { get; set; } 
        public string Description { get; set; }
        public string Code { get; set; }
    }
}
