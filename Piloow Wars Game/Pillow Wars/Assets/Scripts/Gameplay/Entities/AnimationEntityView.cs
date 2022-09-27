using System;
using UnityEngine;


namespace PillowWars.Units.Pijaman
{
    [Serializable]
    public class AnimationEntityView
    {
        //TODO Eliminar o buscar su utilidad
        [SerializeField] EntityAnimationType key;
        [SerializeField] string value;
        public static string GetValue(AnimationEntityView[] listEntities, EntityAnimationType key) => Array.Find(listEntities, e => e.key.Equals(key)).value;
    }
}


