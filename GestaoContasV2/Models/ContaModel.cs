using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoContasV2.Models
{
    [Serializable]
    public class ContaModel
    {
        DBCCC00Entities entity = null;

        public List<TBCCC_005_CONT> findAll()
        {
            entity = new DBCCC00Entities();

            var selectTBCCC_005_CONT = from t in entity.TBCCC_005_CONT select t;

            return selectTBCCC_005_CONT.ToList();
        }

        public TBCCC_005_CONT find(string nomeConta, string descricaoConta, int codigoUsuario)
        {
            entity = new DBCCC00Entities();

            return entity.TBCCC_005_CONT.Where(s => s.NOM_USUA_CONT.Contains(nomeConta) || s.DES_CONT.Contains(descricaoConta) || s.COD_USUA == codigoUsuario).FirstOrDefault();            
        }

        public int Inserir(TBCCC_005_CONT tbcc005)
        {
            entity = new DBCCC00Entities();

            entity.TBCCC_005_CONT.Add(tbcc005);

            return entity.SaveChanges();
        }

        public int Alterar(TBCCC_005_CONT tbcc005)
        {
            entity = new DBCCC00Entities();

            var temp = entity.TBCCC_005_CONT.Where(s => s.COD_CONT == tbcc005.COD_CONT).FirstOrDefault();
           

            if (temp != null)
            {
                temp.COD_CONT = tbcc005.COD_CONT;
                temp.COD_USUA = tbcc005.COD_USUA;
                temp.DES_CONT = tbcc005.DES_CONT;
                temp.NOM_USUA_CONT = tbcc005.NOM_USUA_CONT;
                temp.NUM_AGEN = tbcc005.NUM_AGEN;
                temp.NUM_CONTA = tbcc005.NUM_CONTA;
                temp.NUM_DAC_CONT = tbcc005.NUM_DAC_CONT;
                temp.COD_BANC = tbcc005.COD_BANC;
                temp.NUM_CNPJ_CPF = tbcc005.NUM_CNPJ_CPF;
                temp.DESC_SENH_CONT = tbcc005.DESC_SENH_CONT;
                temp.DAT_INCL_CONT = tbcc005.DAT_INCL_CONT;
                temp.DAT_ALTE_CONT = tbcc005.DAT_ALTE_CONT;
                temp.IND_STAT_CONT = tbcc005.IND_STAT_CONT;
                temp.NUM_FATU_ABER = tbcc005.NUM_FATU_ABER;
            }

            entity.Entry(temp).State = System.Data.Entity.EntityState.Modified;
            
            return entity.SaveChanges();
        }

        public int Deletar(int codConta)
        {
            entity = new DBCCC00Entities();

            var temp = entity.TBCCC_005_CONT.Where(s => s.COD_CONT == codConta).FirstOrDefault();
                        
            entity.TBCCC_005_CONT.Remove(temp);

            return entity.SaveChanges();          
           
        }

    }
}