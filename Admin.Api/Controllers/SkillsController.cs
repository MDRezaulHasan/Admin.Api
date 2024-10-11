using Admin.Api.DB;
using Admin.Api.DTOs;
using Admin.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly AdminDbContext _adminDbContext;

        public SkillsController(AdminDbContext adminDbContext)
        {
            _adminDbContext = adminDbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllSkills()
        {
            var allSkills = _adminDbContext.Skills.ToList();

            if (!allSkills.Any()) return NotFound("No skills found!");
            return Ok(allSkills);

        }

        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSkillById(Guid id)
        {
            var singleSkill = _adminDbContext.Skills.Find(id);

            if (singleSkill is null)
            {
                return NotFound("No skill is found");
            }
            return Ok(singleSkill);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddSkill(SkillDto skillDto)
        {
            if(skillDto.Equals(null))return BadRequest("Request object is empty.");
            var skillModal = new Skill()
            {
                Name = skillDto.Name,
                Level = skillDto.Level,
                CreateAt = DateTimeOffset.UtcNow,

            };
            _adminDbContext.Skills.Add(skillModal);
            await _adminDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllSkills), skillModal);

        }

        [HttpPut]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateSkill(Guid id, UpdateSkillRequest updateSkillRequest)
        {
            if (updateSkillRequest is null) return NotFound("Nothing to update.");
            var findSkill = _adminDbContext.Skills.Find(id);
            if (findSkill is null) return NotFound("Skill not found");
            findSkill.Name = updateSkillRequest.Name==""?findSkill.Name:updateSkillRequest.Name;
            findSkill.Level = updateSkillRequest.Level;
            findSkill.CreateAt = DateTimeOffset.UtcNow;
            _adminDbContext.SaveChanges();
            return Ok(findSkill);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteSkill(Guid id)
        {
            var skill = _adminDbContext.Skills.Find(id);
            if (skill is null) return NotFound("Skill not found");
            _adminDbContext.Skills.Remove(skill);
            _adminDbContext.SaveChanges();
            return Ok("Successfully deleted!");


        }
    }
}
