using Microsoft.AspNetCore.Authorization;

namespace User.Management.API.Models
{
    public class AgeRequirement : IAuthorizationRequirement
    {
        public AgeRequirement(int age) {
            Age = age;
        }
        public int Age { get; set; }
    }
}
