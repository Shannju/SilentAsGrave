using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Mapping;

public class GameLoop : MonoBehaviour
{
    private bool player1IsAlive;
    private bool player2IsAlive;
    private bool player3IsAlive;
    private float gameDuration = 0f;

    void Awake()
    {
        // 添加监听器
        EventManager.AddListener(GameEventType.GameStart, OnGameStart);
        EventManager.AddListener(GameEventType.Player1Revived, () => OnPlayerRevived(1));
        EventManager.AddListener(GameEventType.Player2Revived, () => OnPlayerRevived(2));
        EventManager.AddListener(GameEventType.Player3Revived, () => OnPlayerRevived(3));
        EventManager.AddListener(GameEventType.Player1Dead, () => OnPlayerDead(1));
        EventManager.AddListener(GameEventType.Player2Dead, () => OnPlayerDead(2));
        EventManager.AddListener(GameEventType.Player3Dead, () => OnPlayerDead(3));
    }

    void OnDestroy()
    {
        // 移除监听器
        EventManager.RemoveListener(GameEventType.GameStart, OnGameStart);
        EventManager.RemoveListener(GameEventType.Player1Revived, () => OnPlayerRevived(1));
        EventManager.RemoveListener(GameEventType.Player2Revived, () => OnPlayerRevived(2));
        EventManager.RemoveListener(GameEventType.Player3Revived, () => OnPlayerRevived(3));
        EventManager.RemoveListener(GameEventType.Player1Dead, () => OnPlayerDead(1));
        EventManager.RemoveListener(GameEventType.Player2Dead, () => OnPlayerDead(2));
        EventManager.RemoveListener(GameEventType.Player3Dead, () => OnPlayerDead(3));
    }
    void OnGameStart()
    {
        // 初始化玩家状态和游戏时长
        player1IsAlive = player2IsAlive = player3IsAlive = true;
        gameDuration = 0f;
    }

    void OnPlayerRevived(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1: player1IsAlive = true; break;
            case 2: player2IsAlive = true; break;
            case 3: player3IsAlive = true; break;
        }
    }

    void OnPlayerDead(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1: player1IsAlive = false; break;
            case 2: player2IsAlive = false; break;
            case 3: player3IsAlive = false; break;
        }
    }
    void OnGameOver()
    {
        // 游戏结束逻辑
        Debug.Log("Game Over!");
        EventManager.SendMessage(GameEventType.GameOver); // 发送游戏结束消息
    }
    void Update()
    {
        // 更新游戏持续时间
        gameDuration += Time.deltaTime;

        // 检查是否所有玩家都死亡
        if (!player1IsAlive && !player2IsAlive && !player3IsAlive)
        {
            OnGameOver();
        }

        // 检查游戏是否已经持续了120秒
        if (gameDuration >= 120f)
        {
            OnGameOver();
        }
    }
}


