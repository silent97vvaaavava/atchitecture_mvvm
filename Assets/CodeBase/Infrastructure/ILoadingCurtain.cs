using System;

namespace CodeBase.Infrastructure
{
    public interface ILoadingCurtain
    {
        IProgress<int> Progress { get; }
        
        void Show();
        void UpdateProgress(int percentage);
        void Hide();
    }
}