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
                var artworkjson = httpRequest.Form[0];
                var artwork = JsonConvert.DeserializeObject<TBCCC_006_FATU>(artworkjson);
                if (artwork == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No saved");
                }

                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    artwork.IMG_BOLE_FATU = binaryReader.ReadBytes(file.ContentLength);
                }

                FaturaModel model = new FaturaModel();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model.Inserir(artwork));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = artwork.COD_FATU }));

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
                    var artworkjson = httpRequest.Form[0];
                    var artwork = JsonConvert.DeserializeObject<TBCCC_006_FATU>(artworkjson);

                    if (artwork == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "No saved");
                    }

                    using (var binaryReader = new BinaryReader(file.InputStream))
                    {
                        artwork.IMG_BOLE_FATU = binaryReader.ReadBytes(file.ContentLength);
                    }

                    FaturaModel model = new FaturaModel();

                    model.Alterar(artwork);
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage deletarFatura(int codigoFatura)
        {
            FaturaModel model = new FaturaModel();

            int retorno = 0;           

            try
            {
                retorno = model.Deletar(codigoFatura);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, retorno);
        }

        
    }
}
