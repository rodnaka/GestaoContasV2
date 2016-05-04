using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GestaoContasV2.Models
{
    [Serializable]
    public class UsuarioModel
    {
        DBCCC00Entities entity = null;

        public List<TBCCC_001_USUA> findAll()
        {
            entity = new DBCCC00Entities();

            var selectTBCCC_001_USUA = from t in entity.TBCCC_001_USUA select t;

            return selectTBCCC_001_USUA.ToList();
        }

        public TBCCC_001_USUA find(string nomeUsuario, string emailUsuario)
        {
            entity = new DBCCC00Entities();

            return entity.TBCCC_001_USUA.Where(s => s.NOM_USUA.Contains(nomeUsuario) || s.DES_EMAIL.Contains(emailUsuario)).FirstOrDefault();            
        }

        public TBCCC_001_USUA findLogin(string emailUsuario, string senhaUsuario)
        {
            entity = new DBCCC00Entities();

            return entity.TBCCC_001_USUA.Where(s => s.DES_EMAIL.Equals(emailUsuario) && s.NUM_SENH.Equals(senhaUsuario)).FirstOrDefault();
        }

        public int Inserir(TBCCC_001_USUA tbcc001usua)
        {
            entity = new DBCCC00Entities();

            entity.TBCCC_001_USUA.Add(tbcc001usua);

            return entity.SaveChanges();
        }

        public int Alterar(TBCCC_001_USUA tbcc001usua)
        {
            entity = new DBCCC00Entities();

            var temp = entity.TBCCC_001_USUA.Where(s => s.COD_USUA == tbcc001usua.COD_USUA).FirstOrDefault();
           

            if (temp != null)
            {
                temp.COD_USUA = tbcc001usua.COD_USUA;
                temp.COD_ESTA_CIVI = tbcc001usua.COD_ESTA_CIVI;
                //temp.COD_ENDE = tbcc001usua.COD_ENDE;
                //temp.COD_TELE = tbcc001usua.COD_TELE;
                temp.NOM_USUA = tbcc001usua.NOM_USUA;
                temp.NOM_SEXO = tbcc001usua.NOM_SEXO;
                temp.NUM_CPF_CNPJ = tbcc001usua.NUM_CPF_CNPJ;
                temp.NUM_RG = tbcc001usua.NUM_RG;
                temp.DES_EMAIL = tbcc001usua.DES_EMAIL;
                temp.NUM_SENH = tbcc001usua.NUM_SENH;
                temp.NOM_ORGA_EMIS = tbcc001usua.NOM_ORGA_EMIS;
                temp.NOM_ESTA_EMIS = tbcc001usua.NOM_ESTA_EMIS;
                temp.NOM_MAE = tbcc001usua.NOM_MAE;
                temp.NOM_PAI = tbcc001usua.NOM_PAI;
                temp.DES_NATU = tbcc001usua.DES_NATU;
                temp.DAT_INCL_USUA = tbcc001usua.DAT_INCL_USUA;
                temp.DAT_ALTE_USUA = tbcc001usua.DAT_ALTE_USUA;
                temp.DAT_NASC_USUA = tbcc001usua.DAT_NASC_USUA;
                temp.IND_STAT_USUA = tbcc001usua.IND_STAT_USUA;
                temp.IND_ALTE = tbcc001usua.IND_ALTE;
                temp.IND_CONS = tbcc001usua.IND_CONS;
                temp.IND_EXCL = tbcc001usua.IND_EXCL;
                temp.IND_INCL = tbcc001usua.IND_INCL;
                temp.TBCCC_003_ENDE.NUM_CEP = tbcc001usua.TBCCC_003_ENDE.NUM_CEP;
                temp.TBCCC_003_ENDE.DES_LOGR = tbcc001usua.TBCCC_003_ENDE.DES_LOGR;
                temp.TBCCC_003_ENDE.NUM_NUME = tbcc001usua.TBCCC_003_ENDE.NUM_NUME;
                temp.TBCCC_003_ENDE.DES_COMP = tbcc001usua.TBCCC_003_ENDE.DES_COMP;
                temp.TBCCC_003_ENDE.DES_BAIR = tbcc001usua.TBCCC_003_ENDE.DES_BAIR;
                temp.TBCCC_003_ENDE.DES_CIDA = tbcc001usua.TBCCC_003_ENDE.DES_CIDA;
                temp.TBCCC_003_ENDE.DES_ESTA = tbcc001usua.TBCCC_003_ENDE.DES_ESTA;
                temp.TBCCC_004_TELE.NUM_DDI_CELU = tbcc001usua.TBCCC_004_TELE.NUM_DDI_CELU;
                temp.TBCCC_004_TELE.NUM_DDD_CELU = tbcc001usua.TBCCC_004_TELE.NUM_DDD_CELU;
                temp.TBCCC_004_TELE.NUM_TELE_CELU = tbcc001usua.TBCCC_004_TELE.NUM_TELE_CELU;
                temp.TBCCC_004_TELE.NUM_DDI_FIXO = tbcc001usua.TBCCC_004_TELE.NUM_DDI_FIXO;
                temp.TBCCC_004_TELE.NUM_DDD_FIXO = tbcc001usua.TBCCC_004_TELE.NUM_DDD_FIXO;
                temp.TBCCC_004_TELE.NUM_TELE_FIXO = tbcc001usua.TBCCC_004_TELE.NUM_TELE_FIXO;
            }

            entity.Entry(temp).State = System.Data.Entity.EntityState.Modified;
            
            return entity.SaveChanges();
        }

        public int Deletar(int codUsuario)
        {
            entity = new DBCCC00Entities();

            var temp = entity.TBCCC_001_USUA.Where(s => s.COD_USUA == codUsuario).FirstOrDefault();
                        
            entity.TBCCC_001_USUA.Remove(temp);

            return entity.SaveChanges();          
           
        }

    }
}