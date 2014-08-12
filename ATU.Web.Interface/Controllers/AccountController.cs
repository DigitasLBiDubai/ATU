using AutoMapper;
using ATU.Domain;
using ATU.Domain.Abstract;
using ATU.Domain.Model;
using ATU.Web.Domain;
using ATU.Web.Domain.Abstract;
using ATU.Web.Domain.Model;
using ATU.Web.Interface.Filters;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace ATU.Web.Interface.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ICacheService _cacheService;
        private readonly IMembershipCreateStatusToErroMapper _membershipCreateStatusToErroMapper;
        private readonly IRegistrationService _registrationService;

        public AccountController(IAuthenticationService authenticationService, IMembershipCreateStatusToErroMapper membershipCreateStatusToErroMapper, ICacheService cacheService, IRegistrationService registrationService, IViewFactory viewFactory) : base(viewFactory)
        {
            _authenticationService = authenticationService;
            _cacheService = cacheService;
            _membershipCreateStatusToErroMapper = membershipCreateStatusToErroMapper;
            _registrationService = registrationService;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            var view = new LoginModel();
            ViewBag.ReturnUrl = returnUrl;
            return View(view);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && _authenticationService.Login(model.UserName, model.Password, model.RememberMe))
            {
                if (!string.IsNullOrEmpty(returnUrl))
                    return RedirectToLocal(returnUrl);

                var roles = Roles.GetRolesForUser(model.UserName);

                if (null == roles) // This is here to redirect role based
                {
                    return RedirectToAction("Index", "Home");
                }

                var roleList = roles.ToList();

                if (!roleList.Any())
                {
                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");

            return View(model);
        }

        public ActionResult LogOff()
        {
            _cacheService.ClearKey(CacheKeys.CurrentUser);
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            var view = new RegisterModel();

            return View(view);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    var userProfile = Mapper.Map<RegisterModel, UserProfile>(model);
                    var user = Mapper.Map<RegisterModel, User>(model);
                    user.UserName = userProfile.Email;
                    _registrationService.CreateUserAndLogin(user, userProfile, model.Password, RoleNames.Editor);

                    return RedirectToAction("Index", "Request");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", _membershipCreateStatusToErroMapper.ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}