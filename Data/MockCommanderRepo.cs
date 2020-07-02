using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
  public class MockCommanderRepo : ICommanderRepo
  {
    public IEnumerable<Command> GetAppCommands()
    {
      var commands = new List<Command>
      {
        new Command{Id=0, HowTo="Make Tacos", Line="Season Meat", Platform="Pan"},
        new Command{Id=0, HowTo="Make Pizza", Line="Add Cheese", Platform="Ovem"},
        new Command{Id=0, HowTo="Make Spagetti", Line="Boil Water", Platform="Pot"}
      };
      return commands;
    }

    public Command GetCommandById(int Id)
    {
      return new Command{Id=0, HowTo="Make Tacos", Line="Season Meat", Platform="Pan"};
    }
  }
}