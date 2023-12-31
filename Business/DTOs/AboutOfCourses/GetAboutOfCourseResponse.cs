﻿namespace Business.DTOs.AboutOfCourses;

public class GetListAboutOfCourseResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public Guid ManufacturerId { get; set; }
    public string ManufacturerName { get; set; }
    public string CourseName { get; set; }
    public Guid CourseId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime SpentTime { get; set; }
}