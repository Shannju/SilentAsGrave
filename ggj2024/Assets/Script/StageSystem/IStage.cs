using Cysharp.Threading.Tasks;

namespace Script.StageSystem
{
    public interface IStage
    {
        public UniTask InitStage();
        public UniTask EnterStage();
        public UniTask ExitStage();
    }
}