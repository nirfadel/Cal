using CalApiProject.BLL;
using CalApiProject.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;

namespace CalApiProject
{
    public class CalApiController : ApiController
    {
        private IUserRepository userRepository = null;

        public CalApiController()
        {
            userRepository = new UserRepository();
        }

        public IHttpActionResult Authorize()
        {
            return Ok("Authorized");
        }

        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login(User user)
        {
            string baseAddress = "http://localhost:19117";
            using (var client = new HttpClient())
            {
                var form = new Dictionary<string, string>
                {
                   {"grant_type", "password"},
                   {"username", user.Email},
                   {"password", user.Password},
                };
                try
                {
                    var tokenResponse = client.PostAsync(baseAddress + "/token", new FormUrlEncodedContent(form)).Result;
                    var token = tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
                    if (string.IsNullOrEmpty(token.Error))
                    {
                        ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
                        var claims = principal.Claims.Select(x => new { type = x.Type, value = x.Value });
                        return Ok("User " + user.Email + " logged in.");
                    }
                    else
                    {
                        var myError = new Error
                        {
                            Code = "1001",
                            Message = token.Error
                        };
                        return new ErrorResult(myError, Request);
                    }
                }
                catch (Exception ex)
                {
                    var myError = new Error
                    {
                        Code = "1000",
                        Message = ex.Message
                    };
                    return new ErrorResult(myError, Request);
                }
            }
        }

        [Authorize]
        [Route("api/GetData")]
        [HttpGet]
        public IHttpActionResult GetData()
        {
            var email = ((ClaimsIdentity)User.Identity).FindFirst("Email");
            UserMock userMock = new UserMock();
            var _user = userMock.GetUsers().Where(u => u.Email.Equals(email.Value)).Select(x=> new { userid = x.UserId, username = x.Name, email = x.Email, role = x.Role }).FirstOrDefault();
            if(_user != null)
            {
                return Ok("User details: " + JsonConvert.SerializeObject(_user));
            }

            return BadRequest();
        }
    }
}