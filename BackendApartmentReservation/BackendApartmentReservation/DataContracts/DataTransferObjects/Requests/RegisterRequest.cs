﻿namespace BackendApartmentReservation.DataContracts.DataTransferObjects.Requests
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Office { get; set; }
    }
}