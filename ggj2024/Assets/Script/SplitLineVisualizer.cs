using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitLineVisualizer : MonoBehaviour
{
    public float angleDegrees = 45.0f; // 分割线的角度
    public float lineLength = 10.0f; // 分割线的长度
    private LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer != null)
        {
            // 计算分割线的角度并将其转换为弧度
            float angleRadians = angleDegrees * Mathf.Deg2Rad;

            // 计算分割线的起点和终点
            Vector3 startPoint = transform.position;
            Vector3 endPoint = startPoint + new Vector3(Mathf.Cos(angleRadians) * lineLength, Mathf.Sin(angleRadians) * lineLength, 0);

            // 设置LineRenderer的位置
            lineRenderer.SetPositions(new Vector3[] { startPoint, endPoint });
        }
        else
        {
            Debug.LogError("未找到 LineRenderer 组件。");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
