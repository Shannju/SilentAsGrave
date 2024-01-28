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
            // 实例化子弹并设置其位置
            LoveBullet bullet = Instantiate(bulletPrefab, bulletStartPoint.transform.position, Quaternion.identity);

            // 使用 currentDirection 作为发射方向
            bullet.SetVector(currentDirection.normalized);
        }
        
        public void RemoveBean()
        {
            Destroy(this);
        }
    }
}