using UnityEngine;
public enum TerrainType
{
    Plain, // 平原，基础移动速度
    Water, // 启动时减速效果
    Ice, // 滑的不行
    // 可以根据需要添加更多地形类型
}

[RequireComponent(typeof(Collider2D))] // 确保地形区域有碰撞器
public class Terrain : MonoBehaviour
{
    public TerrainType terrainType; // 当前地形的类型
    public float speedModifier = 1f; // 移动速度的修改因子

    // 根据地形类型设置移动速度的修改因子
    private void Start()
    {
        switch (terrainType)
        {
            case TerrainType.Plain:
                speedModifier = 1f; // 平原不改变速度
                break;
            case TerrainType.Water:
                speedModifier = 0.7f; // 森林减少20%速度
                break;
            case TerrainType.Ice:
                speedModifier = 0.5f; // 山地减少50%速度
                break;
            // 更多地形的处理...
            default:
                speedModifier = 1f;
                break;
        }
    }

    // 玩家进入地形区域时调用
    private void OnTriggerEnter2D(Collider2D other)
    {
        BasePlayerController player1 = other.GetComponent<BasePlayerController>();
        if (player1 != null)
        {
            player1.AdjustSpeed(speedModifier);
        }
        BasePlayerController player2 = other.GetComponent<BasePlayerController>();
        if (player2 != null)
        {
            player2.AdjustSpeed(speedModifier);
        }
    }

    // 玩家离开地形区域时调用
    private void OnTriggerExit2D(Collider2D other)
    {
        BasePlayerController player = other.GetComponent<BasePlayerController>();
        if (player != null)
        {
            player.ResetSpeed();
        }
    }
}
