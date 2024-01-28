using Script.Interface.ItemSystem;
using Script.ItemSystem.Bullet;
using UnityEngine;

namespace Script.ItemSystem.Weapon
{
    public class LoveBean : MonoBehaviour, IWeapon
    {
        [SerializeField] private LoveBullet bulletPrefab;
        [SerializeField] private GameObject bulletStartPoint;
        [SerializeField] private Animator animator;
        
        public void UseWeapon(Vector2 currentDirection)
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