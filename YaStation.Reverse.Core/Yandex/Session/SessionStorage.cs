using System;

namespace YaStation.Reverse.Core.Yandex.Session
{
    public class SessionStorage : ISessionStorage
    {
        private readonly string _path;

        public SessionStorage(string path)
        {
            _path = path;
        }
        
        public ISession Get()
        {
            throw new NotImplementedException();
        }

        public void Save(ISession session)
        {
            throw new NotImplementedException();
        }
    }
}