using JetBrains.Annotations;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
//using System.Monads;

namespace ACS.DAL.EF
{
    /// <summary>
    /// Фабрика DbContext
    /// </summary>
    public class DbContextFactory : IDbContextFactory<ACSContext>
    {
        //private readonly string _connectionString;
        //private readonly Func<string, ACSContext> _creator;

        //public DbContextFactory(/*[NotNull]*/ string connectionString,/* [NotNull]*/ Func<string, ACSContext> creator)
        //{
        //    if (string.IsNullOrEmpty(connectionString))
        //        connectionString = Сonnection.@string;
        //    _connectionString = connectionString/*.CheckNull("connectionString")*/;
        //    _creator = creator/*.CheckNull("creator")*/;
        //}

        public ACSContext Create()
        {
            return new ACSContext(Сonnection.@string);
        }
    }
}