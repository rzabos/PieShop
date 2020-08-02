using System;
using System.ComponentModel.DataAnnotations;

namespace BethanysPieShopHRM.Shared
{
    public class Employee
    {
        public DateTime BirthDate { get; set; }

        public string City { get; set; }

        [StringLength(1000, ErrorMessage = "Comment length can't exceed 1000 characters.")]
        public string Comment { get; set; }

        public Country Country { get; set; }

        public int CountryId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int EmployeeId { get; set; }

        public DateTime? ExitDate { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name is too long.")]
        public string FirstName { get; set; }

        public Gender Gender { get; set; }

        public JobCategory JobCategory { get; set; }

        public int JobCategoryId { get; set; }

        public DateTime? JoinedDate { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name is too long.")]
        public string LastName { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public string PhoneNumber { get; set; }

        public bool Smoker { get; set; }

        public string Street { get; set; }

        public string Zip { get; set; }
    }
}