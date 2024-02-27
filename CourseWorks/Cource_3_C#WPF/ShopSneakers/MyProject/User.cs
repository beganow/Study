using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class User
    {
        public int userId { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        private int role { get; set; }

        public User(int userId, string login, string password, string email, int role)
        {
            this.userId = userId;
            this.login = login;
            this.password = password;
            this.email = email;
            this.role = role;
        }
        public User()
        {
        }
    }
}
