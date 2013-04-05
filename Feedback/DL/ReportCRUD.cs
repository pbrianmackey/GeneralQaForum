using Feedback.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feedback.DL
{
    public class ReportCRUD
    {
        GeneralDbEntities1 context = new GeneralDbEntities1();

        public IOrderedQueryable<Question> HottestQuestions()
        {
            var result = context.Questions.OrderByDescending(q => q.votes);
            return result;
        }
    }
}