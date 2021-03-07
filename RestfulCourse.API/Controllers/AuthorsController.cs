using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestfulCourse.API.Helpers;
using RestfulCourse.API.Models;
using RestfulCourse.API.ResourceParameters;
using RestfulCourse.API.Services;

namespace RestfulCourse.API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : Controller
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;
        public AuthorsController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors([FromQuery] AuthorsResourceParameters authorsResourceParameters)
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthors(authorsResourceParameters);
            
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthor(authorId);
            
            if (authorsFromRepo == null)
            {
                return NotFound();
            }   
            
            return Ok(_mapper.Map<AuthorDto>(authorsFromRepo));
        }
    }
}
