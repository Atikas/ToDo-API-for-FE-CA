using Microsoft.AspNetCore.Identity;

namespace ToDo.Api.DTOs
{
    public class UserResponse : RegisterUserRequest
    {
        public string? Id { get; set; }

        public UserResponse()
        {
        }

        public UserResponse(IdentityUser identity): base(identity)
        {
            Id = identity.Id;
        }
    }
}
