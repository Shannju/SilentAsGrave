using Script.Interface.ItemSystem;
using UnityEngine;

namespace Script.ItemSystem.Weapon
{
    public class NormalBean : MonoBehaviour, IWeapon
    {
        [SerializeField] private Animator animator;

        public void UseWeapon(Vector2 currentDirection)
        {
        }
        
        public void RemoveBean()
        {
            Destroy(this);
        }
    }
}