using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
  public class CommanderRepo : ICommanderRepo
  {
    private readonly CommanderContext _context;

    public CommanderRepo(CommanderContext context)
    {
      _context = context;
    }

    public void CreateCommand(Command cmd)
    {
      if(cmd == null)
      {
        throw new ArgumentNullException(nameof(cmd));
      }

      _context.Commands.Add(cmd);
    }

    public IEnumerable<Command> GetAllCommands()
    {
      return _context.Commands.ToList();
    }

    public Command GetCommandById(int Id)
    {
      return _context.Commands.FirstOrDefault(command => command.Id == Id);
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

    public void UppdateCommand(Command cmd)
    {
      _context.Commands.Update(cmd);
    }

    public void DeleteCommand(Command cmd)
    {
     if(cmd == null)
     {
       throw new ArgumentNullException(nameof(cmd));
     }

     _context.Commands.Remove(cmd);
    }
  }
}