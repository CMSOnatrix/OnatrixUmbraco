using System.ComponentModel.DataAnnotations;

namespace OnatrixUmbraco.ViewModels;

public class QuestionFormViewModel
{
    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Name")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email address")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Please enter your question")]
    [Display(Name = "Message")]
    public string Message { get; set; } = null!;
}
