using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
  public interface ICommanderRepo
  {
    bool SaveChanges();
    IEnumerable<Command> GetAllCommands();
    Command GetCommandById(int Id);
    void CreateCommand(Command cmd);
    void UppdateCommand(Command cms);
  }
}