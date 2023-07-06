﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*--------脚本描述-----------
				
电子邮箱：
	1607388033@qq.com
作者:
	暗沉
描述:
	核心模块初始化

-----------------------*/


namespace ACFrameworkCore
{
    public interface ICoreComponent
    {
        /// <summary>
        /// 核心初始化
        /// </summary>
        public void OnCroeComponentInit();
    }
}