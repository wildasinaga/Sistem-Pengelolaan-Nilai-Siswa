﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.DAL;
using System.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private SchoolContext db = new SchoolContext();
        // GET: User
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login account)
        {
            DataTable personTable = new DataTable();
            var persons = db.Login.Where(s => s.Email == account.Email && s.Password == account.Password).FirstOrDefault();
            if (persons == null)
            {
                return RedirectToAction("index", "Login");
            }

            Session["ID"] = persons.Id;
            Session["Nama"] = persons.FirstName + " " + persons.LastName;
            Session["Role"] = persons.Role;

            return RedirectToAction("index", "Home");

        }

        public ActionResult Logout()
        {
            Session.Remove("Id");
            Session.Remove("Nama");
            Session.Remove("Role");
            return RedirectToAction("Index", "Login");
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
