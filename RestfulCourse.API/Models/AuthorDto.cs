using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulCourse.API.Models
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string MainCategory { get; set; }
    }
}
