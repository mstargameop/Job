﻿using Project.Areas.JobArea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Areas.JobArea.Controllers
{
    public class JobController : Controller
    {
        private IRepository<Job> db = new Repository<Job>();
        private SuperUniversityEntities1 su = new SuperUniversityEntities1();
        // GET: JobArea/Job
        public ActionResult Index()
        {
            List<Job> jb = db.GetAll().ToList();
            ViewBag.Result = TempData["Result"];
            return View(jb);
        }
        [HttpGet]
        public ActionResult Insert()
        {
            ViewBag.datas = su.Jobtime.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Job j)
        {
            if (this.ModelState.IsValid)
            {
            db.Create(j);
                TempData["Result"] = string.Format("工作{0}新增成功", j.JobName);
            ViewBag.datas = su.Jobtime.ToList();
            return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Result = "資料錯誤，請檢查";
                return View(j);
            }

        }
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            ViewBag.datas = su.Jobtime.ToList();
            return View(su.Job.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(Job j, int id)
        {
            j.JobID = id;
            db.Update(j);
            ViewBag.datas = su.Jobtime.ToList();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id = 0)
        {
            db.Delete(db.GetById(id));
            return RedirectToAction("Index");

        }
    }
}