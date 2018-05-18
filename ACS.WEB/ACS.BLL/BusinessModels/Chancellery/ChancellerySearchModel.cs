using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACS.BLL.BusinessModels
{

    public class ChancellerySearchModel
    {
        public int? Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата регистрации от")]
        public DateTime? RegistryDateFrom { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата регистрации до")]
        public DateTime? RegistryDateTo { get; set; }
        public string FromContains { get; set; }
        public string ToContains { get; set; }
        public string ResponsibleContains { get; set; }
        public int? FolderId { get; set; }
        public int? TypeRecordId { get; set; }
    }
}