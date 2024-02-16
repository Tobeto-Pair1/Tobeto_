namespace Business.DTOs.Employees;

public class EmployeeForRegisterRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    //  public Guid DepartmentId { get; set; }
    public string DepartmentName { get; set; }
}