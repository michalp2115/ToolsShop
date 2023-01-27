using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tools.DataAccess;
using Tools.DataAccess.Repository.IRepository;
using Tools.Models;

namespace ToolsWeb.Areas.Admin.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public CategoryApiController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll();
            return Ok(objCategoryList);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _context.Categories.FirstOrDefault(c => c.Id == id);

            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult Post(Category obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _unitOfWork.Category.Add(obj);
            _unitOfWork.Save();
            return Created($"api/category/{obj.Id}", obj);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(Category obj, int id)
        {
            var item = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _unitOfWork.Category.Update(obj);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
