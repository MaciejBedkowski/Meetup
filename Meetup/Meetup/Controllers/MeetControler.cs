using Meetup.Models;
using Meetup.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Meetup.Controllers
{
    [Route("api/meet")]
    public class MeetControler : ControllerBase
    {
        private readonly IMeetService _meetService;
        private readonly IParticipantService _participantService;
        public MeetControler(IMeetService meetService, IParticipantService participantService)
        {
            _meetService = meetService;
            _participantService = participantService;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody]UpdateMeetDto dto, [FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _meetService.Update(id, dto);

            if(!isUpdated)
            {
                return NotFound();
            }

            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _meetService.Delete(id);

            if (isDeleted)
                return NoContent();

            return NotFound();
        }

        [HttpPost] 
        public ActionResult CreateMeet([FromBody]CreateMeetDto dto) 
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _meetService.Create(dto);

            return Created($"/api/meet/{id}", null); //Code status 201
        }

        [HttpGet]
        public ActionResult<IEnumerable<MeetDto>> GetAll()
        {
            var meetsDtos = _meetService.GetAll();

            return Ok(meetsDtos); //Ok is status 200
        }

        [HttpGet("{id}")]
        public ActionResult<MeetDto> Get([FromRoute] int id)
        {
            var meet = _meetService.GetById(id);

            if(meet is null)
            {
                return NotFound();
            }

            return Ok(meet);
        }
    }
}
