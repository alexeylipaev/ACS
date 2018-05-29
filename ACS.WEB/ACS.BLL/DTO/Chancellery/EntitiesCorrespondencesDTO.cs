using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    public partial class CorrespondencesBaseDTO : EntityDTO
    {
        #region simple prop
        public string RegistrationNumber { get; set; }
        public DateTime? DateRegistration { get; set; }
        public string Summary { get; set; }
        public string Notice { get; set; }
        public string Status { get; set; }

        #endregion
        public int TypeRecordChancelleryId { get; set; }
        public int? FolderChancelleryId { get; set; }
        public int? JournalRegistrationsChancelleryId { get; set; }
        public virtual IEnumerable<int> ResponsibleEmployees { get; set; }
        public virtual IEnumerable<int> FileRecordChancelleries { get; set; }
    }

    /// <summary>
    /// Входящая канцелярия
    /// </summary>
    public class IncomingCorrespondencyDTO : CorrespondencesBaseDTO
    {
        /// <summary>
        /// От кого"
        /// </summary>
        public int? From_ExternalOrganizationChancelleryId { get; set; }

        /// <summary>
        /// Кому
        /// </summary>
        public int? To_EmployeeId { get; set; }
    }
    /// <summary>
    /// Исходящая канцелярия
    /// </summary>
    public class OutgoingCorrespondencyDTO : CorrespondencesBaseDTO
    {
        /// <summary>
        /// От кого"
        /// </summary>
        public int? From_EmployeeId { get; set; }

        /// <summary>
        /// Кому
        /// </summary>
        public IEnumerable<int> To_ExtOrgns { get; set; }

    }
    /// <summary>
    /// Внутреняя
    /// </summary>
    public class InternalCorrespondencyDTO : CorrespondencesBaseDTO
    {
        /// <summary>
        /// От кого
        /// </summary>
        public int? From_EmployeeId { get; set; }
        /// <summary>
        /// Кому
        /// </summary>
        public IEnumerable<int> To_Employees { get; set; }
    }

    /// <summary>
    /// Тип канцелярской записи
    /// </summary>
    public partial class TypeRecordCorrespondencesDTO : EntityDTO
    {
        public string Name { get; set; }

        /// <summary>
        /// Канцелярские записи которые имеют this тип
        /// </summary>
        public virtual IEnumerable<int> Chancelleries { get; set; }
    }

    /// <summary>
    /// Журнал канцелярский
    /// </summary>
    public partial class JournalRegistrationsCorrespondencesDTO : EntityDTO
    {
        public string Name { get; set; }

        public virtual IEnumerable<int> Chancelleries { get; set; }
    }
    /// <summary>
    /// Канцелярская папка
    /// </summary>
    public partial class FolderCorrespondencesDTO : EntityDTO
    {
        public string Name { get; set; }

        /// <summary>
        /// Канцелярские записи в папке
        /// </summary>
        public virtual IEnumerable<int> Chancelleries { get; set; }
    }
}
