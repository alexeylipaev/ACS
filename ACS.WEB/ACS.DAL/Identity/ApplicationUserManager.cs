using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using ACS.DAL.Entities;
using ACS.DAL.EF;


namespace ACS.DAL.Identity
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, int> store)
            : base(store)
        {
            //Настройте Microsoft.AspNet.Identity, чтобы разрешить адрес электронной почты как имя пользователя
            this.UserValidator = new UserValidator<ApplicationUser,int>(this) { AllowOnlyAlphanumericUserNames = false };
        }
     
    public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {

            var manager = new ApplicationUserManager(
              new AppUserStore(context.Get<ACSContext>()));


            //// валидация пользователя
            //manager.UserValidator = new UserValidator<ApplicationUser, int>(manager)
            //{
            //    //если равно true, то юзернейм должен содержать только алфавитно-цифровые символы
            //    AllowOnlyAlphanumericUserNames = false,
            //    //если равно true, то email пользователя должен быть уникальным
            //    RequireUniqueEmail = true,

            //};

            manager.UserValidator = new ApplicationUserValidator(manager);

  

            // Configure validation logic for passwords
           manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Телефонный код", new PhoneNumberTokenProvider<ApplicationUser, int>
            {
                MessageFormat = "Ваш код безопасности {0}"
            });
            manager.RegisterTwoFactorProvider("Код электронной почты", new EmailTokenProvider<ApplicationUser, int>
            {
                Subject = "Код безопасности",
                BodyFormat = "Ваш код безопасности {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
        public ApplicationUser FindByEmail(string Email)
        {
            return (from user in Users
                    where user.Email == Email
                    select user).FirstOrDefault();
        }

        public ApplicationUser FindById(int userId)
        {
            return (from user in Users
                    where user.Id == userId
                    select user).FirstOrDefault();
        }

        public ApplicationUser FindByUserName(string userName)
        {
            return (from user in Users
                    where user.UserName == userName
                    select user).FirstOrDefault();
        }

        public ApplicationUser FindByFullNameEmpl(string fullName)
        {
            return (from user in Users
                    where GetFullName(user.Employee) == fullName
                    select user).FirstOrDefault();
        }


        string GetFullName(Employee empl)
        {
            return string.Format("{0} {1} {2}", empl.LName, empl.FName, empl.MName);
        }
    }
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your Email service here to send an Email.
            return Task.FromResult(0);
        }
    }
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
