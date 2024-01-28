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
        [SerializeField] private GameObject enterGameGo;
        [Range(0f, 0.5f), SerializeField] private float scrollSpeed;

        private void Awake()
        {
            enterGameBtn.onClick.AddListener(OnEnterBtnClick);
        }

        private void OnDestroy()
        {
            enterGameBtn.onClick.RemoveAllListeners();
        }

        private void OnEnterBtnClick()
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

        // ReSharper disable Unity.PerformanceAnalysis
        public async UniTask EnterStage()
        {
            // await DOTween.To(value => { emojis.transform.localPosition = new Vector3(value, value, 0); },
            //     -3100, 0, 0.8f).SetEase(Ease.InQuad);
            stageController.gameOverStage.RemoveInstantiateGo();
            emojis.transform.localPosition = new Vector3(-3100, 3100, 0);
            enterGameGo.transform.localPosition = new Vector3(-720, -600, 0);
            await transform.DOLocalMove(new Vector3(0, 0, 0), 0.2f).ToUniTask();
            await emojis.transform.DOLocalMove(new Vector3(0, 0, 0), 0.8f).SetEase(Ease.InQuad).ToUniTask();
            if (stageController.isQuart) await stageController.ScrollQuartReset();
            await DOTween.To(value => { enterGameGo.transform.localPosition = new Vector3(-720, value, 0); },
                -600, -303, 0.8f).SetEase(Ease.OutBounce).ToUniTask();
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