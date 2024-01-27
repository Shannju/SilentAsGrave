using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class massageGreen : MonoBehaviour
{
    public Transform spTrans01; // 生成位置1
    public Transform spTrans02; // 生成位置2
    public Transform spTrans03;
    public Transform spTrans04;
    public Transform spTrans05;
    private Transform[] MovePositions;
    public GameObject WxmassageGreen_Short;
    public float GenerateInterval = 10.0f;

    public int healthMassageGreen = 9;
    private Animator animator;
    private bool KeyDown = false;
    public float moveDuration = 1.0f; // 协程中，平滑移动的距离。值越小，移动越快。
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
