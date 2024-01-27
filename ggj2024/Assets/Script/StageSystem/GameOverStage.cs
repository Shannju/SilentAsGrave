using Cysharp.Threading.Tasks;
using DG.Tweening;
using Script.StageSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverStage : MonoBehaviour, IStage
{
    [SerializeField] private StageController stageController;
    [SerializeField] private Image background;
    [SerializeField] private TMP_Text text;
    [SerializeField] public Button exitGameOverBtn;

    private void Awake()
    {
        exitGameOverBtn.onClick.AddListener(OnExitBtnClick);
    }

    private void OnExitBtnClick()
    {
        stageController.ChangeHeadingStage();
    }

    public async UniTask InitStage()
    {
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public async UniTask EnterStage()
    {
        exitGameOverBtn.gameObject.SetActive(true);
        await DOTween.To(value => { background.transform.localPosition = new Vector3(value, 0, 0); },
                -1920, 0, 0.8f)
            .SetEase(Ease.InBounce)
            .ToUniTask();
        stageController.ScrollQuartSweatyBean();
        DOTween.To(value => { text.color = new Color(1, 1, 1, 1); },
            -1920, 0, 0.8f);
    }

    public async UniTask ExitStage()
    {
        exitGameOverBtn.gameObject.SetActive(false);
    }
}