//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestaoContasV2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBCCC_006_FATU
    {
        public int COD_FATU { get; set; }
        public int COD_CONT { get; set; }
        public string DES_FATU { get; set; }
        public System.DateTime DAT_UPLO_FATU { get; set; }
        public System.DateTime DAT_VENC_FATU { get; set; }
        public byte[] IMG_BOLE_FATU { get; set; }
        public string IND_STAT_FATU { get; set; }
    
        public virtual TBCCC_005_CONT TBCCC_005_CONT { get; set; }
    }
}
