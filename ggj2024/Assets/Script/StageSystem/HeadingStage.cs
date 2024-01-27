using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Script.StageSystem
{
    public class HeadingStage : MonoBehaviour, IStage
    {
        [SerializeField] public StageController stageController;
        [SerializeField] private RawImage emojis;
        [SerializeField] private Button enterGameBtn;
        [Range(0f, 0.5f), SerializeField] private float scrollSpeed;

        private void Awake()
        {
            enterGameBtn.onClick.AddListener(OnEnterGameEnter);
        }

        private void OnDestroy()
        {
            enterGameBtn.onClick.RemoveAllListeners();
        }

        private void OnEnterGameEnter()
        {
            stageController.ChangeGameplayStage();
        }

        private void Update()
        {
            ScrollEmojis();
        }

        private void ScrollEmojis()
        {
            var xOffset = 0.05f * scrollSpeed * Time.deltaTime;
            Rect rect = emojis.uvRect;
            rect.x += xOffset;
            emojis.uvRect = rect;
        }

        public async UniTask InitStage()
        {
        }

        public async UniTask EnterStage()
        {
        }

        public UniTask ExitStage()
        {
            stageController.ScrollSweatyBean();
            DOTween.To(value => { transform.localPosition = new Vector3(value, 0, 0); },
                0f, 2300f, 0.8f);
            return default;
        }
    }
}