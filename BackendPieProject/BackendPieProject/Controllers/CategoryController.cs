using AutoMapper;
using BackendPieProject.Dtos;
using BackendPieProject.Models;
using BackendPieProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendPieProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryReadDTO>> GetAll()
        {
            var categories = _categoryRepository.GetAll();
            var readCategories = _mapper.Map<IEnumerable<CategoryReadDTO>>(categories);
            return Ok(readCategories);
        }

        [HttpGet("{Id}")]
        public ActionResult<CategoryReadDTO> FindOne(int Id)
        {
            var findCategory= _categoryRepository.FindOne(Id);
            var readCategory = _mapper.Map<CategoryReadDTO>(findCategory);
            if (readCategory == null) return NotFound();
            return Ok(readCategory);
        }

        [HttpPost]
        public ActionResult CreateOne([FromBody] CategoryCreateDTO newCategory)
        {
            if (newCategory == null) return BadRequest();
            var mapCategory = _mapper.Map<Category>(newCategory);
            _categoryRepository.CreateOne(mapCategory);
            var readCategory = _mapper.Map<CategoryReadDTO>(mapCategory);
            return CreatedAtAction(nameof(CreateOne), readCategory);
        }

        [HttpPatch("{Id}")]
        public ActionResult<CategoryReadDTO> UpdateOne(int Id,[FromBody] CategoryUpdateDTO UpdatedCategory)
        {
            var findcategory = _categoryRepository.FindOne(Id);
                if(findcategory == null) return NotFound();
            findcategory.CategoryName = UpdatedCategory.CategoryName;
            findcategory.Description = UpdatedCategory.Description;
            _categoryRepository.UpdateOne(findcategory);
            var readCategory = _mapper.Map<CategoryReadDTO>(findcategory);
            return Accepted(readCategory);

        }

        [HttpDelete("{Id}")]
        public ActionResult DeleteOne(int Id)
        {
            var findCategory = _categoryRepository.FindOne(Id);
            if(findCategory == null) return NotFound();
            var deleteCategory = _categoryRepository.DeleteOne(Id);
            return Ok();
        }
 
    }
}
