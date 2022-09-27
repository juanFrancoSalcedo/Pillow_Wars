namespace PillowWars
{
    public abstract class Command 
    {
        public abstract TypeAttack attackType { get; protected set; }
        public abstract void Execute(EntityStateController stateController);
    }
}

