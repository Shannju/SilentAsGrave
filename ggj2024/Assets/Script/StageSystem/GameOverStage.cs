using Cysharp.Threading.Tasks;
using DG.Tweening;
using Script.StageSystem;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverStage : MonoBehaviour, IStage
{
    [SerializeField] private StageController stageController;
    [SerializeField] private GameObject endGameGo;
    [SerializeField] public Button exitGameOverBtn;
    private GameObject instantiateGo;

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
        instantiateGo = Instantiate(endGameGo);
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        stageController.ScrollQuartSweatyBean();
    }

    public async UniTask ExitStage()
    {
        exitGameOverBtn.gameObject.SetActive(false);
    }

    public void RemoveInstantiateGo()
    {
        Destroy(instantiateGo);
    }
}