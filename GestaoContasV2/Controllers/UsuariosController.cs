using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GestaoContasV2.Models;

namespace GestaoContas.Controllers
{
    [Serializable]
    public class UsuariosController : ApiController
    {        
        [HttpGet]
        public IEnumerable<TBCCC_001_USUA> selecionarUsuario(string nomeUsuario, string emailUsuario)
        {
            UsuarioModel model = new UsuarioModel();

            List<TBCCC_001_USUA> lstUsuarios = new List<TBCCC_001_USUA>();

            if (nomeUsuario == null && emailUsuario == null)
                lstUsuarios = model.findAll();
            else
            {
                TBCCC_001_USUA usuario = model.find(nomeUsuario, emailUsuario);

                if (usuario == null)
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                }
                else
                    lstUsuarios.Add(usuario);
            }
                

            return lstUsuarios.AsEnumerable();
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

        [HttpPut]
        public HttpResponseMessage alterarUsuario(TBCCC_001_USUA tbcc001usua)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                UsuarioModel model = new UsuarioModel();

                model.Alterar(tbcc001usua);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage studentDelete(int tbcc001usua)
        {
            UsuarioModel model = new UsuarioModel();
            int retorno = 0;
           

            try
            {
                retorno = model.Deletar(tbcc001usua);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, retorno);
        }
    }
}
