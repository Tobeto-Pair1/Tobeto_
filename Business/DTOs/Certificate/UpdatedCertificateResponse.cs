﻿namespace Business.DTOs.Certificate;

public class UpdatedCertificateResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string FileName { get; set; }
    public string FileUrl { get; set; }
}
