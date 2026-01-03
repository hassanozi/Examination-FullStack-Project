using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.DTOs.Choices
{
    public class AddChoiceDTO
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool IsRightAnswer { get; set; }
    }
}