using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class massageGreen : MonoBehaviour
{
    
    public int healthMassageGreen = 9;
    private Animator animator;
    [SerializeField] private Collider2D col;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetInteger("massageGreenChange", healthMassageGreen);
        if (Input.GetKeyUp(KeyCode.Q))
        {
            ReduceBoxLevel();
        }
    }
    public void ReduceBoxLevel()
    {
        healthMassageGreen -= 1;
        if (healthMassageGreen <= 0)
        {
            col.enabled = false;
        }
    }
}
