using Microsoft.AspNetCore.Identity;

namespace ExamSim4.Models
{
    public class Appuser : IdentityUser
    {
        public string UserName {  get; set; }
    }
}
