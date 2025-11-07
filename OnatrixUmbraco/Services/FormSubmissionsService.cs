using OnatrixUmbraco.ViewModels;
using Umbraco.Cms.Core.Services;

namespace OnatrixUmbraco.Services;

public class FormSubmissionsService(IContentService contentService)
{
    private readonly IContentService _contentService = contentService;

    public bool SaveCallbackRequest(CallbackFormViewModel model)
    {

         try

         {
            var container = _contentService.GetRootContent().FirstOrDefault(c => c.ContentType.Alias == "formSubmissions");
            if (container == null)
            {
                return false;
            }

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {model.Name}";
            var request = _contentService.Create(requestName, container, "callbackRequest");

            request.SetValue("callbackRequestName", model.Name);
            request.SetValue("callbackRequestEmail", model.Email);
            request.SetValue("callbackRequestPhone", model.Phone);
            request.SetValue("callbackRequestOption", model.SelectedOption);

            var saveResult = _contentService.Save(request);
            return saveResult.Success;
         }
         catch (Exception)
         {

            return false;
         }
    }

    public bool SaveQuestionRequest(QuestionFormViewModel model)
    {
        try
        {
            var container = _contentService.GetRootContent()
                .FirstOrDefault(c => c.ContentType.Alias == "questionSubmissons");

            if (container == null)
                return false;

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {model.Name}";
            var request = _contentService.Create(requestName, container, "questionRequest");

            request.SetValue("questionRequestName", model.Name);
            request.SetValue("questionRequestEmail", model.Email);
            request.SetValue("questionRequestMessage", model.Message);

            var saveResult = _contentService.Save(request);
            return saveResult.Success;
        }
        catch (Exception)
        {
            return false;
        }
    }

}
