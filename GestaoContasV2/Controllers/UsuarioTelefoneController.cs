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
    public class UsuarioTelefoneController : ApiController
    {        
        [HttpGet]
        public IEnumerable<TBCCC_004_TELE> selecionarTelefoneTodos()
        {
            return new UsuarioTelefoneModel().findAll().AsEnumerable();
        }
    }
}
