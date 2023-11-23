using System;
using System.Threading.Tasks;
using CodeBase.Data;
using CodeBase.Helpers;

namespace CodeBase.Services
{
    public class DatabaseService 
    {
        private readonly IInternetReachability _internetReachability;
        private RepositoryService _repository;
        
        public DatabaseService(IInternetReachability internetReachability)
        {
            _internetReachability = internetReachability;
            _repository  = new RepositoryService();
        }
    }
} 
