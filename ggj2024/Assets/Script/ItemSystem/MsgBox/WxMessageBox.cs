using UnityEngine;

namespace Script.ItemSystem.MsgBox
{
    public class WxMessageBox : MonoBehaviour
    {
        [SerializeField] private int hitCount;
        [SerializeField] private Collider2D col;

        public void ReduceBoxLevel()
        {
            hitCount -= 1;
            if (hitCount == 0)
            {
                col.enabled = false;
            }
        }
    }
}