using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoContasV2.Models
{
    [Serializable]
    public class UsuarioTelefoneModel
    {
        DBCCC00Entities entity = null;

        public List<TBCCC_004_TELE> findAll()
        {
            entity = new DBCCC00Entities();

            var selectTBCCC_004 = from t in entity.TBCCC_004_TELE select t;

            return selectTBCCC_004.ToList();
        }        

        public int Inserir(TBCCC_004_TELE tbcc004)
        {
            entity = new DBCCC00Entities();

            entity.TBCCC_004_TELE.Add(tbcc004);

            return entity.SaveChanges();
        }

        public int Alterar(TBCCC_004_TELE tbcc004)
        {
            entity = new DBCCC00Entities();

            var temp = entity.TBCCC_004_TELE.Where(s => s.COD_TELE == tbcc004.COD_TELE).FirstOrDefault();

            if (temp != null)
            {               
                temp.COD_TELE = tbcc004.COD_TELE;               
                temp.NUM_DDI_CELU = tbcc004.NUM_DDI_CELU;
                temp.NUM_DDD_CELU = tbcc004.NUM_DDD_CELU;
                temp.NUM_TELE_CELU = tbcc004.NUM_TELE_CELU;
                temp.NUM_DDI_FIXO = tbcc004.NUM_DDI_FIXO;
                temp.NUM_DDD_FIXO = tbcc004.NUM_DDD_FIXO;
                temp.NUM_TELE_FIXO = tbcc004.NUM_TELE_FIXO;
            }

            entity.Entry(temp).State = System.Data.Entity.EntityState.Modified;
            
            return entity.SaveChanges();
        }

        public int Deletar(int codigo)
        {
            entity = new DBCCC00Entities();

            var temp = entity.TBCCC_004_TELE.Where(s => s.COD_TELE == codigo).FirstOrDefault();
                        
            entity.TBCCC_004_TELE.Remove(temp);

            return entity.SaveChanges();          
           
        }

    }
}