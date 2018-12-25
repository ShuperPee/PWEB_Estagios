using Microsoft.AspNet.Identity;
using PWEB_Estagios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PWEB_Estagios.Controllers
{
    public class EmpresaController : Controller
    {

        private PropostasContext context = new PropostasContext();
        // GET: Empresa
        [Authorize(Roles = "Empresa")]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Empresa")]
        public ActionResult Perfil()
        {
            string strCurrentUserId = User.Identity.GetUserId();
            return View(context.Empresas.Where(s => s.UserId == strCurrentUserId).FirstOrDefault());
        }
        [Authorize(Roles = "Empresa")]
        public ActionResult Edit()
        {
            string strCurrentUserId = User.Identity.GetUserId();
            return View(context.Empresas.Where(s => s.UserId == strCurrentUserId).FirstOrDefault());
        }
        [HttpPost]
        [Authorize(Roles = "Empresa")]
        public ActionResult Edit(Empresa empresa)
        {
            if (empresa != null)
            {

                string strCurrentUserId = User.Identity.GetUserId();
                Empresa contaEmpresa = context.Empresas.Where(s => s.UserId == strCurrentUserId).FirstOrDefault();
                contaEmpresa.Nome = empresa.Nome;
                contaEmpresa.Sede = empresa.Sede;
                contaEmpresa.EmpresaNIF = empresa.EmpresaNIF;
                if (ModelState.IsValid)
                {
                    var contaToUpdate = context.Empresas.Where(s => s.UserId == strCurrentUserId).FirstOrDefault();
                    if (TryUpdateModel(contaToUpdate, "", new string[] { "Nome", "Sede", "EmpresaNIF"}))
                    {
                        try
                        {
                            context.SaveChanges();
                            return RedirectToAction("Perfil");
                        }
                        catch (Exception)
                        {
                            ModelState.AddModelError("", "Não foi possivel atualizar o modelo!");
                        }
                    }
                    return RedirectToAction("Perfil");
                }

            }
            return View(empresa);
        }
    }
}