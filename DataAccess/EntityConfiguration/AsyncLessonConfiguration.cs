﻿using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration
{
    public class AsyncLessonConfiguration :IEntityTypeConfiguration<AsyncLesson>
    {

    public void Configure(EntityTypeBuilder<AsyncLesson> builder)
        {
            builder.ToTable("AsyncLessons").HasKey(an => an.Id);
            builder.Property(an => an.Name).HasColumnName("Name").IsRequired();
            builder.Property(an => an.DurationTime).HasColumnName("DurationTime");
            builder.Property(an => an.TimeSpent).HasColumnName("TimeSpent");
            builder.Property(an => an.InstructorId).HasColumnName("InstructorId");
            builder.Property(an => an.CourseModuleId).HasColumnName("CourseModuleId");
            builder.Property(an => an.AsyncLessonDetailId).HasColumnName("AsyncLessonDetailId");


            builder.HasOne(an => an.Instructor);
            builder.HasOne(an => an.CourseModule);
            builder.HasOne(an => an.AsyncLessonDetail);
            builder.HasQueryFilter(an => !an.DeletedDate.HasValue);
        }
    }
}