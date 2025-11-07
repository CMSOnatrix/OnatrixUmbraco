using Microsoft.AspNetCore.Mvc;
using OnatrixUmbraco.Services;
using OnatrixUmbraco.ViewModels;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace OnatrixUmbraco.Controllers;

public class CallbackFormController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, FormSubmissionsService formSubmissionsService) : SurfaceController(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
{
    private readonly FormSubmissionsService _formSubmissionsService = formSubmissionsService;


    public IActionResult HandleCallBackForm(CallbackFormViewModel model)
    {
       if(!ModelState.IsValid)
        {
          
            return CurrentUmbracoPage();
        }
    
       var result = _formSubmissionsService.SaveCallbackRequest(model);
        if(!result)
        {
            TempData["FormError"] = "There was an error submitting the request. Please try again later.";
            return RedirectToCurrentUmbracoPage();
        }

        TempData["FormSuccess"] = "Thank you for contacting us! Will get back to you within 2-4 days.";
        return RedirectToCurrentUmbracoPage();
    }
}
