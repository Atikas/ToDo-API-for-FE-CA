using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Api.DTOs
{
    public class RegisterUserRequest
    {
        /// <summary>
        /// User name of user. Must be unique.
        /// </summary>
        [Required]
        public string UserName { get; set; }


        /// <summary>
        /// Password of user. No password policy is implemented. You can use any password.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Email of user. Must be unique.
        /// </summary>
        [Required, EmailAddress]
        public string Email { get; set; }

        public RegisterUserRequest()
        {

        }

        public RegisterUserRequest(IdentityUser identity)
        { 
            UserName = identity.UserName;
            Email = identity.Email;
        }
    }
}
