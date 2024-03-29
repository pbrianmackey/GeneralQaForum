﻿using Feedback.BL;
using Feedback.DL;
using Feedback.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Feedback.Controllers
{
    public class TagController : Controller
    {
        TagCRUD tagCrud = new TagCRUD();
        //
        // GET: /Tag/


        public string Lookup(string tagName)
        {
            List<Tag> items = new List<Tag>();
            items.AddRange(tagCrud.Lookup(tagName));            

            var serializer = new JavaScriptSerializer();
            var result = serializer.Serialize(items);
            return result;
        }

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Tag/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Tag/Create

        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /Tag/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string name = collection["tagName"];
                string description = collection["tagDescription"];
                tagCrud.Create(name,description);
                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Tag/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Tag/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Tag/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Tag/Delete/5

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
