using Microsoft.AspNetCore.Mvc;
using OnatrixUmbraco.ViewModels;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace OnatrixUmbraco.Controllers;

public class FormController : SurfaceController
{
    public FormController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
    {
    }

    public IActionResult HandleCallBackForm(CallbackFormViewModel model)
    {
       if(!ModelState.IsValid)
        {
            // If the model is not valid, return the current page with validation errors
            return CurrentUmbracoPage();
        }
        // Process the form data (e.g., save to database, send email, etc.)
        // Redirect to a thank you page or display a success message
        return RedirectToCurrentUmbracoPage();
    }
}
