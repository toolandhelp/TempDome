using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tool.Calendar.Models.Models
{
   public class T_WebUser
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int UserId { get; set; }
        /// <summary>
        /// Guid主键
        /// </summary>
        public Guid UserGuid { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string UserMail { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPwd { get; set; }
        /// <summary>
        /// 加密码
        /// </summary>
        public string EncryptCode { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDateTime { get; set; }


    }
}
