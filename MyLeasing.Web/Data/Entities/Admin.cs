using System;
using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Data.Entities
{
    public class Admin
    {
        public int Id { get; set; }

        public int Document { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [MaxLength(9)]
        [Display(Name = "Fixed Phone")]
        public string FixedPhone { get; set; }

        [MaxLength(9)]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }

        public string Address { get; set; }

        [Display(Name = "Photo")]
        public Guid ImageId { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

        public User User { get; set; }

        [Display(Name = "Photo")]
        public string ImageFullPath => ImageId == Guid.Empty
       ? $"https://myleasingandre.blob.core.windows.net/noimage/noimage.png"
       : $"https://myleasingandre.blob.core.windows.net/lessees/{ImageId}";
    }
}
