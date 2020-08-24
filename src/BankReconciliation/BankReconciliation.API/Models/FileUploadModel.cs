using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BankReconciliation.API.Models
{
    public class FileUploadModel
    {
        [Required]
        [Display(Name = "Files")]
        public IFormFileCollection FormFiles { get; set; }
    }
}
