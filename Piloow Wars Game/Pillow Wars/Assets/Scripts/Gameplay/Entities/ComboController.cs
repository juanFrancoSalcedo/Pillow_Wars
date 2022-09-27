using System.Collections.Generic;



namespace PillowWars
{
    public class ComboController
    {
        public Stack<Command> ActionStacks { get; private set; } = new Stack<Command>();
        public void AddCommand(Command command) => ActionStacks.Push(command);
    }
}

