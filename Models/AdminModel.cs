using System.Collections.Generic;

namespace Dershane.Models
{
    public class AdminModel
    {
        public Dictionary<string, IEnumerable<object>>? Tables { get; set; } = new Dictionary<string, IEnumerable<object>>();
    }
        public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}