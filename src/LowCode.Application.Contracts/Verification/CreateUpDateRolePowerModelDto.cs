﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace LowCode.Verification
{
    public class CreateUpDateRolePowerModelDto
    {
        /// <summary>
        /// 角色权限Id
        /// </summary>
        //  public int RolePowerId { get; set; }
        /// <summary>
        /// 角色Id
        /// </summary>
        [Required]
        public int RoleId { get; set; }
        /// <summary>
        /// 权限Id
        /// </summary>
        [Required]
        public int PowerId { get; set; }
    }
}
