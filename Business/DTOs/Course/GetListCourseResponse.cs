﻿namespace Business.DTOs.Course;

public class GetListCourseResponse
{
    public Guid Id { get; set; }
    public Guid CourseTypeId { get; set; }
    public Guid? ImageId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
}
