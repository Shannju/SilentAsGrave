using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Script.Interface.ItemSystem;
using Script.ItemSystem.Weapon;
using Script.Mapping;
using UnityEngine;

public abstract class BasePlayerController : MonoBehaviour
{
    [SerializeField] private GameObject playerHand;

    public bool acceptMoveInput = true;
    public float moveSpeed = 5f;
    public float forceTime = 5f; // 力扩大倍数
    public float originalMoveSpeed;
    public float speedMultiplier = 1.5f; // X轴拉伸系数
    protected float currentSpeedModifier = 1f;
    public float impactMultiplier = 1f; // 计算冲量时使用它来放大或减小结果
    protected Vector2 currentVelocity;
    protected Vector2 targetVelocity;
    public float inertia = 0.7f; // 可调整的惯性系数
    public int direction = 1;

    public float slapRange = 1f;
    public float slapForce = 5f;
    protected LayerMask slapLayerMask; // LayerMask用于识别其他玩家
    protected Vector2 lastMoveDirection; // 存储上一次的移动方向
    protected Vector2 position;
    public GameObject directionIndicator;
    public float ellipseWidth = 0.2f; // 椭圆长轴的一半（横向）
    public float ellipseHeight = 0.1f; // 椭圆短轴的一半（纵向）
    protected float ellipseAngle = 0f;
    protected Vector2 perpendicularVector;
    protected Vector3 inputVector;

    # region ==== Slap & Skill ====

    protected float slapCooldown = 0f;
    protected float skillCooldown = 0f;

    # endregion

    # region ==== State ====

    private bool spiritState;
    private float spiritTimeDuration;
    private bool slipState;
    private float slipTimeDuration = 0f;
    private bool slowState = false;
    private float slowTimeDuration = 0f;
    private bool loveState = false;
    private float loveTimeDuration = 0f;

    # endregion

    # region ==== Weapon Prefabs ====

    [SerializeField] private NormalBean normalBean;
    [SerializeField] private BadWordBean badWordBean;
    [SerializeField] private LoveBean loveBean;
    [SerializeField] private NaughtyBean naughtyBean;
    [SerializeField] private PukeBean pukeBean;
    [SerializeField] private SweatyBean sweatyBean;
    [SerializeField] private DeadBean deadBean;
    protected IWeapon currentBean;

    #endregion
    protected abstract void Die();

    protected abstract void MovePlayer();
    protected abstract void UseSlap();
    protected abstract void UseSkill();

    private void StateUpdate()
    {
        if (spiritState)
        {
            spiritTimeDuration += Time.deltaTime;
            if (spiritTimeDuration >= GameConfig.SpiritDuration)
            {
                spiritState = false;
                spiritTimeDuration = 0f;
                direction = 1;
            }
        }

        if (slipState)
        {
            slipTimeDuration += Time.deltaTime;
            if (slipTimeDuration >= GameConfig.SlipDuration)
            {
                slipState = false;
                slipTimeDuration = 0f;
                Debug.Log($"Player exit slow state.");
            }
        }

        if (slowState)
        {
            slowTimeDuration += Time.deltaTime;
            if (slowTimeDuration >= GameConfig.SlowDuration)
            {
                slowState = false;
                slowTimeDuration = 0f;
                Debug.Log($"Player exit slow state.");
            }
        }

        if (loveState)
        {
            loveTimeDuration += Time.deltaTime;
            if (loveTimeDuration >= GameConfig.LoveDuration)
            {
                loveState = false;
                loveTimeDuration = 0f;
                Debug.Log($"Player exit love state.");
            }
        }
    }

    protected void Start()
    {
        
        // playerHandRenderer.color = new Color(1, 1, 1, 1);
    }

    protected void Update()
    {
        StateUpdate();
        if (acceptMoveInput)
        {
            MovePlayer();
        }

        UseSkill();
        UseSlap();
    }

    protected async void Slap() // 拍打技能
    {
/*        playerHandRenderer.transform.rotation = Quaternion.LookRotation(inputVector);*/
        // 检测前方180°范围内的物体
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, slapRange, slapLayerMask);
        Debug.Log($"{gameObject.name} use Slap.");
        foreach (var go in hits)
        {
            Debug.Log(go.name);
        }
        playerHand.GetComponent<HandController>().PlayLeft();

/*
        // 使用 DOTween 改变颜色
        await DOTween.To(() => playerHandRenderer.color, x => playerHandRenderer.color = x, new Color(1, 1, 1, 1), 0.2f).SetEase(Ease.InCirc);

        // 计算移动的目标位置
        Vector3 targetPosition = playerHandRenderer.gameObject.transform.localPosition + new Vector3(inputVector.x, inputVector.y, 0) * 0.1f;

        // 使用 DOTween 移动手掌
        await DOTween.To(() => playerHandRenderer.gameObject.transform.localPosition, x => playerHandRenderer.gameObject.transform.localPosition = x, targetPosition, 0.2f).SetEase(Ease.OutCirc);

        await UniTask.Delay(TimeSpan.FromSeconds(1d));

        // 重置 playerHand 位置和颜色
        playerHandRenderer.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        playerHandRenderer.color = new Color(1, 1, 1, 0);*/
    }

    protected void UpdateDirectionIndicator()
    {
        if (lastMoveDirection != Vector2.zero) // 确保有移动方向
        {
            // 更新指示器旋转使其朝向玩家的移动方向
            float angleRad = Mathf.Atan2(lastMoveDirection.y, lastMoveDirection.x);
            float angleDeg = angleRad * Mathf.Rad2Deg;
            directionIndicator.transform.rotation = Quaternion.AngleAxis(angleDeg, Vector3.forward);

            // 计算椭圆上的位置
            float xPosition = Mathf.Cos(angleRad + Mathf.PI / 2) * ellipseWidth + transform.position.x;
            float yPosition = Mathf.Sin(angleRad + Mathf.PI / 2) * ellipseHeight + transform.position.y;

            // 围绕玩家椭圆
            directionIndicator.transform.position = new Vector3(xPosition, yPosition, 0f);
        }
    }

    public void ResetSpeed() // 用于急停
    {
        moveSpeed = originalMoveSpeed; // 假设您存储了原始的moveSpeed值
        currentVelocity = Vector2.zero; // 重置当前速度
    }

    public void AdjustSpeed(float newSpeedModifier)
    {
        // 调整目标速度以包含新的速度修正因子
        targetVelocity *= newSpeedModifier / currentSpeedModifier;
        currentSpeedModifier = newSpeedModifier;
    }
    protected void ApplyExternalForce(Vector2 force)
    {
        // 添加外部力到当前速度上
        currentVelocity += force;
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        // 计算碰撞产生的力（示例）
        Vector2 force = collision.relativeVelocity * collision.rigidbody.mass * impactMultiplier;
        // 假设对方刚体的质量为1
        
        ApplyExternalForce(force);
    }

    public void SetWeapon(BeanType beanType)
    {
        currentBean?.RemoveBean();
        switch (beanType)
        {
            case BeanType.LoveBean:
                Debug.Log($"Player equip LoveBean.");
                var love = Instantiate(loveBean, transform);
                currentBean = love;
                break;
            case BeanType.NaughtyBean:
                Debug.Log($"Player equip NaughtyBean.");
                var naughty = Instantiate(naughtyBean, transform);
                currentBean = naughty;
                break;
            case BeanType.PukeBean:
                Debug.Log($"Player equip PukeBean.");
                var puke = Instantiate(pukeBean, transform);
                currentBean = puke;
                break;
            case BeanType.SweatyBean:
                Debug.Log($"Player equip SweatyBean.");
                var sweaty = Instantiate(sweatyBean, transform);
                currentBean = sweaty;
                break;
            case BeanType.BadWordBean:
                Debug.Log($"Player equip BadWordBean.");
                var badWord = Instantiate(badWordBean, transform);
                currentBean = badWord;
                break;
            case BeanType.DeadBean:
                Debug.Log("Player equip DeadBean");
                var dead = Instantiate(deadBean, transform);
                currentBean = dead;
                break;
            case BeanType.NormalBean:
                Debug.Log("Player equip NormalBean");
                var normal = Instantiate(normalBean, transform);
                currentBean = normal;
                break;
            default:
                Debug.Log("Player equip NormalBean");
                var normal2 = Instantiate(normalBean, transform);
                currentBean = normal2;
                return;
        }
    }

    public void SetSpiritExceptionState()
    {
        spiritState = true;
        direction = -1;
    }

    public void SetSlowState()
    {
        slowState = true;
        Debug.Log($"Player enter slow state.");
    }

    public void SetSlipState()
    {
        slipState = true;
        Debug.Log($"Player enter slip state.");
    }

    public void SetLoveState()
    {
        loveState = true;
        Debug.Log($"Player enter love state.");
    }
}