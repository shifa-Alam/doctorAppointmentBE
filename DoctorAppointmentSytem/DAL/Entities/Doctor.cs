﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appoinments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Appointment> Appoinments { get; set; }
    }
}
