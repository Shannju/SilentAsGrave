using Cysharp.Threading.Tasks;
using Script.StageSystem;
using UnityEngine;

public class GameOverStage : MonoBehaviour, IStage
{
    [SerializeField] public StageController stageController;

    public async UniTask InitStage()
    {
    }

    public async UniTask EnterStage()
    {
    }

    public async UniTask ExitStage()
    {
    }
}