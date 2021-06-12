using Meetup.Models;
using Meetup.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Controllers
{
    [Route("api/participant")]
    public class ParticipantControler : ControllerBase
    {
        private readonly IParticipantService _participantService;

        public ParticipantControler(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody]UpdateParticipantDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _participantService.Update(id, dto);

            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _participantService.Delete(id);

            if (isDeleted)
                return NoContent();

            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateParticipant([FromBody]CreateParticipantDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //User validation for meeting
            var meetId = dto.MeetId;
            int meetCount = _participantService.GetAll().Where(x => x.MeetId == meetId).Count();

            if(meetCount>=25) 
            {
                return BadRequest("Too many users for this meet");
            }
            //////

            var id = _participantService.Create(dto);

            return Created($"/api/participant/{id}", null); //Code status 201
        }

        [HttpGet]
        public ActionResult<IEnumerable<ParticipantDto>> GetAll()
        {
            var participantsDtos = _participantService.GetAll();

            return Ok(participantsDtos); //Ok is status 200
        }

        [HttpGet("{id}")]
        public ActionResult<ParticipantDto> Get([FromRoute] int id)
        {
            var user = _participantService.GetById(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
