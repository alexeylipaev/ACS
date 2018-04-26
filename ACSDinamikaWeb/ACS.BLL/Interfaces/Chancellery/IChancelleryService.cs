using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    /*
  public int? FolderId { get; set; }


    public int? JournalRegistrationsId { get; set; }


    public byte? TypeRecordId { get; set; }


    public int? ResponsibleUserId { get; set; }
     */
    public interface IChancelleryService
    {
        void MakeChancellery(ChancelleryDTO chancelleryDto);
        void GetChancelleryFolder(ChancelleryDTO chancelleryDto);
        ChancelleryDTO GetChancellery(int? id);
        IEnumerable<ChancelleryDTO> GetChancelleries();

        void Dispose();
    }
}
