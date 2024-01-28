using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathManager : MonoBehaviour
{
    private float P1stayTime = 0f;
    private float P2stayTime = 0f;
    private float P3stayTime = 0f;
    private bool P1isInside = false;
    private bool P2isInside = false;
    private bool P3isInside = false;
    public TextMeshProUGUI stayTimeText1; // UI文本元素的引用
    public TextMeshProUGUI stayTimeText2;
    public TextMeshProUGUI stayTimeText3;
    [SerializeField]public PlayerController1 player1;
    [SerializeField]public PlayerController2 player2;
    [SerializeField]public PlayerController3 player3;

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
            stayTimeText1.text = "P1:" + P1stayTime.ToString("F2") + "To DIE!!";
            if (P1stayTime >= 3.0f)
            {
                player1.Die();
            }
        }
        else
        {
            stayTimeText1.text = "";
        }
        if (P2isInside)
        {
            P2stayTime += Time.deltaTime;
            stayTimeText2.text = "P2:" + P2stayTime.ToString("F2") + "To DIE!!";
            if (P2stayTime >= 3.0f)
            {
                player2.Die();
            }
        }
        else
        {
            stayTimeText2.text = "";
        }
        if (P3isInside)
        {
            P3stayTime += Time.deltaTime;
            stayTimeText3.text = "P3:" + P3stayTime.ToString("F2") + "To DIE!!";
            if (P3stayTime >= 3.0f)
            {
                player3.Die();
            }
        }
        else
        {
            stayTimeText3.text = "";
        }
    }
}
