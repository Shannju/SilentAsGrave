using Script.Mapping;
using UnityEngine;

public class PlayerController2 : BasePlayerController
{
    // 添加拍打范围和力量的变量

    protected override void MovePlayer()
    {
        // 使用方向键来设置目标速度向量
        inputVector = new Vector2(
            (Input.GetKey(KeyCode.LeftArrow) ? -direction : 0) + (Input.GetKey(KeyCode.RightArrow) ? direction : 0),
            (Input.GetKey(KeyCode.DownArrow) ? -direction : 0) + (Input.GetKey(KeyCode.UpArrow) ? direction : 0)
        ).normalized;

        targetVelocity = inputVector * moveSpeed * currentSpeedModifier;

        // 使用Lerp平滑当前速度到目标速度
        currentVelocity = Vector2.Lerp(currentVelocity, targetVelocity, inertia * Time.deltaTime);

        // 移动玩家
        transform.position += new Vector3(currentVelocity.x, currentVelocity.y, 0f) * Time.deltaTime;
        
        // 在MovePlayer方法中更新lastMoveDirection
        if ((Vector2)inputVector != Vector2.zero)
        {
            Vector2 perpendicularVector = Vector2.Perpendicular(inputVector);
            lastMoveDirection = -perpendicularVector;
        }

        UpdateDirectionIndicator();
    }

    protected override void UseSkill()
    {
        if (skillCooldown >= 0.1f)
        {
            skillCooldown -= Time.deltaTime;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            currentBean.UseWeapon();
            skillCooldown = GameConfig.SkillCooldown;
        }
    }

    protected override void UseSlap()
    {
        if (slapCooldown >= 0.1f)
        {
            slapCooldown -= Time.deltaTime;
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Slap();
            slapCooldown = GameConfig.SlapCooldown;
        } // 当按下小键盘数字1键时返回true
    }
}