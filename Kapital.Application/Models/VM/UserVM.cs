using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapital.Application.Models.VM
{
    public class UserVM
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string full_name { get; set; }
        public string job_title { get; set; }
        public string job_type { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string image { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public int onboarding_completion { get; set; }
    }
}
