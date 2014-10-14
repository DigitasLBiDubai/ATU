using AutoMapper;
using ATU.Domain;
using ATU.Domain.Abstract;
using ATU.Domain.Model;
using ATU.Web.Domain.Abstract;
using ATU.Web.Domain.Model.Request;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace ATU.Web.Interface.Controllers
{
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IViewFactory viewFactory, IRequestService requestService) : base(viewFactory)
        {
            _requestService = requestService;
        }

        [Authorize(Roles = RoleContexts.AdministratorAndSuperUser)]
        public ActionResult Index()
        {
            var requests = _requestService.GetRequests().ToList();
            var viewModel = _viewFactory.BuildRequestIndexViewModel(CurrentUserName, Roles.GetRolesForUser(), "Requests", requests, new List<int>() { 10, 20, 50 });

            return View(viewModel);
        }

        public ActionResult Detail(int id)
        {
            var request = _requestService.GetRequest(id);
            var requestFields = Mapper.Map<Request, RequestFields>(request);

            var viewModel = _viewFactory.BuildRequestDetailViewModel(CurrentUserName, Roles.GetRolesForUser(), "Request Detail", requestFields);

            return View(viewModel);
        }

        public ActionResult EditorAccount()
        {
            return View(new CreateRequest() { RequestFields = new RequestFields() });
        }
       
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult EditorAccount(RequestFields model)
        {
            if (ModelState.IsValid)
            {
                var request = Mapper.Map<RequestFields, Request>(model);
                _requestService.CreateRequest(request, RequestTypes.EditorAccount);

                return RedirectToAction("Thanks", "Request");
            }

            // If we got this far, something failed, redisplay form
            return View(new CreateRequest { RequestFields = model });
        }

        public ActionResult ClaimVenue()
        {
            return View(new CreateRequest() { RequestFields = new RequestFields() });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ClaimVenue(RequestFields model)
        {
            if (ModelState.IsValid)
            {
                var request = Mapper.Map<RequestFields, Request>(model);
                _requestService.CreateRequest(request, RequestTypes.VenueClaim);

                return RedirectToAction("Thanks", "Request");
            }

            // If we got this far, something failed, redisplay form
            return View(new CreateRequest { RequestFields = model });
        }

        public ActionResult Thanks()
        {
            return View();
        }

        [Authorize(Roles = RoleContexts.AdministratorAndSuperUser)]
        public ActionResult Reject(int id)
        {
            _requestService.RejectRequest(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = RoleContexts.AdministratorAndSuperUser)]
        public ActionResult Accept(int id)
        {
            _requestService.AcceptRequest(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = RoleContexts.AdministratorAndSuperUser)]
        public ActionResult ResetToNew(int id)
        {
            _requestService.ResetToNew(id);
            return RedirectToAction("Index");
        }
    }
}
