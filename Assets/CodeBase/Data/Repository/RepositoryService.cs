using System;
using System.Collections.Generic;
using CodeBase.Domain;

namespace CodeBase.Data
{
    public class RepositoryService
    {
        private Dictionary<Type, IDto> _datas;

        public int Count => _datas.Count;
        
        public RepositoryService()
        {
            _datas = new Dictionary<Type, IDto>()
            {
                [typeof(CurrencyDto)] = new CurrencyDto(),
            };
        }

        public TDto GetData<TDto>()
            where TDto : class, IDto
        {
            if (_datas.TryGetValue(typeof(TDto), out var data))
                return data as TDto;
            else
                return null;
        }

        public bool TryChangeValue<TDto>(TDto value)
            where TDto : class, IDto
        {
            Type key = typeof(TDto);
            if (_datas.ContainsKey(key))
            {
                _datas[key] = value;
                return true;
            }
            else
                return false;
        }
    }
}