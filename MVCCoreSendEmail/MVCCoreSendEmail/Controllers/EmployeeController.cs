using Microsoft.AspNetCore.Mvc;
using MVCCoreSendEmail.Models;
using MVCCoreSendEmail.Services;

namespace MVCCoreSendEmail.Controllers
{
    public class EmployeeController : Controller
    {
        IEmailService _emailservice;
        public EmployeeController(IEmailService emailservice)
        {
            _emailservice = emailservice;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(EmailModel em)
        {

            _emailservice.SendEmail(em);
            ViewBag.msg = "Email Sent Successfully";
            ModelState.Clear();
            return View();
        }
    }
}
