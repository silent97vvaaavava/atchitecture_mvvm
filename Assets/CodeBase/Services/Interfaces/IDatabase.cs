using System;
using System.Threading.Tasks;
using CodeBase.Domain;

namespace CodeBase.Services.Interfaces
{
    public interface IDatabase
    {
        void Save<TDto>(TDto dto) where TDto : class, IDto;
        bool TrySave<TDto>(TDto dto) where TDto : class, IDto;
        Task SaveAsync<TDto>(TDto dto, IProgress<int> progress = null) where TDto : class, IDto;
        
        void Load();
        bool TryLoad();
        Task LoadAsync(IProgress<int> progress = null);
    }
}