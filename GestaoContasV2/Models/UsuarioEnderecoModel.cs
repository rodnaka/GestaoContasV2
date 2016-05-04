using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoContasV2.Models
{
    [Serializable]
    public class UsuarioEnderecoModel
    {
        DBCCC00Entities entity = null;

        public List<TBCCC_003_ENDE> findAll()
        {
            entity = new DBCCC00Entities();

            var selectTBCCC = from t in entity.TBCCC_003_ENDE select t;

            return selectTBCCC.ToList();
        }        

        public int Inserir(TBCCC_003_ENDE tbcc003)
        {
            entity = new DBCCC00Entities();

            entity.TBCCC_003_ENDE.Add(tbcc003);

            return entity.SaveChanges();
        }

        public int Alterar(TBCCC_003_ENDE tbcc003)
        {
            entity = new DBCCC00Entities();

            var temp = entity.TBCCC_003_ENDE.Where(s => s.COD_ENDE == tbcc003.COD_ENDE).FirstOrDefault();

            if (temp != null)
            {               
                temp.COD_ENDE = tbcc003.COD_ENDE;
                temp.NUM_CEP = tbcc003.NUM_CEP;
                temp.DES_LOGR = tbcc003.DES_LOGR;
                temp.NUM_NUME = tbcc003.NUM_NUME;
                temp.DES_COMP = tbcc003.DES_COMP;
                temp.DES_BAIR = tbcc003.DES_BAIR;
                temp.DES_CIDA = tbcc003.DES_CIDA;
                temp.DES_ESTA = tbcc003.DES_ESTA;
            }

            entity.Entry(temp).State = System.Data.Entity.EntityState.Modified;
            
            return entity.SaveChanges();
        }

        public int Deletar(int codigo)
        {
            entity = new DBCCC00Entities();

            var temp = entity.TBCCC_003_ENDE.Where(s => s.COD_ENDE == codigo).FirstOrDefault();
                        
            entity.TBCCC_003_ENDE.Remove(temp);

            return entity.SaveChanges();          
           
        }

    }
}