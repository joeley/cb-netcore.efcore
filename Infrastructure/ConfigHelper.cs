﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure
{
    /*
     * .net core 获取配置文件
     * */
    public static class ConfigHelper
    {
        private static IConfiguration _configuration;

        static ConfigHelper()
        {
            //在当前目录或者根目录中寻找appsettings.json文件
            var fileName = "appsettings.json";

            var directory = AppContext.BaseDirectory;
            directory = directory.Replace("\\", "/");

            var filePath = $"{directory}/{fileName}";
            if (!File.Exists(filePath))
            {
                var length = directory.IndexOf("/bin");
                filePath = $"{directory.Substring(0, length)}/{fileName}";
            }

            var builder = new ConfigurationBuilder()
                .AddJsonFile(filePath, false, true);

            _configuration = builder.Build();
        }

        /// <summary>
        /// 获取config
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSectionValue(string key)
        {
            return _configuration.GetSection(key).Value;
        }
    }
}
