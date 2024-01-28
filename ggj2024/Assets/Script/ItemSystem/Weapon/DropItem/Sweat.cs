using UnityEngine;

namespace Script.ItemSystem.DropItem
{
    public class Sweat : MonoBehaviour
    {
        private void Start()
        {
            // �� 10 ������������Ϸ����
            Destroy(gameObject, 10f);
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag($"Player1") || other.gameObject.CompareTag($"Player2"))
            {
                BasePlayerController playerController = other.gameObject.GetComponent<BasePlayerController>();
                playerController.SetSlipState();
            }
        }
    }
}