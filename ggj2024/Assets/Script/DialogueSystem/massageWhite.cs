using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class massageWhite : MonoBehaviour
{
    public int healthMassageWhite = 9;
    private Animator animator;
    [SerializeField] private Collider2D col;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetInteger("massageWhiteChange", healthMassageWhite);
        if (Input.GetKeyUp(KeyCode.Q))
        {
            ReduceBoxLevel();
        }
    }
    public void ReduceBoxLevel()
    {
        healthMassageWhite -= 1;
        if (healthMassageWhite <= 0)
        {
            col.enabled = false;
        }
    }
}
