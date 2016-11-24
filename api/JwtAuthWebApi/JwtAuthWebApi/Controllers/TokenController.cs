using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Jose;

namespace JwtAuthWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TokenController : ApiController
    {
        // POST api/values
        public object Post(LoginData loginData)
        {
            // TODO: key應該移至config
            var secret = "wellwindJtwDemo";

            // TODO: 真實世界檢查帳號密碼
            if (loginData.Username == "wellwind" && loginData.Password == "1234")
            {
                var payload = new JwtAuthObject()
                {
                    Id = "wellwind"
                };

                return new
                {
                    Result = true,
                    token = Jose.JWT.Encode(payload, Encoding.UTF8.GetBytes(secret), JwsAlgorithm.HS256)
                };
            }
            else
            {
                throw new UnauthorizedAccessException("帳號密碼錯誤");
            }
        }
    }
}