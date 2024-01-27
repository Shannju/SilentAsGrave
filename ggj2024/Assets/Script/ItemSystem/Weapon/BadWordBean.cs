using Script.Interface.ItemSystem;
using Script.ItemSystem.Bullet;
using UnityEngine;

namespace Script.ItemSystem.Weapon
{
    public class BadWordBean : MonoBehaviour, IWeapon
    {
        [SerializeField] private BadWordBullet bulletPrefab;
        [SerializeField] private GameObject bulletStartPoint;
        [SerializeField] private Animator animator;
        
        public void UseWeapon()
        {
            var go = Instantiate(bulletPrefab);
            go.SetVector((bulletStartPoint.transform.position - transform.position).normalized);
        }

        public void RemoveBean()
        {
            Destroy(this);
        }
    }
}