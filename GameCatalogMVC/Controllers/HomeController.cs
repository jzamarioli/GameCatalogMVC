using System;
using System.Web.Mvc;
using GameCatalogMVC.Models;
using System.Web.Helpers;
using System.Configuration;
using Microsoft.Web.Helpers;

namespace GameCatalogMVC.Controllers
{
    public class HomeController : Controller
    {       
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Localizacao()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contato()
        {
            return View();
        }

        [HttpPost]        
        //public ActionResult Email_Enviar(string nomeremetente, string emailremetente, string body)
        public ActionResult Contato(Email Model)
        {
            if (!ReCaptcha.Validate(System.Configuration.ConfigurationManager.AppSettings["ReCaptchaPrivateKey"]))
            {
                ViewData.ModelState.AddModelError("_FORM", "Digite o código de verificação corretamente");
                return View();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     WebMail.SmtpServer = ConfigurationManager.AppSettings["email_smtpserver"];              
                    WebMail.SmtpPort = Int32.Parse(ConfigurationManager.AppSettings["email_smtpport"]);                    
                    WebMail.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["email_enablessl"]);
                    WebMail.UserName = ConfigurationManager.AppSettings["email_username"];                  
                    WebMail.Password = ConfigurationManager.AppSettings["email_password"];                    
                    string emailaddress = ConfigurationManager.AppSettings["email_address"];
                    WebMail.From = Model.EmailRemetente;
                    string NomeRemetente = Server.HtmlEncode(Model.NomeRemetente);
                    string Mensagem = Server.HtmlEncode(Model.Mensagem);
                    string Body = "Enviado por: <b>" + NomeRemetente + " (" + Model.EmailRemetente + ")</b><br /><br />" + Mensagem;
                    WebMail.Send(to: emailaddress, subject: "Contato de visitante no site em " + DateTime.Today.ToShortDateString(), body: Body, replyTo: Model.EmailRemetente);                    
                    ViewBag.Enviado = 1;
                    return View();
                }
                catch (Exception ex)
                {
                    ViewData.ModelState.AddModelError("_FORM", "Ocorreu um erro no envio do e-mail.");
                    //ViewData.ModelState.AddModelError("_FORM", ex.ToString());
                    ViewBag.Enviado = 0;
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        
    }
}
