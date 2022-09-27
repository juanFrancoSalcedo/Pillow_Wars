namespace PillowWars.Units.Pijaman
{
    public class BasicAttackPijamanCommand : Command
    {
        public override TypeAttack attackType { get; protected set; } = TypeAttack.Basic;

        public override void Execute(EntityStateController stateController)
        {
            if (stateController != null)
                stateController.Attack(attackType);
        }
    }
}

