namespace PillowWars.Units.Pijaman
{
    public class PijamanIdleState : IEntityState
    {
        private PijamanView view;
        public PijamanIdleState(PijamanView view) => this.view = view;

        public void Handle()
        {
            //Nothing Todo maybe in the future
        }
    }
}   