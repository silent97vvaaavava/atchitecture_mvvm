using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Helpers;
using CodeBase.Services.Interfaces;
using CodeBase.StaticData;

namespace CodeBase.Services
{
    public class DatabaseService 
    {
        private readonly IInternetReachability _internetReachability;
        private readonly Dictionary<TableType, DatabaseTable> _tables;
        private RepositoryService _repository;

        public DatabaseService(IInternetReachability internetReachability)
        {
            _internetReachability = internetReachability;
            _repository  = new RepositoryService();
        }

        public void Subscribe(IStored storedElement)
        {
            
        }
    }
} 
