using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoContasV2.Models
{
    [Serializable]
    public class FaturaModel
    {
        DBCCC00Entities entity = null;

        public List<TBCCC_006_FATU> findAll()
        {
            entity = new DBCCC00Entities();

            var selectTBCCC_006_FATU = from t in entity.TBCCC_006_FATU select t;

            return selectTBCCC_006_FATU.ToList();
        }

        public List<TBCCC_006_FATU> find(string descricaoFatura, int codigoConta, int codigoFatura)
        {
            entity = new DBCCC00Entities();

            return entity.TBCCC_006_FATU.Where(s => s.COD_FATU == codigoFatura ||  s.COD_CONT == codigoConta || s.DES_FATU.Contains(descricaoFatura)).ToList();            
        }

        public int Inserir(TBCCC_006_FATU tbcc006)
        {
            entity = new DBCCC00Entities();

            entity.TBCCC_006_FATU.Add(tbcc006);

            return entity.SaveChanges();
        }

        public int Alterar(TBCCC_006_FATU tbcc006)
        {
            entity = new DBCCC00Entities();

            var temp = entity.TBCCC_006_FATU.Where(s => s.COD_FATU == tbcc006.COD_FATU).FirstOrDefault();
           

            if (temp != null)
            {
                temp.COD_FATU = tbcc006.COD_FATU;
                temp.COD_CONT = tbcc006.COD_CONT;
                temp.DES_FATU = tbcc006.DES_FATU;
                temp.DAT_UPLO_FATU = tbcc006.DAT_UPLO_FATU;
                temp.DAT_VENC_FATU = tbcc006.DAT_VENC_FATU;
                temp.IMG_BOLE_FATU = tbcc006.IMG_BOLE_FATU;
                temp.IND_STAT_FATU = tbcc006.IND_STAT_FATU;
            }

            entity.Entry(temp).State = System.Data.Entity.EntityState.Modified;
            
            return entity.SaveChanges();
        }

        public int Deletar(int codigoFatura)
        {
            var temp = new DBCCC00Entities().TBCCC_006_FATU.Where(s => s.COD_FATU == codigoFatura).FirstOrDefault();

            temp.IND_STAT_FATU = "P";

            return Alterar(temp);

            //entity = new DBCCC00Entities();

            //var temp = entity.TBCCC_006_FATU.Where(s => s.COD_FATU == codigoFatura).FirstOrDefault();

            //entity.TBCCC_006_FATU.Remove(temp);

            //return entity.SaveChanges();          

        }

        public static implicit operator FaturaModel(string v)
        {
            throw new NotImplementedException();
        }
    }
}