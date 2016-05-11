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
