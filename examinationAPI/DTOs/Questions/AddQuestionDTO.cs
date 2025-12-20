using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.Models;

namespace examinationAPI.DTOs.Questions
{
    public class AddQuestionDTO
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public CategoryType CategoryType { get; set; }
        public short Grade { get; set; }
    }
}