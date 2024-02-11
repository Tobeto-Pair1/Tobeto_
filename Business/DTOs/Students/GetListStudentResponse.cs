using Business.DTOs.Users;

namespace Business.DTOs.Students;

public class GetListStudentResponse
{
    public Guid Id{ get; set; }

    public GetListUserResponse GetListUserResponse { get; set; }
}