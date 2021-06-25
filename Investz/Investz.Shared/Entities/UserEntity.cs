using Investz.Shared.Entities;

namespace Investz.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        //public List<string> Roles { get; set; }
    }
}