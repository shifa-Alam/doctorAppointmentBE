using System;
using System.Collections.Generic;

#nullable disable

namespace RND.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appoinments = new HashSet<Appoinment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Appoinment> Appoinments { get; set; }
    }
}
