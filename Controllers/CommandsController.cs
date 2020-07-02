using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
  // api/commands
  [Route("api/commands")]
  [ApiController]
  public class CommandsController: ControllerBase
  {
    private readonly ICommanderRepo _repository;

    public CommandsController(ICommanderRepo repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Command>> GetAllCommands()
    {
      var commandItems = _repository.GetAllCommands();
      return Ok(commandItems);
    }
    // api/commands/{id}
    [HttpGet("{id}")]
    public ActionResult<Command> GetCommandById(int id)
    {
      var commandItem = _repository.GetCommandById(id);
      return Ok(commandItem);
    }
  }
}