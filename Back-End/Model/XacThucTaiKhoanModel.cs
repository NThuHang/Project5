using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class XacThucTaiKhoanModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
