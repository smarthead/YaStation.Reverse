using System;
using System.IO;
using System.Text.Json;

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
            if (!File.Exists(_path))
                return null;

            var content = File.ReadAllText(_path);
            return string.IsNullOrEmpty(content) 
                ? null 
                : JsonSerializer.Deserialize<Session>(content);
        }

        public void Save(ISession session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));
            
            var sessionContent = JsonSerializer.Serialize(session);
            
            File.WriteAllText(_path, sessionContent);
        }
    }
}