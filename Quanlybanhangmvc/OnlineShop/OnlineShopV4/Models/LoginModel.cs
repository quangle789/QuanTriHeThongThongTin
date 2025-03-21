﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopV4.Models
{
    public class LoginModel
    {   
        [Key]

        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage ="Bạn phải nhập tài khoản")]
        public string Username { get; set; }
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string PassWord { get; set; }
    }
}