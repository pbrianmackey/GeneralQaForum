using Feedback.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feedback.DL
{
    public class AnswerCRUD
    {
        GeneralDbEntities context = new GeneralDbEntities();

        public IEnumerable<Answer> Read(int questionId)
        {            
            var answers = context.Answers.Where(a => a.questionId == questionId);
            return answers;
        }

        public void Create(string body, string userName, int questionId)
        {
            Answer answer = new Answer();
            answer.body = body;
            answer.createDate = DateTime.Now;
            answer.userName = userName;
            context.Answers.Add(answer);

            context.SaveChanges();
        }

        public void CreateComment(int answerId, string comment)
        {
            var newCommentObject = new AnswerComment();
            newCommentObject.AnswerId = answerId;
            newCommentObject.body = comment;
            context.AnswerComments.Add(newCommentObject);
            context.SaveChanges();
        }
    }
}