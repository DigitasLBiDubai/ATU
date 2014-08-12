﻿using System.Web.Mvc;
using ATU.Web.Domain.Abstract;

namespace ATU.Web.Interface.Controllers
{
    public class ControllerBase : Controller
    {
        protected readonly IViewFactory _viewFactory;

        public ControllerBase(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
        }
    }
}