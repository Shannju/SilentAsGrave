using System.Collections.Generic;
using Script.Mapping;
using UnityEngine;

namespace Script.ItemSystem.Weapon.Melee
{
    public class NaughtyTone : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        private GameObject tougue_base;
        private GameObject tougue;
        private Rigidbody2D tougueRigidbody;

        // 设置力和旋转的范围
        public float minForce = 5f;
        public float maxForce = 10f;
        public float minTorque = -10f;
        public float maxTorque = 10f;

        public void Attack()
        {
            float forceMagnitude = Random.Range(minForce, maxForce);
            float torqueMagnitude = Random.Range(minTorque, maxTorque);

            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            tougueRigidbody.AddForce(randomDirection * forceMagnitude, ForceMode2D.Impulse);
            tougueRigidbody.AddTorque(torqueMagnitude, ForceMode2D.Impulse);
        }
        // [SerializeField, Header("检测精度")] private float accuracy;

        // public void Sweep(Vector3 vector)
        // {
        //     List<GameObject> sweepObjs = new List<GameObject>();
        //     for (int i = 0; i < GameConfig.NaughtyToneAngle; i++)
        //     {
        //         var go = SweepAround(vector);
        //         if (go != null) sweepObjs.Add(go);
        //     }

        //     if (sweepObjs.Count >= 1) Destroy(sweepObjs[0]);
        // }

        // private GameObject SweepAround(Vector3 vector)
        // {
        //     var position = transform.position;
        //     Debug.DrawRay(position, vector * GameConfig.NaughtyToneRadius, Color.green);
        //     RaycastHit2D hit;
        //     hit = Physics2D.Raycast(position, vector, GameConfig.NaughtyToneRadius);
        //     if (hit.collider != null && !hit.collider.CompareTag($"Player1") && !hit.collider.CompareTag($"Player1"))
        //     {
        //         return hit.collider.gameObject;
        //     }

        //     return null;
        // }
    }
}