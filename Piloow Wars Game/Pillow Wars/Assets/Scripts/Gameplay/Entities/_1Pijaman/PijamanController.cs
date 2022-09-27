using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PillowWars.Units.Pijaman
{
    public class PijamanController : BaseEntity
    {
        [field: SerializeField] public PijamanView PijamanView { get; private set; }
        private void Start() => StateController = new PijamanStateController(this);
    }
}


