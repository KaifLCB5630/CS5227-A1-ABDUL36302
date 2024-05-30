using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CS5227_A1_ABDUL36302.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "The First Name Is Required")]
        public string FirstName { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "The Last Name Is Required")]
        public string LastName { get; set; } = "";

        [BindProperty]
        [EmailAddress]
        [Required(ErrorMessage = "The Email Is Required")]
        public string Email { get; set; } = "";

        [BindProperty]
        public string? Phone { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "The Subject Is Required")]
        public string Subject { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "The Message Is Required")]
        public string Message { get; set; } = "";

        [BindProperty]
        public string Location { get; set; } = "";

        public string successMessage = "";
        public string errorMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                errorMessage = "Data Validation Failed";
                return;
            }

            successMessage = "Your Message Has Been Recieved Correctly";

            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Subject = "";
            Message = "";
            Location = "";

            ModelState.Clear();
        }
    }
}
