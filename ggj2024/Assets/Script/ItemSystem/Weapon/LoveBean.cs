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
            // ʵ�����ӵ���������λ��
            LoveBullet bullet = Instantiate(bulletPrefab, bulletStartPoint.transform.position, Quaternion.identity);

            // ʹ�� currentDirection ��Ϊ���䷽��
            bullet.SetVector(currentDirection.normalized);
        }
        
        public void RemoveBean()
        {
            Destroy(this);
        }
    }
}