using Feedback.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feedback.DL
{
    public class QuestionCRUD
    {
        GeneralDbEntities1 context = new GeneralDbEntities1();

        public int Insert(Question q)
        {            
            context.Questions.Add(q);
            context.SaveChanges();
            return q.id;
        }

        public Question Read(int id)
        {
            var question = context.Questions.Find(id);
            if (question.viewCount == null)
                question.viewCount = 0;
            question.viewCount = question.viewCount + 1;
            context.SaveChanges();
            return question;
        }

        public void Update(Question question)
        {
            Question questionToUpdate = Read(question.id);
            questionToUpdate.id = question.id;
            questionToUpdate.body = question.body;
            questionToUpdate.tags = question.tags;
            questionToUpdate.title = question.title;
            //questionToUpdate.votes = question.votes;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Questions.Remove(Read(id));
            context.SaveChanges();
        }

        public int? UpdateVote(int questionId, int voteCount, string userName)
        {
            bool upvote = true;
            if (voteCount < 0)
                upvote = false;

            context.Database.ExecuteSqlCommand("[dbo].[VoteCRUD] {0}, {1}, {2}", userName, questionId, upvote);

            int? updatedVoteCount = context.Questions.Where(q => q.id == questionId).First().votes;
            return updatedVoteCount;
        }
    }
}