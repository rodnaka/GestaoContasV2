using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using GestaoContasV2.Models;


namespace GestaoContasV2.Controllers.Base
{
    public class BaseController : ApiController
    {
        public CookieHeaderValue UsuarioLogado
        {
            get;
            set;
        }


    }
}
