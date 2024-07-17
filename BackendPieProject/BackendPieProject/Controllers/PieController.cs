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
    public class PieController : ControllerBase
    {
        private readonly IPieReopsitory _pieReopsitory;
        private readonly IMapper _mapper;
        
        public PieController(IPieReopsitory pieReopsitory,IMapper mapper)
        {
            _pieReopsitory = pieReopsitory;
            _mapper = mapper;

        }

        [HttpGet]
        public ActionResult<IEnumerable<PieReadDTO>> GetAll()
        {
            var pies = _pieReopsitory.GetAll();
            var readPies = _mapper.Map<IEnumerable<PieReadDTO>>(pies);
            return Ok(readPies);
        }

        [HttpGet("{Id}")]
        public ActionResult<PieReadDTO> FindOne(int Id)
        {
            var findPie = _pieReopsitory.FindOne(Id);
            if (findPie == null) return NotFound();
            var readpie = _mapper.Map<PieReadDTO>(findPie);
            return Ok(readpie);
        }


        [HttpPost]

        public ActionResult<PieReadDTO> CreateOne([FromBody] PieCreateDTO newPie )
        {
            var MapPie= _mapper.Map<Pie>(newPie);
            _pieReopsitory.CreateOne(MapPie);
            var ReadPie = _mapper.Map<PieReadDTO>(MapPie);
            return Ok(ReadPie);

        }

        [HttpGet("/api/PieOfTheWeek")]
        public ActionResult<PieReadDTO> PieOfTheWeek()
        {
            var ofTheWeek = _pieReopsitory.PiesOfTheWeek();
            var readOfTheWeek = _mapper.Map<IEnumerable<PieReadDTO>>(ofTheWeek);
            return Ok(readOfTheWeek);
        }

        [HttpGet("/api/PieWithCategory")]

        public ActionResult<PieReadDTO> PieWithCategory(string? category)
        {
            var piesWithCategory = _pieReopsitory.PieWithCategory(category);
            var readPiesWithCategory = _mapper.Map<IEnumerable<PieReadDTO>>(piesWithCategory);
            return Ok(readPiesWithCategory);

		}

        [HttpPatch("{id}")]
        public ActionResult<PieReadDTO> UpdateOne(int id,[FromBody]PieUpdateDTO updatePie)
        {
          var findPie = _pieReopsitory.FindOne(id);
            if (findPie == null) return NotFound();
            findPie.Name = updatePie.Name;
            findPie.CategoryId = updatePie.CategoryId;
            findPie.ShortDescription = updatePie.ShortDescription;
		    findPie.LongDescription=updatePie.LongDescription;
		    findPie.AllergyInformation=updatePie.AllergyInformation;
		    findPie.Price=updatePie.Price;
		    findPie.ImageUrl=updatePie.ImageUrl;
		    findPie.ImageThumbnailUrl=updatePie.ImageThumbnailUrl;
		    findPie.IsPieOfTheWeek=updatePie.IsPieOfTheWeek;
		    findPie.InStock=updatePie.InStock;
            var updated = _pieReopsitory.UpdateOne(findPie);
            return Accepted(updated);
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteOne(int id)
        {
            var findPie = _pieReopsitory.FindOne(id);
            if (findPie == null) return NotFound();
            var deletePie = _pieReopsitory.DeleteOne(id);
            return Ok();
        }

	}
}
