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
        currentStage?.ExitStage();
        currentStage = headingStage;
        currentStage.EnterStage();
    }

    public async void ChangeGameplayStage()
    {
        currentStage?.ExitStage();
        currentStage = gameplayStage;
        currentStage.EnterStage();
    }

    public async void ChangeGameOverStage()
    {
        currentStage?.ExitStage();
        currentStage = gameOverStage;
        currentStage.EnterStage();
    }

    public void ScrollSweatyBean()
    {
        rotationTweener = sweatyBean.transform
            .DOBlendableRotateBy(new Vector3(0, 0, 360), 0.8f, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Incremental);
        DOTween.To(value => { sweatyBean.transform.localPosition = new Vector3(value, 0, 0); }
            , -1500, 1500, 0.8f).OnComplete(() => rotationTweener.Kill());
    }
}