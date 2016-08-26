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
            MailMessage mail = new MailMessage("info@hercor.com.bo", "acortez@ricortconstructora.com");
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.carnation.arvixe.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("info@hercor.com.bo", "hn89sxMC78");
            mail.CC.Add("josepe.pedraza@gmail.com");
            mail.Subject =  String.Format("Correo de contacto pagina web Hercor de: {0}",name);
            mail.IsBodyHtml = true;
            mail.Body = String.Format("<strong>Email de Contancto: {0}</strong><br><strong>Mensaje: {1}</strong>",email,message);
            client.Send(mail);
            ViewBag.Mensaje = "Se envio";
            var product = model.Product;
            var banner = model.Banner;
            ViewBag.data = banner.ToList();
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