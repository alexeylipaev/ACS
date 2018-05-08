using JetBrains.Annotations;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Monads;

namespace NLayerApp.DAL.EF
{
    /// <summary>
    /// Фабрика DbContext
    /// </summary>
    public class DbContextFactory : IDbContextFactory<MobileContext>
    {
        private readonly string _connectionString;
        private readonly Func<string, MobileContext> _creator;

        public DbContextFactory([NotNull] string connectionString, [NotNull] Func<string, MobileContext> creator)
        {
            _connectionString = connectionString.CheckNull("connectionString");
            _creator = creator.CheckNull("creator");
        }

        public MobileContext Create()
        {
            return _creator(_connectionString);
        }
    }
}
