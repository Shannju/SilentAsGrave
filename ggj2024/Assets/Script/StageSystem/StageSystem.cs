using Script.Mapping;
using Script.StageSystem;
using UnityEngine;

public class StageSystem : MonoBehaviour
{
    private IStage headingStage;
    private IStage gameplayStage;
    private IStage gameOverStage;
    private IStage currentStage;

    private void Awake()
    {
        EventManager.AddListener(GameEventType.GameOver, OnGameOver);
        headingStage = new HeadingStage();
        gameplayStage = new GameplayStage();
        gameOverStage = new GameOverStage();
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
}