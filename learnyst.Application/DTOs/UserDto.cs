using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnyst.Application.DTOs
{
    public class UserDto
    {
        public int id { get; set; }

        public string? name { get; set; }

        public string? email { get; set; }

        public string? role { get; set; }

        public DateTime? created_at { get; set; }
    }
}
