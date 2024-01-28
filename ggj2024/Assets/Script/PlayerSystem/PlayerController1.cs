using DG.Tweening;
using Script.Mapping;
using UnityEngine;

public class PlayerController1 : BasePlayerController
{
    private Rigidbody2D rb; // 计算力的向量中间值
    protected void Start()
    {
        /*SetWeapon(BeanType.NormalBean);*/
        SetWeapon(BeanType.LoveBean);
        originalMoveSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
    }
    // 添加拍打范围和力量的变量
    protected override void MovePlayer() 
    {
        // 使用WASD键位来设置目标速度向量
        inputVector = new Vector2(
            (Input.GetKey(KeyCode.A) ? -direction : 0) + (Input.GetKey(KeyCode.D) ? direction : 0),
            (Input.GetKey(KeyCode.S) ? -direction : 0) + (Input.GetKey(KeyCode.W) ? direction : 0)
        ).normalized;

        targetVelocity = inputVector * moveSpeed * currentSpeedModifier;

        // 计算力的向量
        Vector2 force = inputVector * moveSpeed * currentSpeedModifier * Time.fixedDeltaTime * forceTime;
        rb.AddForce(force);
        
        // 使用Lerp平滑当前速度到目标速度
        currentVelocity = Vector2.Lerp(currentVelocity, targetVelocity, inertia * Time.deltaTime);

        // 移动玩家
        //transform.position += new Vector3(currentVelocity.x, currentVelocity.y, 0f) * Time.deltaTime;
        
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

        if (Input.GetKeyDown(KeyCode.K))
        {
            currentBean.UseWeapon(currentDirection);
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
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            Slap();
            slapCooldown = GameConfig.SlapCooldown;
        } // 当按下J键时返回true
    }

    protected override void Die()
    {
        SetWeapon(BeanType.DeadBean);
        EventManager.SendMessage(GameEventType.Player1Dead);

    }
}