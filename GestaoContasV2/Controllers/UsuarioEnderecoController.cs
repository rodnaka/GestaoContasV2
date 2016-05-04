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
    public class UsuarioEnderecoController : ApiController
    {        
        [HttpGet]
        public IEnumerable<TBCCC_003_ENDE> selecionarEnderecoTodos()
        {
            return new UsuarioEnderecoModel().findAll().AsEnumerable();
        }
    }
}
