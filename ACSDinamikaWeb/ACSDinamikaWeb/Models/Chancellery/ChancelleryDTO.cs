using System;
using System.Collections.Generic;


using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSWeb.Models
{
    public partial class ChancelleryViewModel : SystemParametersViewModel
    {
        
       public ChancelleryViewModel()
       {
           FileRecordChancelleries = new HashSet<FileRecordChancelleryViewModel>();
           FromChancelleries = new HashSet<FromChancelleryViewModel>();
           ToChancelleries = new HashSet<ToChancelleryViewModel>();
       }

        public int Id { get; set; }

       
        public byte? TypeRecordId { get; set; }

       
      

        public DateTime? DateRegistration { get; set; }

      
        public string RegistrationNumber { get; set; }


       
        public string Summary { get; set; }


        public virtual FolderChancelleryViewModel FolderChancellery { get; set; }

        public virtual JournalRegistrationsChancelleryViewModel JournalRegistrationsChancellery { get; set; }


      
        public virtual TypeRecordChancelleryViewModel TypeRecordChancellery { get; set; }

        
        public virtual UserViewModel User { get; set; }


      
        public virtual ICollection<FileRecordChancelleryViewModel> FileRecordChancelleries { get; set; }


       
        public virtual ICollection<FromChancelleryViewModel> FromChancelleries { get; set; }


        
        public virtual ICollection<ToChancelleryViewModel> ToChancelleries { get; set; }
    }
}
