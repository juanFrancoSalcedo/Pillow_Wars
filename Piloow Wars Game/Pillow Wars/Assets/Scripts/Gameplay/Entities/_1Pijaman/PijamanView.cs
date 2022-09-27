using System;
using UnityEngine;


namespace PillowWars.Units.Pijaman
{
    [Serializable]
    public class PijamanView
    {
        [field: SerializeField] public BaseNavigationAgentController AgentController { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public AnimationEntityView[] AnimationsKeys { get; set; }
    }
}


