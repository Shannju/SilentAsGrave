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
    private bool temp1 = false;
    private bool temp2 = false;
    private bool temp3 = false;

    public TextMeshProUGUI stayTimeText1; // UI文本元素的引用
    public TextMeshProUGUI stayTimeText2;
    public TextMeshProUGUI stayTimeText3;
    [SerializeField]public PlayerController1 player1;
    [SerializeField]public PlayerController2 player2;
    [SerializeField]public PlayerController3 player3;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
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

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player1") {
            P1isInside = false;
            P1stayTime = 0f;
            temp1 = false;
        }
        if (other.gameObject.tag == "Player2") {
            P2isInside = false;
            P2stayTime = 0f;
            temp2 = false;
        }
        if (other.gameObject.tag == "Player3") {
            P3isInside = false;
            P3stayTime = 0f;
            temp3 = false;
        }
    }

    void Update()
    {
        if (P1isInside)
        {
            P1stayTime += Time.deltaTime;
            stayTimeText1.text = "P2"+ (3f - P1stayTime).ToString("F2")+ "To DIE!!";
            if (P1stayTime >= 3.0f && !temp1)
            {
                player1.Die();
                stayTimeText1.text = "P1 Dying";
                temp1 = true;
            }
        }
        else
        {
            stayTimeText1.text = "";
        }
        if (P2isInside)
        {
            P2stayTime += Time.deltaTime;
            stayTimeText2.text = "P2"+ (3f - P2stayTime).ToString("F2")+ "To DIE!!";
            if (P2stayTime >= 3.0f && !temp2)
            {
                player2.Die();
                stayTimeText2.text = "P2 Dying";
                temp2 = true;
            }
        }
        else
        {
            stayTimeText2.text = "";
        }
        if (P3isInside)
        {
            P3stayTime += Time.deltaTime;
            stayTimeText3.text = "P2"+ (3f - P3stayTime).ToString("F2")+ "To DIE!!";
            if (P3stayTime >= 3.0f && !temp3)
            {
                player3.Die();
                stayTimeText3.text = "P3 Dying";
                temp3 = true;
            }
        }
        else
        {
            stayTimeText3.text = "";
        }
    }
}
