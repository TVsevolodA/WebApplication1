using System.Web.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        public Dictionary<string, string> users = new Dictionary<string, string>();
        

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Box()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Box(Form form)
        {
            string res = "";
            if (!string.IsNullOrEmpty(form.InputField))
            {
                res += " \"" + form.InputField.ToString() + "\" ";
            }
            if (!string.IsNullOrEmpty(form.ListBoxField))
            {
                res += " \"" + form.ListBoxField.ToString() + "\" ";
            }
            if (!string.IsNullOrEmpty(form.DropDownListField))
            {
                res += " \"" + form.DropDownListField.ToString() + "\" ";
            }
            if (!string.IsNullOrEmpty(form.SelectedAnswer))
            {
                res += " \"" + form.SelectedAnswer.ToString() + "\" ";
            }
            ViewData["Result"] = res;
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Authorization()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Welcome()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registration(User user)
        {
            /*
            if (string.IsNullOrEmpty(user.Login))
            {
                ModelState.AddModelError(nameof(user.Login), "Введите имя");
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                ModelState.AddModelError(nameof(user.Password), "Введите пароль");
            }
            if (string.IsNullOrEmpty(user.СheckPassword))
            {
                ModelState.AddModelError(nameof(user.СheckPassword), "Введите пароль");
            }
            if (user.Password != user.СheckPassword)
            {
                ModelState.AddModelError(nameof(user.Password), "Пароли не совпадают");
            }
            if (ModelState.IsValid)
            {

                users.Add(user.Login.ToLower(), user.Password);
                return Redirect("~/Home/Authorization");
            }*/
            return View(user);
        }

        [HttpPost]
        public ActionResult Authorization(User user)
        {
            users.Add("admin", "admin");
            if (string.IsNullOrEmpty(user.Login))
            {
                ModelState.AddModelError(nameof(user.Login), "Введите имя");
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                ModelState.AddModelError(nameof(user.Password), "Введите пароль");
            }
            if (ModelState.IsValid)
            {
                if ((users.ContainsKey(user.Login.ToLower()) && users.ContainsValue(user.Password)) == false)
                {
                    ModelState.AddModelError(nameof(user.Password), "Имя пользователя или пароль введены неверно");
                }
                else if ((users.ContainsKey(user.Login.ToLower()) && users.ContainsValue(user.Password)) == true)
                {
                    return Redirect("~/Home/Welcome");
                }
            }
            return View(user);
        }
    }
}