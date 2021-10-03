﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class DoctorInputModel
    {
        public DoctorInputModel()
        {
            Appoinments = new List<AppointmentInputModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public IList<AppointmentInputModel> Appoinments { get; set; }
    }
}
