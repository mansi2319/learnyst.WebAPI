using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnyst.Application.DTOs
{
    public class BatchDto
    {
        public int id { get; set; }

        public string? title { get; set; }

        public decimal? price { get; set; }

        public int? course_id { get; set; }

        public DateOnly? start_date { get; set; }

        public DateOnly? end_date { get; set; }

        public int? instructor_id { get; set; }
    }

    public class BundleDto
    {
        public int id { get; set; }

        public string? title { get; set; }

        public string? description { get; set; }

        public decimal? price { get; set; }

        public string? course_ids { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }
    }
}
