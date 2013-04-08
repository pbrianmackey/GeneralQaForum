using Feedback.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Feedback.Models;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Feedback.Controllers
{
    public class QuestionController : Controller
    {
        QuestionCRUD questionCRUD = new QuestionCRUD();
        //
        // GET: /Question/

        public ActionResult Index(int id)
        {
            Question q = questionCRUD.Read(id);
            return View(q);
        }

        //
        // GET: /Question/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        public void UpdateQuestion(Question question)
        {
            questionCRUD.Update(question);
        }

        public int UpdateVote(int questionId, int voteCount, string userName)
        {
            int? updatedVoteCount = questionCRUD.UpdateVote(questionId, voteCount, userName);
            if (updatedVoteCount == null)
                updatedVoteCount = 0;
            return (int)updatedVoteCount;
        }


        public ActionResult Create()
        {            
            return View();
        }
        //
        // POST: /Question/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                int id = questionCRUD.Create(new Question() 
                { title = collection["questionTitle"], body = collection["questionBody"], tags = collection["questionTags"] });

                return RedirectToAction("Index", new { id = id});
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Question/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var question = questionCRUD.Read(id);
                return View(question);
            }
            catch
            {
                return View();
            }
        
        }
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            Question question = new Question();
            question.id = int.Parse(collection["questionId"]);
            question.body = collection["questionBody"];
            question.tags = collection["questionTags"];
            question.title = collection["questionTitle"];

            questionCRUD.Update(question);

            return RedirectToAction("Index", new { id = question.id });
        }

        //
        // GET: /Question/Delete/5

        public ActionResult Delete(int id)
        {
            questionCRUD.Delete(id);
            return View("Index");
        }

        //
        // POST: /Question/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
