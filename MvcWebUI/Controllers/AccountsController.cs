using Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Login(UserLoginModel model)
        {

            return View();
        }
    }
}
