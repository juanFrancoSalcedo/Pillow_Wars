namespace PillowWars.Units.Pijaman
{
    public class PijamanBasicAttackState : IEntityState
    {
        private PijamanView view;
        public PijamanBasicAttackState(PijamanView view) => this.view = view;

        public void Handle()
        {
            // Nothing todo maybe in the futures
        }
    }
}

