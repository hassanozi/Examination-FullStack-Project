using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.DTOs.Choices;
using examinationAPI.Helpers;
using examinationAPI.Models;
using examinationAPI.Repositories;

namespace examinationAPI.Services
{
    public class ChoiceService(IRepository<Choice> _choiceRepo, IRepository<Question> _questionRepo)
    {
        

        // Get all choices for a question
        public async Task<IEnumerable<GetChoicesDTO>> GetChoicesByQuestion(int questionId)
        {
            var exists = await _questionRepo.GetById(questionId);
            if (exists == null)
                throw new Exception("Question not found");

            return _choiceRepo.GetAll()
                .Where(c => c.QuestionsId == questionId)
                .Map<Choice, GetChoicesDTO>();   
        }




        // Add a new choice
        public async Task<AddChoiceDTO> AddChoice(int questionId, AddChoiceDTO dto)
        {
            var question = await _questionRepo.GetById(questionId);
            if (question == null)
                throw new Exception("Question not found");

            var choice = dto.MapOne<Choice>();
            choice.QuestionsId = questionId;

            _choiceRepo.Add(choice);
            await _choiceRepo.SaveChanges();

            return choice.MapOne<AddChoiceDTO>();
        }

        public async Task<AddChoiceDTO> UpdateChoice(int choiceId, AddChoiceDTO dto)
        {
            var choice = await _choiceRepo.GetById(choiceId);
            if (choice == null)
                throw new Exception("Choice not found");

            // Map DTO → existing entity
            dto.MapOne(choice);  

            await _choiceRepo.SaveChanges();

            return dto;
        }


        // Delete a choice
        public async Task DeleteChoice(int choiceId)
        {
            var choice = await _choiceRepo.GetById(choiceId);
            if (choice == null)
                throw new Exception("Choice not found");

            _choiceRepo.SoftDelete(choice);
            await _choiceRepo.SaveChanges();
        }

        // Get a single choice
        public async Task<GetChoicesDTO> GetChoice(int choiceId)
        {
            var choice = await _choiceRepo.GetById(choiceId);
            if (choice == null)
                throw new Exception("Choice not found");

            return choice.MapOne<GetChoicesDTO>();
        }
    }
    
}