using System;
using Microsoft.AspNetCore.Mvc;
using RestfulCourse.API.Services;

namespace RestfulCourse.API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : Controller
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
        {
            _courseLibraryRepository = courseLibraryRepository;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthors();
            return Ok(authorsFromRepo);
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthor(authorId);
            
            if (authorsFromRepo == null)
            {
                return NotFound();
            }   
            
            return Ok(authorsFromRepo);
        }
    }
}
