using ACS.DAL.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Identity
{
    /// <summary>
    /// Валидация пользователя в ASP.NET Identity
    /// </summary>
    public class ApplicationUserValidator : UserValidator<ApplicationUser,int>
    {
         ApplicationUserManager manager { get; set; }

        public ApplicationUserValidator(ApplicationUserManager mgr)
            : base(mgr)
        {
            this.manager = mgr;
            //если равно true, то юзернейм должен содержать только алфавитно-цифровые символы
            AllowOnlyAlphanumericUserNames = false;
            //если равно true, то email пользователя должен быть уникальным
            RequireUniqueEmail = true;
        }
        /// <summary>
        /// Чтобы написать свою логику валидации, надо переопределить метод ValidateAsync
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public override async Task<IdentityResult> ValidateAsync(ApplicationUser user)
        {
          
            IdentityResult result = await base.ValidateAsync(user);
            if (user.Email.ToLower().EndsWith("@spam.com"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Данный домен находится в спам-базе. Выберите другой почтовый сервис");
                result = new IdentityResult(errors);
            }
            if (user.UserName.Contains("admin"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Ник пользователя не должен содержать слово 'admin'");
                result = new IdentityResult(errors);
            }

            return result;
        }
    }
}
