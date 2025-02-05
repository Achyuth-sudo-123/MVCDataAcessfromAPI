namespace MVCDataAcessfromAPI.DTO.Response
{
    public class EmployeeDetailsResponse
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int salary { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

    }
}
