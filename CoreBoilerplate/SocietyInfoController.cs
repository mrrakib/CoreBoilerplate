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
    public class SocietyInfoController : Controller
    {
        #region private properties
        private readonly ISocietyInfoService _societyInfoService;
        #endregion

        #region constructor
        public SocietyInfoController(ISocietyInfoService societyInfoService)
        {
            _societyInfoService = societyInfoService;
        }
        #endregion

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var societyInfos = _societyInfoService.FindAllBySQL();
                return Ok(societyInfos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetById")]
        public IActionResult Get(int id)
        {
            try
            {
                var societyInfo = _societyInfoService.FindById(id);
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
        public IActionResult Post([FromBody]SocietyInfo model)
        {
            if (model == null)
                return BadRequest("Society info not found.");

            if (!ModelState.IsValid)
                return BadRequest("Not a valid object!");

            try
            {
                _societyInfoService.Create(model);
                return CreatedAtRoute("GetById", new { id = model.Id}, model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]SocietyInfo model)
        {
            try
            {
                if (model == null)
                    return BadRequest("No data found!");

                if (!ModelState.IsValid)
                    return BadRequest("Not a valid request!");

                _societyInfoService.Update(model);
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
                var society = _societyInfoService.FindById(id);
                if (society == null)
                    return NotFound($"Society with id: {id}, hasn't been found in db.");

                _societyInfoService.Delete(society);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
