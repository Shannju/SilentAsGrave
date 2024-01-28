using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
    private float P1stayTime = 0f;
    private float P2stayTime = 0f;
    private float P3stayTime = 0f;
    private bool P1isInside = false;
    private bool P2isInside = false;
    private bool P3isInside = false;
    public Text stayTimeText1; // UI文本元素的引用
    public Text stayTimeText2;
    public Text stayTimeText3;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player1") { // 确保与您要跟踪的对象标签匹配
            P1isInside = true;
        }
        if (other.gameObject.tag == "Player2") {
            P2isInside = true;
        }
        if (other.gameObject.tag == "Player3") {
            P3isInside = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player1") {
            P1isInside = false;
            P1stayTime = 0f;
        }
        if (other.gameObject.tag == "Player2") {
            P2isInside = false;
            P2stayTime = 0f;
        }
        if (other.gameObject.tag == "Player3") {
            P3isInside = false;
            P3stayTime = 0f;
        }
    }

    void Update()
    {
        if (P1isInside)
        {
            P1stayTime += Time.deltaTime;
            stayTimeText1.text = P1stayTime.ToString("F2");
        }
        if (P2isInside)
        {
            P2stayTime += Time.deltaTime;
            stayTimeText2.text = P2stayTime.ToString("F2");
        }
        if (P3isInside)
        {
            P3stayTime += Time.deltaTime;
            stayTimeText.text = P3stayTime.ToString("F2");
        }
    }
}
