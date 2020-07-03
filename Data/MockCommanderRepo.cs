using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
  public class MockCommanderRepo : ICommanderRepo
  {
    public void CreateCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<Command> GetAllCommands()
    {
      var commands = new List<Command>
      {
        new Command{Id=0, HowTo="Make Tacos", Line="Season Meat", Platform="Pan"},
        new Command{Id=0, HowTo="Make Pizza", Line="Add Cheese", Platform="Oven"},
        new Command{Id=0, HowTo="Make Spagetti", Line="Boil Water", Platform="Pot"}
      };
      return commands;
    }

    public Command GetCommandById(int Id)
    {
      return new Command{Id=0, HowTo="Make Tacos", Line="Season Meat", Platform="Pan"};
    }

    public bool SaveChanges()
    {
      throw new System.NotImplementedException();
    }
  }
}