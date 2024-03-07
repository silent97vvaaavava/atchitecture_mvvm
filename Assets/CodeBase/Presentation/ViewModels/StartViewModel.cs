using CodeBase.Infrastructure;

namespace CodeBase.Presentation.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        private readonly IGameFsm _gameFsm;

        public StartViewModel(IWindowFsm windowFsm, IGameFsm gameFsm) : base(windowFsm)
        {
            _gameFsm = gameFsm;
        }

        public override void InvokeOpen()
        {
            _gameFsm.Enter<LoaderState>();
        }

        public override void InvokeClose()
        {
            
        }
    }
}