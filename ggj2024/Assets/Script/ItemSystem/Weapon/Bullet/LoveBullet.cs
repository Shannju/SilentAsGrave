using Script.Mapping;
using UnityEngine;

namespace Script.ItemSystem.Bullet
{
    public class LoveBullet : MonoBehaviour
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
            transform.position += bulletVector * GameConfig.LoveBulletSpeed * Time.deltaTime;
        }

        private void IncreaseLifeTime()
        {
            lifeTime += Time.deltaTime;
            if (lifeTime >= GameConfig.LoveBulletLifeTime)
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
            if (!other.gameObject.CompareTag(gameObject.tag) &&
                (other.gameObject.CompareTag($"Player1") || other.gameObject.CompareTag($"Player2")))
            {
                BasePlayerController playerController = other.gameObject.GetComponent<BasePlayerController>();
                Debug.Log($"{other.gameObject.name} Be love attacked.");
                Destroy(this);
            }
        }
    }
}