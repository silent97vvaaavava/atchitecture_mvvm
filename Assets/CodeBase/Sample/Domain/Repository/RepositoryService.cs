using System;
using System.Collections.Generic;
using CodeBase.Core.Data.Dto;
using CodeBase.Sample.Data.Dto;

namespace CodeBase.Sample.Domain.Repository
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

        public TData Get<TData>()
            where TData : class, IDto
        {
            if (_datas.TryGetValue(typeof(TData), out var data))
                return data as TData;
            else
                return null;
        }

        public bool TryChangeValue<TData>(TData value)
            where TData : class, IDto
        {
            Type key = typeof(TData);
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