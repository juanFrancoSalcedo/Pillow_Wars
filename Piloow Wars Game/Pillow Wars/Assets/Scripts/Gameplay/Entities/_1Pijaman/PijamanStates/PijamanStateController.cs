using System;
using UnityEngine;


namespace PillowWars.Units.Pijaman
{
    public class PijamanStateController: EntityStateController
    {
        private readonly PijamanController entity;
        private EntityStateContext context = null;
        IEntityState walkState;
        IEntityState idleState;
        IEntityState basicAttackState;
        IEntityState longAttackState;

        public PijamanStateController(BaseEntity entity)
        {
            this.context = new EntityStateContext();
            this.entity = (PijamanController)entity;
            Init();
            CreateStates();
        }

        private void Init()
        {
            entity.PijamanView.AgentController.OnVelocityChanged += CalculateVelocityAgent;
        }

        private void CreateStates()
        {
            walkState = new PijamanWalkState(entity.PijamanView);
            idleState = new PijamanIdleState(entity.PijamanView);
            basicAttackState = new PijamanBasicAttackState(entity.PijamanView);
        }

        private void CalculateVelocityAgent(float velocity)
        {
            entity.PijamanView.Animator.SetFloat("AgentVelocity", velocity);
            context.Transition((velocity > 1) ? walkState : idleState);
        }

        public override void Attack(TypeAttack attack)
        {
            entity.PijamanView.Animator.SetTrigger("BasicAttack");
            context.Transition(attack.Equals(TypeAttack.Basic) ? basicAttackState : longAttackState);
        }

        ~PijamanStateController()
        {
            entity.PijamanView.AgentController.OnVelocityChanged -= CalculateVelocityAgent;
        }
    }
}

