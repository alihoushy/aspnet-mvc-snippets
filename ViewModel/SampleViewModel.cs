using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class SampleViewModel
    {
        [Key]
        [Display(Name = "User Id")]
        [Range(1, 1000000, ErrorMessage = "User Id should be between 1 and 1000000")]
        public int UserId { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "User Name should be between 3 and 50 characters")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address format")]
        [Required(ErrorMessage = "Email address is required")]
        [Display(Name = "Email Address")]
        [UniqueEmail(ErrorMessage = "Email address must be unique")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter your password")]
        [MinLength(8, ErrorMessage = "Please enter at least 8 characters")]
        [MaxLength(500)]
        [Display(Name = "User Password")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Invalid password format")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        [Required(ErrorMessage = "Confirm Password is required")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Created DateTime is required")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Created DateTime")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Updated DateTime is required")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Updated DateTime")]
        public DateTime UpdatedAt { get; set; }

        [Url(ErrorMessage = "Invalid URL format")]
        [Display(Name = "Website")]
        public string Website { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format")]
        [Display(Name = "Phone Number")]
        [UniquePhoneNumber(ErrorMessage = "Phone number must be unique")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only alphabets are allowed")]
        [Display(Name = "Alphabetic Field")]
        public string AlphabeticField { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Text Field")]
        public string TextField { get; set; }

        [Display(Name = "JSON Field")]
        [DataType(DataType.MultilineText)]
        public string JsonField { get; set; }

        [Display(Name = "Soft Delete")]
        public bool IsSoftDeleted { get; set; }

        [Display(Name = "Enum Field")]
        public SampleEnum EnumField { get; set; }

        [Display(Name = "IP Address")]
        [RegularExpression(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$", ErrorMessage = "Invalid IP address format")]
        public string IpAddress { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true; // Default value for boolean field
    }

    public enum SampleEnum
    {
        Option1,
        Option2,
        Option3
    }

    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Add your logic to check uniqueness of Email
            // For example, query the database to see if the email already exists
            // If it exists, return ValidationResult with error message

            return ValidationResult.Success;
        }
    }

    public class UniquePhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Add your logic to check uniqueness of PhoneNumber
            // For example, query the database to see if the phone number already exists
            // If it exists, return ValidationResult with error message

            return ValidationResult.Success;
        }
    }
}
