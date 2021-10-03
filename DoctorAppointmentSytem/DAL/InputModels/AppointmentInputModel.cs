using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public  class AppointmentInputModel
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int PatientId { get; set; }
        public string Issue { get; set; }
        public int DoctorId { get; set; }

    }
}
