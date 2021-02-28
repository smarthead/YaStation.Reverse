using System.Net;
using Xunit;
using YaStation.Reverse.Core.Yandex.Session;

namespace YaStation.Reverse.Core.Tests.Yandex.Session
{
    public class SessionStorageTests
    {
        private const string EmptyFile = "./empty.session";
        private const string NewFile = "./new.session";

        [Fact]
        public void SessionStorage_Get_Should_Return_Null_For_Empty_File()
        {
            var sessionStorage = new SessionStorage(EmptyFile);
            var session = sessionStorage.Get();
            
            Assert.Null(session);
        }
        
        [Fact]
        public void SessionStorage_Save_Should_Save_Cookies_In_File()
        {
            var sessionStorage = new SessionStorage(NewFile);
            var expected = new Core.Yandex.Session.Session
            {
                XToken = "MY_STRONG_SECRET_TOKEN",
                Cookies = new CookieCollection
                {
                    new Cookie("cookie", "value"),
                    new Cookie("cookie", "value", "domain")
                }
            };
            
            sessionStorage.Save(expected);

            var actual = sessionStorage.Get();
            
            Assert.Equal(expected.XToken, actual.XToken);
            Assert.Equal(expected.Cookies, actual.Cookies);
        }
    }
}