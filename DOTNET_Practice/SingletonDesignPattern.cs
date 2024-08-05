using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_Practice
{
    sealed class SingletonDesignPattern
    {
        public int Id { get; private set; }
        private SingletonDesignPattern(int id)
        {
            this.Id = id;
        }
        private static SingletonDesignPattern _instance;
        private static readonly object _lock = new object();
        public static SingletonDesignPattern Instance(int id)
        {
            if (_instance == null)
            {
                lock(_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new SingletonDesignPattern(id);
                    }
                }
            }
            return _instance;
        }
    }
}
