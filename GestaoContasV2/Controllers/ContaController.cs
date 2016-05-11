using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GestaoContasV2.Models;
using GestaoContasV2.Controllers.Base;

namespace GestaoContas.Controllers
{
    [Serializable]
    public class ContaController : ApiController
    {        
        [HttpGet]
        public IEnumerable<TBCCC_005_CONT> selecionarConta(string nomeConta, string descricaoConta, int codigoUsuario)
        {
            ContaModel model = new ContaModel();

            List<TBCCC_005_CONT> lstConta = new List<TBCCC_005_CONT>();

            if (nomeConta == null && descricaoConta == null && codigoUsuario == 0)
                lstConta = model.findAll();
            else           
                lstConta = model.find(nomeConta, descricaoConta, codigoUsuario);

            return lstConta.AsEnumerable();
        }

        [HttpPost]
        public HttpResponseMessage inserirConta(TBCCC_005_CONT tbcc005)
        {
            if (ModelState.IsValid)
            {
                ContaModel model = new ContaModel();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model.Inserir(tbcc005));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = tbcc005.COD_USUA }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        public HttpResponseMessage alterarConta(TBCCC_005_CONT tbcc005)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                ContaModel model = new ContaModel();

                model.Alterar(tbcc005);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage deletarConta(int codigoConta)
        {
            ContaModel model = new ContaModel();

            int retorno = 0;           

            try
            {
                retorno = model.Deletar(codigoConta);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, retorno);
        }
    }
}
