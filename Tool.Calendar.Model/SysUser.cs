using System;
using System.Collections.Generic;

namespace Tool.Calendar.Model
{
    public partial class SysUser
    {
        public int UserId { get; set; }
        public string UserGuid { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string UserKey { get; set; }
        public DateTime? UserCreateDate { get; set; }
    }
}
