using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnyst.Application.DTOs
{
    public class UserDto
    {
        public int? id { get; set; }

        public string? name { get; set; }

        public string? email { get; set; }

        public string? mobile_number { get; set; }

        public required string password { get; set; }

        public string? role { get; set; }

        public DateOnly? date_of_birth { get; set; }

        public string? profile_image_url { get; set; }

        public DateTime? signup_date { get; set; }

        public DateTime? updated_at { get; set; }
    }   

    public class SessionDto
    {
        public int id { get; set; }

        public int? user_id { get; set; }

        public string? device_info { get; set; }

        public string? ip_address { get; set; }

        public string? token { get; set; }

        public DateTime? login_at { get; set; }

        public DateTime? logout_at { get; set; }
    }
}
