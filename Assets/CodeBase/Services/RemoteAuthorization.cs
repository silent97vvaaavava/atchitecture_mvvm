using System;
using System.Collections.Generic;
using CodeBase.Services.Interfaces;

namespace CodeBase.Services
{
    public class RemoteAuthorization
    {
        private readonly Dictionary<Type, IAuthorization> _services;
    }
}