using System;
using System.Linq;
using AutoMapper;
using ATU.Domain.Abstract;
using ATU.Domain.Data.Repository.Abstract;
using ATU.Domain.Model;
using WebMatrix.WebData;

namespace ATU.Domain.Concrete
{
    public class RequestService : BaseService, IRequestService
    {
        private readonly IPasswordGenerator _passwordGenerator;
        private readonly IRegistrationService _registrationService;

        public RequestService(IRepository repo, IPasswordGenerator passwordGenerator, IRegistrationService registrationService) : base(repo)
        {
            _passwordGenerator = passwordGenerator;
            _registrationService = registrationService;
        }

        public Request GetRequest(int id)
        {
            var pages = Repo.Find<Request>(x => x.Id == id);
            if (null != pages && pages.Any())
                return pages.Single();

            return null;
        }

        public IQueryable<Request> GetRequests()
        {
            return Repo.GetAll<Request>();
        }

        public Request CreateRequest(Request request, RequestTypes requestType)
        {
            request.CreatedUtc = DateTime.UtcNow;
            request.LastModifiedUtc = DateTime.UtcNow;
            request.Status = (int)RequestStatus.New;
            request.RequestType = (int)requestType;
            Repo.Add<Request>(request);
            Repo.SaveChanges();

            return request;
        }

        public void UpdateRequest(Request request)
        {
            request.LastModifiedUtc = DateTime.UtcNow;
            Repo.SaveChanges();
        }

        public void AcceptRequest(int id)
        {
            var request = GetRequest(id);

            switch (request.RequestType)
            {
                case 0:
                    CreateNewEditorAccount(request);
                    break;
                case 1:
                    CreateNewEditorAccountAndAssociateVenueClaimed(request);
                    break;
            }

            request.Status = (int)RequestStatus.Accepted;
            UpdateRequest(request);
        }

        public void RejectRequest(int id)
        {
            var request = GetRequest(id);
            request.Status = (int)RequestStatus.Rejected;
            UpdateRequest(request);
        }

        public void ResetToNew(int id)
        {
            var request = GetRequest(id);
            request.Status = (int)RequestStatus.New;
            UpdateRequest(request);
        }

        private void CreateNewEditorAccount(Request request)
        {
            if (WebSecurity.UserExists(request.Email))
                throw new Exception("Username taken");

            var user = Mapper.Map<Request, User>(request);
            var userProfile = Mapper.Map<Request, UserProfile>(request);
            user.UserName = userProfile.Email;
            userProfile.Status = 0;
            _registrationService.CreateUser(user, userProfile, _passwordGenerator.GeneratePassword(), RoleNames.Editor);
        }

        private void CreateNewEditorAccountAndAssociateVenueClaimed(Request request)
        {
            CreateNewEditorAccount(request);

            // ...
        }
    }
}