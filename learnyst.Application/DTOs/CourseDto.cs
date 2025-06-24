using learnyst.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnyst.Application.DTOs
{
    public class CourseDto
    {
        public int id { get; set; }

        public string? title { get; set; }

        public string? description { get; set; }

        public decimal? price { get; set; }

        public int? access_duration { get; set; }

        public string? visibility { get; set; }

        public string? status { get; set; }

        public int? instructor_id { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }
    }

    public class SectionDto
    {
        public int id { get; set; }

        public int? course_id { get; set; }

        public string? title { get; set; }

        public int? position { get; set; }
    }

    public class LessonDto
    {
        public int id { get; set; }

        public int? section_id { get; set; }

        public string? type { get; set; }

        public string? title { get; set; }

        public string? content_url { get; set; }

        public int? duration { get; set; }
    }

    public class LiveclassDto
    {
        public int id { get; set; }

        public string? title { get; set; }

        public int? course_id { get; set; }

        public int? section_id { get; set; }

        public int? lessons_id { get; set; }

        public int? instructor_id { get; set; }

        public DateTime? start_time { get; set; }

        public DateTime? end_time { get; set; }

        public string? meeting_url { get; set; }

        public string? recording_url { get; set; }
    }
}
