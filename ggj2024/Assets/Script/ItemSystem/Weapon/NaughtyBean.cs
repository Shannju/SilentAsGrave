using Script.Interface.ItemSystem;
using Script.ItemSystem.Weapon.Melee;
using UnityEngine;

namespace Script.ItemSystem.Weapon
{
    public class NaughtyBean : MonoBehaviour, IWeapon
    {
        [SerializeField] private NaughtyTone naughtyTone;
        [SerializeField] private Animator animator;
        
        public void UseWeapon(Vector2 currentDirection)
        {
            // naughtyTone.Sweep((transform.position - naughtyTone.transform.position).normalized);
            naughtyTone.Attack();
        }

        public void RemoveBean()
        {
            Destroy(this);
        }
    }
}