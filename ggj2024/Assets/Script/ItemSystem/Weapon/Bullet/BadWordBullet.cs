using System;
using Script.Mapping;
/*using UnityEngine;

namespace Script.ItemSystem.Bullet
{
    public class BadWordBullet : MonoBehaviour
    {
        private Vector3 bulletVector;
        private float lifeTime = 0f;

        private void Update()
        {
            Move();
            IncreaseLifeTime();
        }

        private void Move()
        {
            transform.position += bulletVector * GameConfig.BadWordBulletSpeed * Time.deltaTime;
        }

        private void IncreaseLifeTime()
        {
            lifeTime += Time.deltaTime;
            if (lifeTime >= GameConfig.BadWordBulletLifeTime)
            {
                Destroy(this);
            }
        }

        public void SetVector(Vector3 vector)
        {
            bulletVector = vector;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag($"Player1") || other.gameObject.CompareTag($"Player2"))
            {
                BasePlayerController playerController = other.gameObject.GetComponent<BasePlayerController>();
                playerController.SetSpiritExceptionState();
                Destroy(this);
            }
        }
    }
}*/

using UnityEngine;

namespace Script.ItemSystem.Bullet
{
    public class BadWordBullet : MonoBehaviour
    {
        private Vector3 bulletVector;
        private float lifeTime = 0f;

        private void Update()
        {
            Move();
            IncreaseLifeTime();
        }

        private void Move()
        {
            // 用 Vector3 来移动，确保 z 分量为 0
            transform.position += bulletVector * GameConfig.BadWordBulletSpeed * Time.deltaTime;
        }

        private void IncreaseLifeTime()
        {
            lifeTime += Time.deltaTime;
            if (lifeTime >= GameConfig.BadWordBulletLifeTime)
            {
                Destroy(gameObject); // 销毁整个子弹对象
            }
        }

        public void SetVector(Vector2 vector)
        {
            bulletVector = new Vector3(vector.x, vector.y, 0); // 将 Vector2 转换为 Vector3
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
            {
                BasePlayerController playerController = other.gameObject.GetComponent<BasePlayerController>();
                playerController.SetSpiritExceptionState();
                Destroy(gameObject); // 在碰撞时销毁子弹
            }
        }
    }
}
