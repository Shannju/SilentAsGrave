using Script.Mapping;
using UnityEngine;

namespace Script.ItemSystem.Supplies
{
    public class Supplies : MonoBehaviour
    {
        [SerializeField] public BeanType beanType;

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log(other.gameObject.name);
            if (other.gameObject.CompareTag($"Player1"))
            {
                BasePlayerController playerController = other.gameObject.GetComponent<BasePlayerController>();
                playerController.SetWeapon(beanType);
                GameObject o;
                (o = gameObject).SetActive(false);
                Destroy(o);
            }
            else if (other.gameObject.CompareTag($"Player2"))
            {
                BasePlayerController playerController = other.gameObject.GetComponent<BasePlayerController>();
                playerController.SetWeapon(beanType);
                GameObject o;
                (o = gameObject).SetActive(false);
                Destroy(o);
            }
        }
    }
}