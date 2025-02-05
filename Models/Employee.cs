namespace MVCDataAcessfromAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int salary { get; set; }
        public int? LocationID { get; set; }
        public int? GenderId { get; set; }
        public bool Isdelete { get; set; }
    }
}
