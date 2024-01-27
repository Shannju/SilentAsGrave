using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class massageGreen_Short : MonoBehaviour
{
    public int healthMassageGreenShort = 6;
    private Animator animator;
    [SerializeField] private Collider2D col;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetInteger("massageGreenShortChange", healthMassageGreenShort);
        if (Input.GetKeyUp(KeyCode.Q))
        {
            ReduceBoxLevel();
        }
    }
    public void ReduceBoxLevel()
    {
        healthMassageGreenShort -= 1;
        if (healthMassageGreenShort <= 0)
        {
            col.enabled = false;
        }
    }
}
