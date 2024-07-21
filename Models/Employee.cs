namespace EmployeeManagementSys.Models
{
    public class Employee : UserActivity
    {
        public int Id { get; set; }

        public string EmployeeNum { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName=> $"{FirstName}{MiddleName} {LastName}";

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public string PhysicalAddress { get; set; }

        public DateTime DateOfBirth { get; set; }
        
        public string Department { get; set; }

        public string Designation { get; set; }


    }
}
