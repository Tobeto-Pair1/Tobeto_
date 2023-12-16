namespace Business.Dtos.Requests;

public class DeleteEducationRequest
{
    public string EducationType { get; set; }
    public string University { get; set; }
    public string Department { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime GraduationDate { get; set; }

}