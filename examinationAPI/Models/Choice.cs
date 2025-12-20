using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.Models
{
    public class Choice : BaseModel
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool IsRightAnswer { get; set; }


        public int QuestionsId { get; set; }
        public required Question Questions { get; set; }
        
    }
}