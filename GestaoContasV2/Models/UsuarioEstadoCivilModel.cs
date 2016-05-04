using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoContasV2.Models
{
    [Serializable]
    public class UsuarioEstadoCivilModel
    {
        DBCCC00Entities entity = null;

        public List<TBCCC_002_ESTA_CIVI> findAll()
        {
            entity = new DBCCC00Entities();

            var selectTBCCC = from t in entity.TBCCC_002_ESTA_CIVI select t;

            return selectTBCCC.ToList();
        } 
    }
}