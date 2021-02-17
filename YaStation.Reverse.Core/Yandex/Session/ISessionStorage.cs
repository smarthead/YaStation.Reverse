namespace YaStation.Reverse.Core.Yandex.Session
{
    public interface ISessionStorage
    {
        public ISession Get();
        public void Save(ISession session);
    }
}