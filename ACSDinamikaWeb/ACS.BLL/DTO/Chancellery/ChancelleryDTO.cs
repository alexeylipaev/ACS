using System;
using System.Collections.Generic;


using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    public partial class ChancelleryDTO : SystemParametersDTO
    {
        
       public ChancelleryDTO()
       {
           FileRecordChancelleries = new HashSet<FileRecordChancelleryDTO>();
           FromChancelleries = new HashSet<FromChancelleryDTO>();
           ToChancelleries = new HashSet<ToChancelleryDTO>();
       }

        public int Id { get; set; }

       
        public byte? TypeRecordId { get; set; }

       
      

        public DateTime? DateRegistration { get; set; }

      
        public string RegistrationNumber { get; set; }


       
        public string Summary { get; set; }


        public virtual FolderChancelleryDTO FolderChancellery { get; set; }

        public virtual JournalRegistrationsChancelleryDTO JournalRegistrationsChancellery { get; set; }


      
        public virtual TypeRecordChancelleryDTO TypeRecordChancellery { get; set; }

        
        public virtual UserDTO User { get; set; }


      
        public virtual ICollection<FileRecordChancelleryDTO> FileRecordChancelleries { get; set; }


       
        public virtual ICollection<FromChancelleryDTO> FromChancelleries { get; set; }


        
        public virtual ICollection<ToChancelleryDTO> ToChancelleries { get; set; }
    }
}
