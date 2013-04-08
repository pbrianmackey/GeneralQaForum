using Feedback.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feedback.DL
{
    public class AnswerCRUD
    {
        GeneralDbEntities context = new GeneralDbEntities();

        public void Read()
        {
            
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