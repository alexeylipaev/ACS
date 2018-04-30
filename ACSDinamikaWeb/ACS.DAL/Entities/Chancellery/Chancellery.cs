using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    public partial class Chancellery : SystemParameters
    {
        
        public Chancellery()
        {
            FileRecordChancelleries = new HashSet<FileRecordChancellery>();
            FromChancelleries = new HashSet<FromChancellery>();
            ToChancelleries = new HashSet<ToChancellery>();
        }

        public int Id { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = @"Дата регистрации")]

        public DateTime? DateRegistration { get; set; }

        [Display(Name = "Регистрационный номер")]
        public string RegistrationNumber { get; set; }


        [Display(Name = "Описание")]
        public string Summary { get; set; }

        #region папка

        public int? FolderId { get; set; }

        public virtual FolderChancellery FolderChancellery { get; set; }

        #endregion

        #region Журнал

        public int? JournalRegistrationsId { get; set; }

        public virtual JournalRegistrationsChancellery JournalRegistrationsChancellery { get; set; }

        #endregion

        #region Тип

        [DisplayFormat(NullDisplayText = @"Выберите тип")]
        public byte? TypeRecordId { get; set; }

        [Display(Name = "Тип записи")]
        public virtual TypeRecordChancellery TypeRecordChancellery { get; set; }

        #endregion

        #region Ответственный

        public int? ResponsibleEmployeeId { get; set; }

        [Display(Name = "Ответственный")]
        public virtual Employee Employee { get; set; }

        #endregion


        [Display(Name = "Файлы")]
        public virtual ICollection<FileRecordChancellery> FileRecordChancelleries { get; set; }

     
        [Display(Name = "От кого")]
        public virtual ICollection<FromChancellery> FromChancelleries { get; set; }

  
        [Display(Name = "Кому")]
        public virtual ICollection<ToChancellery> ToChancelleries { get; set; }
    }
}
