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
    public class UsuarioEstadoCivilController : ApiController
    {        
        [HttpGet]
        public IEnumerable<TBCCC_002_ESTA_CIVI> selecionarEstadoCivilTodos()
        {
            return new UsuarioEstadoCivilModel().findAll().AsEnumerable();
        }
    }
}
