using ACS.BLL;
using ACS.WEB.App_Start;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace ACS.WEB.Models.ActiveDirectoryAuthentication
{
    public class AdAuthenticationService
    {
        public class AuthenticationResult
        {
            public AuthenticationResult(string errorMessage = null)
            {
                ErrorMessage = errorMessage;
            }

            public String ErrorMessage { get; private set; }
            public Boolean IsSuccess => String.IsNullOrEmpty(ErrorMessage);
        }

        private readonly IAuthenticationManager authenticationManager;

        public AdAuthenticationService(IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }


        /// <summary>
        /// Check if username and password matches existing account in AD. 
        /// </summary>
        /// <param name="userEMail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public AuthenticationResult SignIn(String userEMail, String password)
        {
//#if DEBUG
//            // authenticates against your local machine - for development time
//            ContextType authenticationType = ContextType.Machine;
//#else
            // authenticates against your Domain AD
            ContextType authenticationType = ContextType.Domain;
            //#endif
            string userADName = ActiveDirectory.SearchForMailInAD(userEMail);
            PrincipalContext principalContext = new PrincipalContext(authenticationType);
            bool isAuthenticated = false;
            UserPrincipal userPrincipal = null;
            try
            {
                isAuthenticated = principalContext.ValidateCredentials(userADName, password, ContextOptions.Negotiate);
                if (isAuthenticated)
                {
                    userPrincipal = UserPrincipal.FindByIdentity(principalContext, userADName);
                }
            }
            catch (Exception)
            {
                isAuthenticated = false;
                userPrincipal = null;
            }

            if (!isAuthenticated || userPrincipal == null)
            {
                return new AuthenticationResult("Неправильное имя пользователя или пароль");
            }

            if (userPrincipal.IsAccountLockedOut())
            {
                // here can be a security related discussion weather it is worth 
                // revealing this information
                return new AuthenticationResult("Ваш аккаунт заблокирован.");
            }

            if (userPrincipal.Enabled.HasValue && userPrincipal.Enabled.Value == false)
            {
                // here can be a security related discussion weather it is worth 
                // revealing this information
                return new AuthenticationResult("Ваша учетная запись отключена");
            }

            var identity = CreateIdentity(userPrincipal);

            authenticationManager.SignOut(MyAuthentication.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, identity);


            return new AuthenticationResult();
        }


        private ClaimsIdentity CreateIdentity(UserPrincipal userPrincipal)
        {
            var identity = new ClaimsIdentity(MyAuthentication.ApplicationCookie, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "Active Directory"));
            //identity.AddClaim(new Claim(ClaimTypes.Name, userPrincipal.SamAccountName));
            identity.AddClaim(new Claim(ClaimTypes.Name, userPrincipal.EmailAddress));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userPrincipal.SamAccountName));
            if (!String.IsNullOrEmpty(userPrincipal.EmailAddress))
            {
                identity.AddClaim(new Claim(ClaimTypes.Email, userPrincipal.EmailAddress));
            }

            // add your own claims if you need to add more information stored on the cookie

            return identity;
        }
    }
}