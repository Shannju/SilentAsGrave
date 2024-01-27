using Script.Interface.ItemSystem;
using UnityEngine;

namespace Script.ItemSystem.Weapon
{
    public class DeadBean: MonoBehaviour, IWeapon
    {
        [SerializeField] private Animator animator;
        
        public void UseWeapon()
        {
            Debug.Log("Drop item.");
        }
        
        public void RemoveBean()
        {
            Destroy(this);
        }
    }
}