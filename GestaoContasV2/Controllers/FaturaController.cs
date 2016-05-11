using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using GestaoContasV2.Models;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;

namespace GestaoContas.Controllers
{
    
    public class FaturaController : ApiController
    {        
        [HttpGet]
        public IEnumerable<TBCCC_006_FATU> selecionarFatura(string descricaoFatura, int codigoConta, int codigoFatura)
        {
            FaturaModel model = new FaturaModel();

            List<TBCCC_006_FATU> lstFatura = new List<TBCCC_006_FATU>();

            if (descricaoFatura == null && codigoConta == 0 && codigoFatura == 0)
                lstFatura = model.findAll();
            else
            {
                lstFatura = model.find(descricaoFatura, codigoConta, codigoFatura);

                if (lstFatura.Count == 0)
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                }     
            }
                

            return lstFatura.AsEnumerable();
        }

        [HttpPost]
        public HttpResponseMessage Post()
        {            
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var file = httpRequest.Files[0];
                var objFatura = httpRequest.Form[0];
                var objPersFatura = JsonConvert.DeserializeObject<TBCCC_006_FATU>(objFatura);
                if (objPersFatura == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No saved");
                }

                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    objPersFatura.IMG_BOLE_FATU = binaryReader.ReadBytes(file.ContentLength);
                }

                FaturaModel model = new FaturaModel();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model.Inserir(objPersFatura));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = objPersFatura.COD_FATU }));

                AtualizarContador(objPersFatura.COD_CONT);

                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put()
        {            

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    var file = httpRequest.Files[0];
                    var objFatura = httpRequest.Form[0];
                    var objPersFatura = JsonConvert.DeserializeObject<TBCCC_006_FATU>(objFatura);

                    if (objPersFatura == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "No saved");
                    }

                    using (var binaryReader = new BinaryReader(file.InputStream))
                    {
                        objPersFatura.IMG_BOLE_FATU = binaryReader.ReadBytes(file.ContentLength);
                    }

                    FaturaModel model = new FaturaModel();

                    model.Alterar(objPersFatura);

                    AtualizarContador(objPersFatura.COD_CONT);
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage deletarFatura(int codigoFatura, int codigoConta)
        {
            FaturaModel model = new FaturaModel();

            int retorno = 0;           

            try
            {
                retorno = model.Deletar(codigoFatura);

                AtualizarContador(codigoConta);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, retorno);
        }


        private void AtualizarContador(int CodigoConta)
        {
            FaturaModel model = new FaturaModel();            

            var lstFatura = from t in model.findContaFatura(CodigoConta) where t.IND_STAT_FATU.Equals("A") select t;

            if (lstFatura != null)
            {
                var objConta = new ContaModel();

                TBCCC_005_CONT conta = objConta.findContaFatura(CodigoConta);

                conta.NUM_FATU_ABER = lstFatura.ToList().Count;
                objConta.Alterar(conta);
            }

        }
        
    }
}
