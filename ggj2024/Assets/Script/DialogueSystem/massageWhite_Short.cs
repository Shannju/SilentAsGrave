using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class massageWhite_Short : MonoBehaviour
{
    public int healthMassageWhiteShort = 6;
    private Animator animator;
    [SerializeField] private Collider2D col;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetInteger("massageWhiteShortChange", healthMassageWhiteShort);
        if (Input.GetKeyUp(KeyCode.Q))
        {
            ReduceBoxLevel();
        }
    }
    public void ReduceBoxLevel()
    {
        healthMassageWhiteShort -= 1;
        if (healthMassageWhiteShort <= 0)
        {
            col.enabled = false;
        }
    }
}
