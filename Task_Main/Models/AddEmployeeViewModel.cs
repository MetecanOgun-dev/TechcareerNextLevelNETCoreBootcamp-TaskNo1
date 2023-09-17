using System.ComponentModel.DataAnnotations;

namespace Task_Main.Models
{
    public class AddEmployeeViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10, ErrorMessage = "Maximum {1} characters allowed")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(20, ErrorMessage = "Maximum {1} characters allowed")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(30, ErrorMessage = "Maximum {1} characters allowed")]
        public string Title { get; set; }
    }
}
