using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.Models
{
    public class Question : BaseModel
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public CategoryType CategoryType { get; set; }
        public short Grade { get; set; }


        public int InstructorId { get; set; }
        public required HashSet<Choice> Choices { get; set; }
        public required HashSet<ExamQuestion> ExamQuestions { get; set; }

    }
}