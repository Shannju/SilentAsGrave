using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // 获取 Animator 组件
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the game object.");
            return;
        }

    }

    public void PlayLeft()
    {
/*      Debug.LogWarning("PLAYING LEFT");*/
        animator.SetTrigger("LeftTrigger");
    }

    public void PlayRight()
    {
        animator.SetTrigger("RightTrigger");
    }
}
