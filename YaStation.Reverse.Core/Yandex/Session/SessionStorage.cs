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
                return new Session();

            var content = File.ReadAllText(_path);
            return string.IsNullOrEmpty(content) 
                ? new Session() 
                : JsonSerializer.Deserialize<Session>(content);
        }

        public void Save(ISession session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));
            
            var sessionContent = JsonSerializer.Serialize(session);
            
            File.WriteAllText(_path, sessionContent);
        }

        public void Clear()
        {
            if (!File.Exists(Path.GetFullPath(_path)))
                return;
            
            File.Delete(_path);
        }
    }
}