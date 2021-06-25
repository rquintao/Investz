using System.Collections.Generic;

namespace Investz.Data.Entities
{
    public class UserEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
