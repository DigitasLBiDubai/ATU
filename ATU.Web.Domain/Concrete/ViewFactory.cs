using System.Linq;
using ATU.Domain.Model;
using ATU.Web.Domain.Abstract;
using System.Collections.Generic;
using ATU.Web.Domain.Model.Answer;
using ATU.Web.Domain.Model.Question;
using ATU.Web.Domain.Model.Request;

namespace ATU.Web.Domain.Concrete
{
    public class ViewFactory : IViewFactory
    {
        private readonly IBreadcrumbFactory _breadcrumbFactory;
        private readonly ILeftNavFactory _leftNavFactory;
        private readonly ITopNavFactory _topNavFactory;
        private readonly ITableFactory _tableFactory;

        public ViewFactory(IBreadcrumbFactory breadcrumbFactory, ILeftNavFactory leftNavFactory, ITopNavFactory topNavFactory, ITableFactory tableFactory)
        {
            _breadcrumbFactory = breadcrumbFactory;
            _leftNavFactory = leftNavFactory;
            _topNavFactory = topNavFactory;
            _tableFactory = tableFactory;
        }

        // Request
        public RequestIndex BuildRequestIndexViewModel(string username, string[] userRoles, string title, IEnumerable<Request> requests, List<int> itemsPerPage)
        {
            var contactRequests = requests.Where(c => c.RequestType == 2);
            var allOtherRequests = requests.Where(c => c.RequestType != 2); 

            var viewModel = new RequestIndex
            {
                Title = title,
                SubTitle = GeneralConstants.PortalTitle,
                PortalTitle = GeneralConstants.PortalTitle,
                Icon = "Icon",
                Breadcrumb = _breadcrumbFactory.BuildBreadcrumb(),
                LeftNav = _leftNavFactory.BuildLeftNav(LeftNavigationItems.Requests, userRoles),
                TopNav = _topNavFactory.BuildTopNav(GeneralConstants.PortalTitle, username),
                ContactRequestTable = contactRequests != null && contactRequests.Any() ? _tableFactory.BuildRequestsTable(contactRequests, itemsPerPage, string.Concat("Contact ", title), 0) : null,
                NewRequestTable = allOtherRequests != null && allOtherRequests.Any() ? _tableFactory.BuildRequestsTable(allOtherRequests, itemsPerPage, string.Concat("New ", title), 0) : null,
                RejectedRequestTable = allOtherRequests != null && allOtherRequests.Any() ? _tableFactory.BuildRequestsTable(allOtherRequests, itemsPerPage, string.Concat("Rejected ", title), -1) : null,
                AcceptedRequestTable = allOtherRequests != null && allOtherRequests.Any() ? _tableFactory.BuildRequestsTable(allOtherRequests, itemsPerPage, string.Concat("Accepted ", title), 3) : null
            };

            return viewModel;
        }

        public RequestDetail BuildRequestDetailViewModel(string username, string[] userRoles, string title, RequestFields requestFields)
        {
            var viewModel = new RequestDetail
            {
                Title = title,
                SubTitle = GeneralConstants.PortalTitle,
                PortalTitle = GeneralConstants.PortalTitle,
                Icon = "Icon",
                Breadcrumb = _breadcrumbFactory.BuildBreadcrumb(),
                LeftNav = _leftNavFactory.BuildLeftNav(LeftNavigationItems.Requests, userRoles),
                TopNav = _topNavFactory.BuildTopNav(GeneralConstants.PortalTitle, username),
                RequestFields = requestFields
            };

            return viewModel;
        }

        // Question
        public QuestionIndex BuildQuestionIndexViewModel(string username, string[] userRoles, string title, IEnumerable<Question> questions, List<int> itemsPerPage)
        {
            var viewModel = new QuestionIndex
            {
                Title = title,
                SubTitle = GeneralConstants.PortalTitle,
                PortalTitle = GeneralConstants.PortalTitle,
                Icon = "Icon",
                Breadcrumb = _breadcrumbFactory.BuildBreadcrumb(),
                LeftNav = _leftNavFactory.BuildLeftNav(LeftNavigationItems.Requests, userRoles),
                TopNav = _topNavFactory.BuildTopNav(GeneralConstants.PortalTitle, username),
                QuestionTable = questions != null && questions.Any() ? _tableFactory.BuildQuestionsTable(questions, itemsPerPage, string.Concat("Question ", title)) : null,
            };

            return viewModel;
        }

        public QuestionDetail BuildQuestionDetailViewModel(string username, string[] userRoles, string title, QuestionFields questionFields, List<AnswerFields> answerFieldsList, string poster)
        {
            var viewModel = new QuestionDetail
            {
                Title = title,
                SubTitle = GeneralConstants.PortalTitle,
                PortalTitle = GeneralConstants.PortalTitle,
                Icon = "Icon",
                Breadcrumb = _breadcrumbFactory.BuildBreadcrumb(),
                LeftNav = _leftNavFactory.BuildLeftNav(LeftNavigationItems.Questions, userRoles),
                TopNav = _topNavFactory.BuildTopNav(GeneralConstants.PortalTitle, username),
                QuestionFields = questionFields,
                Answers = answerFieldsList,
                Poster = poster
               
            };

            return viewModel;
        }

        public CreateAnswer BuildCreateAnswerViewModel(string username, string[] userRoles, string title)
        {
            var viewModel = new CreateAnswer
            {
                Title = title,
                SubTitle = GeneralConstants.PortalTitle,
                PortalTitle = GeneralConstants.PortalTitle,
                Icon = "Icon",
                Breadcrumb = _breadcrumbFactory.BuildBreadcrumb(),
                LeftNav = _leftNavFactory.BuildLeftNav(LeftNavigationItems.Questions, userRoles),
                TopNav = _topNavFactory.BuildTopNav(GeneralConstants.PortalTitle, username),
                AnswerFields = new AnswerFields()
            };

            return viewModel;
        }

        public CreateAnswer BuildCreateAnswerViewModel(string username, string[] userRoles, string title, AnswerFields answerFields)
        {
            var viewModel = new CreateAnswer
            {
                Title = title,
                SubTitle = GeneralConstants.PortalTitle,
                PortalTitle = GeneralConstants.PortalTitle,
                Icon = "Icon",
                Breadcrumb = _breadcrumbFactory.BuildBreadcrumb(),
                LeftNav = _leftNavFactory.BuildLeftNav(LeftNavigationItems.Questions, userRoles),
                TopNav = _topNavFactory.BuildTopNav(GeneralConstants.PortalTitle, username),
                AnswerFields = answerFields
            };

            return viewModel;
        }
    }
}