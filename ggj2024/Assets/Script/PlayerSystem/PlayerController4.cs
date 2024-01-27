using UnityEngine;

public class PlayerController4 : BasePlayerController
{
    public Vector2 mousePosition = Vector2.zero;
    private Vector2 direct = Vector2.zero;

    protected override void UseSlap()
    {
    }

    protected override void MovePlayer()
    {
        // 在这里编写鼠标控制移动的逻辑
        if (Input.GetMouseButton(0)) // 检查鼠标左键是否被按住
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direct = mousePosition - new Vector2(transform.position.x, transform.position.y);
            direct.Normalize();

            // 设置玩家移动方向和速度,使用Lerp平滑当前速度到目标速度
            targetVelocity = direct * moveSpeed * currentSpeedModifier;
            currentVelocity = Vector2.Lerp(currentVelocity, targetVelocity, inertia * Time.deltaTime);
        }

        // 移动玩家
        transform.position += new Vector3(currentVelocity.x, currentVelocity.y, 0f) * Time.deltaTime;
        // 在MovePlayer方法中更新lastMoveDirection
        if (mousePosition != Vector2.zero)
        {
            Vector2 perpendicularVector = Vector2.Perpendicular(direct);
            lastMoveDirection = -perpendicularVector;
        }

        UpdateDirectionIndicator();
    }

    protected override void UseSkill()
    {
    }
}