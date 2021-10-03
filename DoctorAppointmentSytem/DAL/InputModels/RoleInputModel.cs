using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public  class RoleInputModel
    {
        public RoleInputModel()
        {
            Users = new List<UserInputModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public IList<UserInputModel> Users { get; set; }
    }
}
