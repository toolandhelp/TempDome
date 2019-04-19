using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tool.Calendar.Api.AuthHelper;
using Tool.Calendar.IServices;
using Tool.Calendar.Models.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tool.Calendar.Api.Controllers
{
    [Route("api/[controller]")]
    public class WebUserController : ControllerBase
    {
        private readonly IT_WebUserService webUserService;
        // GET: api/<controller>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
     //   [Authorize(Roles = "SystemOrAdmin")]
        public string Get(int id)
        {
            TokenModelJwt tokenModel = new TokenModelJwt { Uid = 1, Role = "Admin" };
            string token = JwtHelper.IssueJwt(tokenModel);//登录，获取到一定规则的 Token 令牌
            return "value"+ token;
        }


        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]T_WebUser userInfo)
        {
            try
            {
                bool flag = false;
                string jwtStr = string.Empty;
                if (!string.IsNullOrEmpty(userInfo.UserMail) || !string.IsNullOrEmpty(userInfo.UserPwd))
                {
                    //userInfo.uPassWord = CryptographyHelper.DESEncrypt(userInfo.uPassWord, encryptionKey, encryptionIv);//加密
                    var userinfo = await webUserService.Query(u => u.UserMail == userInfo.UserMail && u.UserPwd == userInfo.UserPwd);

                    //if (userinfo.Count > 0)
                    //{
                    //    HttpContext.Session.SetString("UserName", userInfo.uUserName);
                    //    flag = 1;
                    //}

                    TokenModelJwt tokenModel = new TokenModelJwt { Uid = 1, Role = userInfo.UserMail };
                    jwtStr = JwtHelper.IssueJwt(tokenModel);//登录，获取到一定规则的 Token 令牌
                    flag = true;
                }
                else
                {
                    jwtStr = "login fail!!!";
                }
                return Ok(new
                {
                    success = flag,

                    token = jwtStr
                });
            }
            catch (Exception ex)
            {
                // loggerHelper.Error("UserInfoesController.Login", "异常位置：UserInfoesController.Login" + "异常消息：" + ex.Message);
                return Ok(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

    }
}
