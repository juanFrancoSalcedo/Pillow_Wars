namespace PillowWars.Units.Pijaman
{
    public class PijamanWalkState : IEntityState
    {
        private PijamanView view;
        public PijamanWalkState(PijamanView view) => this.view = view;

        public void Handle()
        {
            // Nothing todo maybe in the futures
        }
    }
}


