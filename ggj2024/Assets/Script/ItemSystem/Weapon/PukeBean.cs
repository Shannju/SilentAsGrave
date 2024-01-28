using Script.Interface.ItemSystem;
using Script.ItemSystem.DropItem;
using UnityEngine;

namespace Script.ItemSystem.Weapon
{
    public class PukeBean : MonoBehaviour, IWeapon
    {
        [SerializeField] private Puke pukePrefab;
        [SerializeField] private Animator animator;

        public void UseWeapon(Vector2 currentDirection)
        {
            var puke = Instantiate(pukePrefab);
            puke.transform.position = gameObject.transform.position;
        }
        
        public void RemoveBean()
        {
            Destroy(this);
        }
    }
}