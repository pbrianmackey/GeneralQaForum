using Feedback.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Feedback.DL
{
    public class TagCRUD
    {
        GeneralDbEntities context = new GeneralDbEntities();

        public void Create(string name, string description)
        {
            try
            {
                Tag tag = new Tag();
                tag.Name = name;
                tag.Description = description;
                context.Tags.Add(tag);
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }   
        }

        public IEnumerable<Tag> Lookup(string tagName)
        {
            var result =  context.Database.SqlQuery<Tag>("FindSimilarTags @tagName", new SqlParameter("tagName",tagName));
            return result;
        }
    }
}