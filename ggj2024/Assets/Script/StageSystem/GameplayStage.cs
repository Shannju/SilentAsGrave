using System;
using Cysharp.Threading.Tasks;
using Script.Mapping;
using UnityEngine;
using UnityEngine.UI;

namespace Script.StageSystem
{
    public class GameplayStage : MonoBehaviour, IStage
    {
        [SerializeField] public StageController stageController;
        [SerializeField] public Button exitGameplayBtn;

        private void Awake()
        {
            exitGameplayBtn.onClick.AddListener(OnExitBtnClick);
        }

        private void OnExitBtnClick()
        {
            
        }

        public async UniTask InitStage()
        {
        }

        public async UniTask EnterStage()
        {
            EventManager.SendMessage(GameEventType.GameStart);
        }

        public async UniTask ExitStage()
        {
            
        }
    }
}