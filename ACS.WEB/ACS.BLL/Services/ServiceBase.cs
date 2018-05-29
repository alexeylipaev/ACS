using ACS.BLL.Infrastructure;
using ACS.DAL.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Services
{
    public class ServiceBase
    {
        private IUnitOfWork db;

        public ServiceBase(IUnitOfWork uow)
        {
            this.db = uow;
            MapDB.Init(uow);
        }

        protected virtual IUnitOfWork Database
        {
            get { return db; }
        }
        public void CatchError(Exception e)
        {
            Debug.WriteLine("Имя члена:               {0}", e.TargetSite);
            Debug.WriteLine("Класс определяющий член: {0}", e.TargetSite.DeclaringType);
            Debug.WriteLine("Тип члена:               {0}", e.TargetSite.MemberType);
            Debug.WriteLine("Message:                 {0}", e.Message);
            Debug.WriteLine("Source:                  {0}", e.Source);
            Debug.WriteLine("Help Link:               {0}", e.HelpLink);
            Debug.WriteLine("Stack:                   {0}", e.StackTrace);

            foreach (DictionaryEntry de in e.Data)
                Console.WriteLine("{0} : {1}", de.Key, de.Value);
            throw e;
        }

        public int CheckAuthorAndGetIndexAuthor(string authorEmail)
        {
            var Author = Database.Employees.Find(u => u.Email == authorEmail).FirstOrDefault();
            var AuthorUser = Database.UserManager.FindByEmail(authorEmail);

            if (Author == null && AuthorUser == null)
                throw new ValidationException("Невозможно идентифицировать текущего пользователя по почте", authorEmail);

            return Author != null ? Author.Id : AuthorUser.Id;
        }

    }
}
