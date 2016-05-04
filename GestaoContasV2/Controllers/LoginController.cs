using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using GestaoContasV2.Models;
using GestaoContasV2.Controllers.Base;
using System.Net.Http.Headers;

namespace GestaoContasV2.Controllers
{
    public class LoginController : BaseController
    {
        [HttpGet]
        public TBCCC_001_USUA selecionarUsuario(string emailUsuario, string senhalUsuario)
        {
            TBCCC_001_USUA usuario = null;

            if (HttpContext.Current.Request.Cookies != null &&
                HttpContext.Current.Request.Cookies["SESSAO"] != null)
            {
                emailUsuario = HttpContext.Current.Request.Cookies["SESSAO"]["DES_EMAIL"];
                senhalUsuario = HttpContext.Current.Request.Cookies["SESSAO"]["NUM_SENH"];
            }
            
            usuario = new UsuarioModel().findLogin(emailUsuario, senhalUsuario);

            if (usuario == null)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.Unauthorized));
            else
            {
                var lstCookie = new NameValueCollection();
                lstCookie["COD_USUA"] = usuario.COD_USUA.ToString();
                lstCookie["COD_ESTA_CIVI"] = usuario.COD_ESTA_CIVI.ToString();
                lstCookie["COD_ENDE"] = usuario.COD_ENDE.ToString();
                lstCookie["COD_TELE"] = usuario.COD_TELE.ToString();
                lstCookie["NOM_USUA"] = usuario.NOM_USUA.ToString();
                lstCookie["NUM_CPF_CNPJ"] = usuario.NUM_CPF_CNPJ.ToString();
                lstCookie["DES_EMAIL"] = usuario.DES_EMAIL.ToString();
                lstCookie["NUM_SENH"] = usuario.NUM_SENH.ToString();
                lstCookie["IND_STAT_USUA"] = usuario.IND_STAT_USUA.ToString();
                lstCookie["IND_CONS"] = usuario.IND_CONS.ToString();
                lstCookie["IND_INCL"] = usuario.IND_INCL.ToString();
                lstCookie["IND_ALTE"] = usuario.IND_ALTE.ToString();
                lstCookie["IND_EXCL"] = usuario.IND_EXCL.ToString();

                HttpCookie cookie = new HttpCookie("SESSAO");

                cookie.Values.Add(lstCookie);

                HttpContext.Current.Response.Cookies.Add(cookie);
            }           

            return usuario;
        }

        [HttpPost]
        public HttpResponseMessage inserirUsuario(TBCCC_001_USUA tbcc001usua)
        {
            //if (ModelState.IsValid)
            //{
                UsuarioModel model = new UsuarioModel();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model.Inserir(tbcc001usua));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = tbcc001usua.COD_USUA }));
                return response;
            //}
            //else
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            //}
        }

    }
}
