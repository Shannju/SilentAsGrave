using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class massageGreen : MonoBehaviour
{
    
    public int healthMassageGreen = 3;
    public Transform bone_2;
    private Animator animator;
    private float yOffsetPerHealth;
    [SerializeField] private Collider2D col;

    void Start()
    {
        animator = GetComponent<Animator>();
        Vector3 initialPosition = new Vector3(0.1900753f, 0.281807f, 0f);
        Vector3 endPosition = new Vector3(0.02302467f, 0.004980184f, 0f);
        
        // 计算两个骨骼的 Y 坐标差值
        Vector3 positionDifference = endPosition - initialPosition;
        yOffsetPerHealth = positionDifference.y / 5;

    }

    void Update()
    {
        // 根据 healthMassageGreen 的值计算 Y 偏移量，确保它不小于0
        float yOffset = Mathf.Max(0, healthMassageGreen * yOffsetPerHealth);

        // 使用 Animator 控制 bone_2 的 Y 位置
        animator.SetInteger("massageGreenChange", healthMassageGreen);
        if (Input.GetKeyUp(KeyCode.Q))
        {
            ReduceBoxLevel();
        }
    }
    public void ReduceBoxLevel()
    {
        healthMassageGreen -= 1;
        if (healthMassageGreen == 0)
        {
            col.enabled = false;
        }
    }
}
