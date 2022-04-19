﻿/*
 * *******************************************************
 *
 * 作者：hzy
 *
 * 开源地址：https://gitee.com/hzy6
 *
 * *******************************************************
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Threading.Tasks;

namespace HzyEFCoreRepositories.Repositories
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public interface IUnitOfWork<TBaseDbContext>
        where TBaseDbContext : DbContext
    {
        /// <summary>
        /// 获取保存状态
        /// </summary>
        /// <returns></returns>
        bool GetDelaySaveState();

        /// <summary>
        /// 设置保存状态
        /// </summary>
        /// <param name="saveSate"></param>
        void SetDelaySaveState(bool saveSate);

        /// <summary>
        /// 打开延迟提交
        /// </summary>
        void CommitDelayStart();

        /// <summary>
        /// 延迟提交结束
        /// </summary>
        /// <returns></returns>
        int CommitDelayEnd();

        /// <summary>
        /// 延迟提交结束
        /// </summary>
        /// <returns></returns>
        Task<int> CommitEndAsync();

        /// <summary>
        /// 开始事务
        /// </summary>
        /// <returns></returns>
        IDbContextTransaction BeginTransaction();

        /// <summary>
        /// 开始事务
        /// </summary>
        /// <returns></returns>
        Task<IDbContextTransaction> BeginTransactionAsync();

        /// <summary>
        /// 获取当前上下文事务
        /// </summary>
        IDbContextTransaction CurrentDbContextTransaction => default;

        /// <summary>
        /// 获取当前事务
        /// </summary>
        IDbTransaction CurrentDbTransaction => default;

        /// <summary>
        /// 获取当前 事务 根据 IDbContextTransaction 事务
        /// </summary>
        /// <param name="dbContextTransaction"></param>
        /// <returns></returns>
        IDbTransaction GetDbTransaction(IDbContextTransaction dbContextTransaction);

    }
}

