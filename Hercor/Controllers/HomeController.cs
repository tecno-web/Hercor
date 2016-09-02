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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ricort(string name, string phone ,string email,string metros,string lugar,string estilo,string plantas,string topografia, string message)
        {
            MailMessage mail = new MailMessage("info@hercor.com.bo", "josepe.pedraza@gmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.carnation.arvixe.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("info@hercor.com.bo", "hn89sxMC78");
            mail.CC.Add("josepe.pedraza@gmail.com");
            mail.Subject = String.Format("Correo de contacto pagina web Ricort de: {0}", name);
            mail.IsBodyHtml = true;
            mail.Body = String.Format
                ("<strong>Nombre de Contancto: {0}</strong><br><strong>Email: {1}</strong><br><strong>Telefono: {2}</strong><br><strong>Metros: {3}</strong><br><strong>Lugar: {4}</strong><br><strong>Estilo: {5}</strong><br><strong>Cantidad PLantas: {6}</strong><br><strong>Situacion Topografica: {7}</strong><br><strong>Comentarios: {8}</strong>", 
                name, email,phone,metros,lugar,estilo,plantas,topografia,message);
            client.Send(mail);
            ViewBag.Mensaje = "Se envio";
            var product = model.Product;
            ViewBag.Envio = "Se envio correctamente su cotización";
            return View(product.ToList());
        }
        public ActionResult Ricort()
        {
            var product = model.Product;
            return View(product.ToList());
        }
        
    }
}