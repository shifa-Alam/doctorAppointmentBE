using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public class UserInputModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
