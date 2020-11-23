using AspnetMVC_FirebaseTutorial.Models;
using Firebase.Auth;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspnetMVC_FirebaseTutorial.Controllers
{
    public class AccountController : Controller
    {
        private static string ApiKey = "AIzaSyDRr1WqIf33SZ0-O6rq9aJ5Mhd2Wcesz7o";
      //  private static string Bucket = "messageapp-be75d.appspot.com";
        // GET: Account
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SignUp(SignUpModal model)
        {
            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));

                var a = await auth.CreateUserWithEmailAndPasswordAsync(model.Email, model.Password, model.Name, true);
                ModelState.AddModelError(string.Empty, "Please Verify your email then login.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                //Verification
                if (this.Request.IsAuthenticated)
                {
                    return this.RedirectLocal(returnUrl);
                }
            }
            catch (Exception ex)
            {
                //Info
                Console.Write(ex);
            }

            //Info
            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                    var ab = await auth.SignInWithEmailAndPasswordAsync(model.Email, model.Password);
                    string token = ab.FirebaseToken;
                    var user = ab.User;
                    if (token != "")
                    {
                        this.SignInUser(user.Email, token, false);
                        return this.RedirectLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid username or password");
                    }


                }

            }
            catch (Exception ex)
            {
                //Info
                Console.Write(ex);
            }

            //Info
            return this.View(model);
        }


        private void SignInUser(string email, string token, bool isPersistent)
        {
            // Intialization
            var claims = new List<Claim>();

            try
            {
                // Setting
                claims.Add(new Claim(ClaimTypes.Email, email));
                claims.Add(new Claim(ClaimTypes.Authentication, token));
                var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie,ClaimTypes.Name,ClaimTypes.Authentication);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                // Sign in.
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIdenties);


            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }
        }

        private void ClaimIdentities(string username, bool isPersistent)
        {
            // Intialization
            var claims = new List<Claim>();
            try
            {
                // Setting
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdentites = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }
        }

        private ActionResult RedirectLocal(string returnUrl)
        {
            try
            {
                // Verification
                if (Url.IsLocalUrl(returnUrl))
                {
                    // Info
                    return this.Redirect(returnUrl);
                }

            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }
            return this.RedirectToAction("LogOff", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");           

        }
    }
}