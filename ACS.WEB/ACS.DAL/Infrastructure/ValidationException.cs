using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Infrastructure
{
     public class DbEntitySaveValidationException : DbEntityValidationException
    {
        public StringBuilder Property  { get; protected set; }
        public DbEntitySaveValidationException(string message, string prop) : base(message)
        {
            if (Property == null)
                Property = new StringBuilder();
            Property.AppendLine(prop);
        }

        public DbEntitySaveValidationException(DbEntityValidationException ex)
        {
            if (Property == null)
                Property = new StringBuilder();

            foreach (var eve in ex.EntityValidationErrors)
            {
                string result = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                Debug.WriteLine(result);
                Property.AppendLine(result);
                foreach (var ve in eve.ValidationErrors)
                {
                    result = string.Format("- Property: \"{0}\", Error: \"{1}\"",
                        ve.PropertyName, ve.ErrorMessage);
                    Debug.WriteLine(result);
                    Property.AppendLine(result);
                }
            }

           
            throw this;
        }

    }
}
