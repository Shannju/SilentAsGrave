using Script.Interface.ItemSystem;
using Script.ItemSystem.DropItem;
using UnityEngine;

namespace Script.ItemSystem.Weapon
{
    public class SweatyBean : MonoBehaviour, IWeapon
    {
        [SerializeField] private Sweat sweatPrefab;
        [SerializeField] private Animator animator;

        public void UseWeapon(Vector2 currentDirection)
        {
            var sweat = Instantiate(sweatPrefab);
            sweat.transform.position = gameObject.transform.position;
        }

        public void RemoveBean()
        {
            Destroy(this);
        }
    }
}