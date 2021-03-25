using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancePagination.Demo.Data;
using AdvancePagination.Demo.Filters;
using AdvancePagination.Demo.Helpers;
using AdvancePagination.Demo.Models;
using AdvancePagination.Demo.Services;
using AdvancePagination.Demo.Validation;
using AdvancePagination.Demo.Wrapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdvancePagination.Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly AppDbContext context;

         private readonly IUriService uriService;

        public PostController(AppDbContext context, IUriService uriService)
        {
            this.context = context;
            this.uriService = uriService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await context.Posts.Where(a => a.Id == id).FirstOrDefaultAsync();
            return Ok(new Response<Post>(post));
        }
        [HttpGet]
        //No pagination
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await context.Posts.ToListAsync();
            return Ok(response);
        }
        //Pagination
        [HttpGet]
        //Pn = 10 , ps =10
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            // var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            // var response = await context.Posts.ToListAsync();
            // return Ok(response);
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await context.Posts.OrderBy(x=>x.Id)
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();
            var totalRecords = await context.Posts.CountAsync();
             var pagedReponse = PaginationHelper.CreatePagedReponse<Post>(pagedData, validFilter, totalRecords, uriService, route);
               return Ok(pagedReponse);
        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
             context.Posts.Add(post); 
             context.SaveChanges();
             return Json(new {message = "new Post Added", post = post});  
        }
        [Route("AddNew")]
        [HttpPost]
        [System.Obsolete]
        public IActionResult AddWithCustomeValidationResponse()
        {
            PostValidator validator = new PostValidator();
            List<string> ValidationMessages = new List<string>();
            var tester = new Post
            {
                Title = "Ok",
                Description = "",
                CreatedBy = "1",
            };
            var validationResult = validator.Validate(tester);
            var response = new ResponseModel();
            if (!validationResult.IsValid)
            {
                response.IsValid = false;
                foreach (ValidationFailure failure in validationResult.Errors)
                {
                    ValidationMessages.Add(failure.ErrorMessage);
                }
                response.ValidationMessages = ValidationMessages;
            }
            return Ok(response);
        }

    }
}