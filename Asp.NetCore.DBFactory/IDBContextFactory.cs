using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.DBFactory
{
    public interface IDBContextFactory
    {
        /// <summary>
        /// 创建一个新的DBContext
        /// </summary>
        /// <returns></returns>
        DBContextFactory CreateContext();
    }
}
