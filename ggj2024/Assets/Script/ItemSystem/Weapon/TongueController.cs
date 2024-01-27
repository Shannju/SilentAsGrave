using Script.Interface.ItemSystem;
using Script.ItemSystem.Weapon.Melee;
using UnityEngine;
namespace Script.ItemSystem.Weapon
{
    using UnityEngine;

    public class TongueController : MonoBehaviour
    {
        private GameObject tougue_base;
        private GameObject tougue;
        private Rigidbody2D tougueRigidbody;

        // 设置力和旋转的范围
        public float minForce = 5f;
        public float maxForce = 10f;
        public float minTorque = -10f;
        public float maxTorque = 10f;

        // Start is called before the first frame update
        void Start()
        {
            tougue_base = GameObject.Find("tougue_base");
            tougue = GameObject.Find("tougue");
            tougueRigidbody = tougue.GetComponent<Rigidbody2D>();
            if (tougueRigidbody == null)
            {
                Debug.LogError("Rigidbody2D not found on the tougue object!");
            }
        }

        // Update is called once per frame
        void Update()
        {
            // 更新逻辑（如果有的话）
        }

        // 施加一个随机方向的力和旋转
        public void Attack()
        {
            float forceMagnitude = Random.Range(minForce, maxForce);
            float torqueMagnitude = Random.Range(minTorque, maxTorque);

            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            tougueRigidbody.AddForce(randomDirection * forceMagnitude, ForceMode2D.Impulse);
            tougueRigidbody.AddTorque(torqueMagnitude, ForceMode2D.Impulse);
        }
    }

}