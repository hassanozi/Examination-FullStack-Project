using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.Models
{
    public enum ErrorCode
    {
        NoError = 0,

        InvalidCourseId = 100,
        CourseNotFound = 101,

        InstructrNotFound = 200,

        InternalServerError = 500,

        ValidationError = 505,
    }
}