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
        public void UseWeapon(Vector2 currentDirection)
        {
            // ʵ�����ӵ���������λ��
            BadWordBullet bullet = Instantiate(bulletPrefab, bulletStartPoint.transform.position, Quaternion.identity);

            // ʹ�� currentDirection ��Ϊ���䷽��
            bullet.SetVector(currentDirection.normalized);
        }

        public void RemoveBean()
        {
            Destroy(this);
        }
    }
}