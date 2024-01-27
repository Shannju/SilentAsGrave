using Cysharp.Threading.Tasks;
using DG.Tweening;
using Script.Mapping;
using Script.StageSystem;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    [SerializeField] private HeadingStage headingStage;
    [SerializeField] private GameplayStage gameplayStage;
    [SerializeField] private GameOverStage gameOverStage;
    [SerializeField] private Image sweatyBean;
    private IStage currentStage;
    private Tweener rotationTweener;
    public bool isQuart = false;

    private void Awake()
    {
        EventManager.AddListener(GameEventType.GameOver, OnGameOver);
        currentStage = headingStage;
    }

    private void OnGameOver()
    {
        ChangeGameOverStage();
    }

    private async void Start()
    {
        await currentStage.EnterStage();
    }

    public async void ChangeHeadingStage()
    {
        await currentStage.ExitStage();
        currentStage = headingStage;
        await currentStage.EnterStage();
    }

    public async void ChangeGameplayStage()
    {
        await currentStage.ExitStage();
        currentStage = gameplayStage;
        await currentStage.EnterStage();
    }

    public async void ChangeGameOverStage()
    {
        await currentStage.ExitStage();
        currentStage = gameOverStage;
        await currentStage.EnterStage();
    }

    public void ScrollSweatyBean()
    {
        rotationTweener = sweatyBean.transform
            .DOBlendableRotateBy(new Vector3(0, 0, 360), 0.8f, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Incremental);
        DOTween.To(value => { sweatyBean.transform.localPosition = new Vector3(value, 0, 0); }
            , -1500, 1500, 0.8f).OnComplete(() => rotationTweener.Kill());
    }

    public void ScrollQuartSweatyBean()
    {
        isQuart = true;
        DOTween.To(value => { sweatyBean.transform.localPosition = new Vector3(value, 0, 0); }
            , -1500, -815, 0.8f);
        sweatyBean.transform.DORotate(new Vector3(0, 0, -30), 0.8f);
    }

    public async UniTask ScrollQuartReset()
    {
        sweatyBean.transform.DORotate(new Vector3(0, 0, 0), 0.8f);
        await DOTween.To(value => { sweatyBean.transform.localPosition = new Vector3(value, 0, 0); }
            , -815, -1500, 0.8f).ToUniTask();
    }
}