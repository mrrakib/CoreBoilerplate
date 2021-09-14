using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service;


namespace SM.API
{
    [Route("api/[controller]")]
    public class SocietyMemberController : Controller
    {
        #region private properties
        private readonly ISocietyMemberService _societyMemberService;
        #endregion

        #region constructor
        public SocietyMemberController(ISocietyMemberService societyMemberService)
        {
            _societyMemberService = societyMemberService;
        }
        #endregion

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var societyInfos = _societyMemberService.FindAllBySQL();
                return Ok(societyInfos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetMemberById")]
        public IActionResult Get(int id)
        {
            try
            {
                var societyInfo = _societyMemberService.FindById(id);
                if (societyInfo == null)
                    return NotFound();
                return Ok(societyInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]SocietyMember model)
        {
            if (model == null)
                return BadRequest("Society info not found.");

            if (!ModelState.IsValid)
                return BadRequest("Not a valid object!");

            try
            {
                _societyMemberService.Create(model);
                return CreatedAtRoute("GetMemberById", new { id = model.Id}, model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]SocietyMember model)
        {
            try
            {
                if (model == null)
                    return BadRequest("No data found!");

                if (!ModelState.IsValid)
                    return BadRequest("Not a valid request!");

                _societyMemberService.Update(model);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var society = _societyMemberService.FindById(id);
                if (society == null)
                    return NotFound($"Member with id: {id}, hasn't been found in db.");

                _societyMemberService.Delete(society);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
