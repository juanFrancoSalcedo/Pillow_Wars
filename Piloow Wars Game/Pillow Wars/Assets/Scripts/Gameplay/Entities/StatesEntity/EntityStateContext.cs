namespace PillowWars.Units.Pijaman
{
    public class EntityStateContext
    {
        public IEntityState CurrentContext { get; set; }

        public void Transition(IEntityState newState)
        {
            CurrentContext = newState;
            CurrentContext.Handle();
        }

        public void Transition() => CurrentContext.Handle();
    }
}


