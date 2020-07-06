using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;

namespace Commander.Controllers
{
  // api/commands
  [Route("api/commands")]
  [ApiController]
  public class CommandsController: ControllerBase
  {
    private readonly ICommanderRepo _repository;
    private readonly IMapper _mapper;

    public CommandsController(ICommanderRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    // GET api/commands
    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
    {
      var commandItems = _repository.GetAllCommands();
      if(commandItems.Any())
      {
        return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
      }
      
      return NotFound();  
    }
    // GET api/commands/{id}
    [HttpGet("{id}", Name="GetCommandById")]
    public ActionResult<CommandReadDto> GetCommandById(int id)
    {
      var commandItem = _repository.GetCommandById(id);
      if(commandItem != null) 
      {
        return Ok(_mapper.Map<CommandReadDto>(commandItem));
      }

      return NotFound();    
    }

    // POST api/commands
    [HttpPost]
    public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
    {
      var commandModel =  _mapper.Map<Command>(commandCreateDto);

      _repository.CreateCommand(commandModel);
      _repository.SaveChanges();

      var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

      return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
    }

    // PUT api/commands/{id}
    [HttpPut("{id}")]
    public ActionResult<CommandReadDto> UpdateCommand(int id, CommandUpdateDto commandUpateDto)
    {
      var commandModelFromRepo = _repository.GetCommandById(id);

      if(commandModelFromRepo == null)
      {
        return NotFound();
      }

      // map incoming DTO to model returned from DB
      _mapper.Map(commandUpateDto, commandModelFromRepo);

      _repository.UppdateCommand(commandModelFromRepo);
      _repository.SaveChanges();

      return NoContent();
    }

    // PATCH api/commands/{id} 
    [HttpPatch("{id}")]
     public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
     {
       var commandModelFromRepo = _repository.GetCommandById(id);

       if(commandModelFromRepo == null)
       {
         return NotFound();
       }

       var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
       patchDoc.ApplyTo(commandToPatch, ModelState);

       if(!TryValidateModel(commandToPatch))
       {
         return ValidationProblem(ModelState);
       }

       _mapper.Map(commandToPatch, commandModelFromRepo);

       _repository.UppdateCommand(commandModelFromRepo);

       _repository.SaveChanges();

       return NoContent();
     }

      // DELETE api/commands/{id}
     [HttpDelete("{id}")]
     public ActionResult DeleteCommand(int id)
     {
        var commandModelFromRepo = _repository.GetCommandById(id);

       if(commandModelFromRepo == null)
       {
         return NotFound();
       }

       _repository.DeleteCommand(commandModelFromRepo);
       _repository.SaveChanges();

       return NoContent();
     }
  }
}