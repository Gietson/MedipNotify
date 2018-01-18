using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedipNotify
{
    public class Result
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalNumberOfRecords { get; set; }
        public Appointment[] Appointments { get; set; }
        public object[] Errors { get; set; }

        public class Appointment
        {
            public object Id { get; set; }
            public object Patient { get; set; }
            public DateTime DateTime { get; set; }
            public string Duration { get; set; }
            public Region Region { get; set; }
            public Doctor Doctor { get; set; }
            public Specialty Specialty { get; set; }
            public Clinic Clinic { get; set; }
            public Appointmenttype AppointmentType { get; set; }
            public object LastError { get; set; }
            public object Expires { get; set; }
            public int VendorType { get; set; }
            public Attribute[] Attributes { get; set; }
            public int State { get; set; }
        }

        public class Region
        {
            public int DictionaryType { get; set; }
            public string Code { get; set; }
            public object Description { get; set; }
        }

        public class Doctor
        {
            public int DictionaryType { get; set; }
            public string Code { get; set; }
            public string Description { get; set; }
        }

        public class Specialty
        {
            public int DictionaryType { get; set; }
            public string Code { get; set; }
            public object Description { get; set; }
        }

        public class Clinic
        {
            public int DictionaryType { get; set; }
            public string Code { get; set; }
            public string Description { get; set; }
        }

        public class Appointmenttype
        {
            public int DictionaryType { get; set; }
            public string Code { get; set; }
            public object Description { get; set; }
        }

        public class Attribute
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

    }
}
