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


        public int? UserId { get; set; }
        public User? user{ get; set; }
        public  HashSet<Choice> Choices { get; set; } = new HashSet<Choice>();
        public  HashSet<ExamQuestion> ExamQuestions { get; set; } = new HashSet<ExamQuestion>();

    }
}