using System.Numerics;
using UnityEngine;

namespace Script.Interface.ItemSystem
{
    public interface IWeapon
    {
        public void UseWeapon(UnityEngine.Vector2 currentDirection);
        public void RemoveBean();
    }
}