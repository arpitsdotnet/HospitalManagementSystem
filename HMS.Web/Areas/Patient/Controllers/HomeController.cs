﻿using Microsoft.AspNetCore.Mvc;

namespace HMS.Web.Areas.Patient.Controllers;

[Area("Patient")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
