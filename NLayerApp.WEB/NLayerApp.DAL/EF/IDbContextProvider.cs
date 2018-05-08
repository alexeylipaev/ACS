using JetBrains.Annotations;
using System.Data.Entity;


namespace NLayerApp.DAL.EF
{
    /// <summary>
    /// Провайдер сессии EntityFramework
    /// </summary>
    public interface IDbContextProvider
    {
        ///<summary>
        /// Текущая сессия 
        ///</summary>
        [CanBeNull]
        MobileContext CurrentDbContext { get; set; }

        /// <summary>
        /// Содержит ли активную сессию
        /// </summary>
        bool IsEmpty { get; }
    }
}
