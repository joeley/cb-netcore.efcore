using Asp.NetCore.Model.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace Asp.NetCore.DBFactory
{
    public class DBContextFactory : DbContext, IDBContextFactory
    {
        private string strConn = null;

        /// <summary>
        /// 索引直接把字符串传进来
        /// </summary>
        /// <param name="writeAndReadEnum"></param>
        public DBContextFactory(string conn)
        {
            this.strConn = conn;
        }

        /// <summary>
        /// 构造函数不传参数时，用配置文件中的连接
        /// </summary>
        public DBContextFactory()
        {
            this.strConn = ConfigHelper.GetSectionValue("SqlServerConn");
        }

        /// <summary>
        /// 构建新的DBContext
        /// </summary>
        /// <returns></returns>
        public DBContextFactory CreateContext()
        {
            return new DBContextFactory();
        }

        /// <summary>
        /// 配置连接数据库 
        /// 数据库连接
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Nuget引入：Microsoft.EntityFrameworkCore.SqlServer
            ///SqlServer
            optionsBuilder.UseSqlServer(strConn);//数据库连接 
        }

        /// <summary>
        /// 配置数据库结构，关系映射
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///初始化数据库表数据，
            ///自定义表和表的关联关系
        }


        #region 数据库表
        public DbSet<ContractT> ContractT { get; set; }
        public DbSet<MainMenuT> MainMenuT { get; set; }
        public DbSet<MaterialT> MaterialT { get; set; }
        public DbSet<ReceiveGroupT> ReceiveGroupT { get; set; }
        public DbSet<RememberKeyT> RememberKeyT { get; set; }
        public DbSet<RoleT> RoleT { get; set; }
        public DbSet<SecondMenuT> SecondMenuT { get; set; }
        public DbSet<SendCarT> SendCarT { get; set; }
        public DbSet<SendGroupT> SendGroupT { get; set; }
        public DbSet<UserPageT> UserPageT { get; set; }
        public DbSet<UserT> UserT { get; set; }
        #endregion
    }
}
