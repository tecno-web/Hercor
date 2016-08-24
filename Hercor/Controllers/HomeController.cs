using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hercor.Models;
using System.Net.Mail;

namespace Hercor.Controllers
{
    public class HomeController : Controller
    {
        ModelFirst model = new ModelFirst();
        //
        // GET: /Home/Index
        public ActionResult Index()
        {
            var product = model.Product;
            var banner = model.Banner;
            ViewBag.data = banner.ToList();
            return View(product.ToList());
        }
        //
        // POST: /Home/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string name,string email,string message)
        {
            MailMessage mail = new MailMessage("josepe.pedraza@gmail.com", "josepe.pedraza@gmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("josepe.pedraza@gmail.com","October_2016");
            mail.Subject =  String.Format("this is a test email {0}",name);
            mail.Body = message;
            client.Send(mail);
            ViewBag.Mensaje = "Se envio";
            var product = model.Product;
            return View(product.ToList());
        }
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            int x = 2;
            if (x == 2)
            {
                throw new Exception("test");
            }
            return View();
        }

        
    }
}