using System;
using System.ComponentModel.DataAnnotations;

namespace EducationSystem.Web.Models
{
    public class StudentViewModel
    {
        /// Vendég neve.
        /// </summary>
        [Required(ErrorMessage = "A név megadása kötelező.")] // feltételek a validáláshoz
        [StringLength(60, ErrorMessage = "A foglaló neve maximum 60 karakter lehet.")]
        public String UserName { get; set; }

    }
}
