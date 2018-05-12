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

        public int id { get; set; }

        public DateTime? DateRegistration { get; set; }

        public string RegistrationNumber { get; set; }

        public string Summary { get; set; }

        public string Notice { get; set; }

        #region папка

        public virtual FolderChancellery FolderChancellery { get; set; }

        #endregion

        #region Журнал

        public virtual JournalRegistrationsChancellery JournalRegistrationsChancellery { get; set; }

        #endregion

        #region Тип

        public virtual TypeRecordChancellery TypeRecordChancellery { get; set; }

        #endregion

        #region Ответственный

        public virtual Employee Employee { get; set; }

        #endregion

        public virtual ICollection<FileRecordChancellery> FileRecordChancelleries { get; set; }
        public virtual ICollection<FromChancellery> FromChancelleries { get; set; }
        public virtual ICollection<ToChancellery> ToChancelleries { get; set; }
    }
}
