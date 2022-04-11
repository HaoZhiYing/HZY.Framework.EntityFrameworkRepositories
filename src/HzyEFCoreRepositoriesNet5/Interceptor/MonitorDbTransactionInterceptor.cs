﻿using HzyEFCoreRepositories.Monitor;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HzyEFCoreRepositories.Interceptor
{
    /// <summary>
    /// 监控数据库事务信息
    /// Efcore 拦截监控文档: https://docs.microsoft.com/en-us/ef/core/logging-events-diagnostics/interceptors
    /// </summary>
    public class MonitorDbTransactionInterceptor : DbTransactionInterceptor
    {
        /// <summary>
        /// RolledBackToSavepoint
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="eventData"></param>
        public override void RolledBackToSavepoint(DbTransaction transaction, TransactionEventData eventData)
        {
            MonitorEFCoreCache.RollBackCount();
            base.RolledBackToSavepoint(transaction, eventData);
        }

        /// <summary>
        /// RolledBackToSavepointAsync
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="eventData"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task RolledBackToSavepointAsync(DbTransaction transaction, TransactionEventData eventData, CancellationToken cancellationToken = default)
        {
            MonitorEFCoreCache.RollBackCount();
            return base.RolledBackToSavepointAsync(transaction, eventData, cancellationToken);
        }

        /// <summary>
        /// TransactionCommitted
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="eventData"></param>
        public override void TransactionCommitted(DbTransaction transaction, TransactionEndEventData eventData)
        {
            MonitorEFCoreCache.SubmitTransactionCount();
            base.TransactionCommitted(transaction, eventData);
        }

        /// <summary>
        /// TransactionCommittedAsync
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="eventData"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task TransactionCommittedAsync(DbTransaction transaction, TransactionEndEventData eventData, CancellationToken cancellationToken = default)
        {
            MonitorEFCoreCache.SubmitTransactionCount();
            return base.TransactionCommittedAsync(transaction, eventData, cancellationToken);
        }

        /// <summary>
        /// TransactionFailed
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="eventData"></param>
        public override void TransactionFailed(DbTransaction transaction, TransactionErrorEventData eventData)
        {
            MonitorEFCoreCache.TransactionFailedCount();
            base.TransactionFailed(transaction, eventData);
        }

        /// <summary>
        /// TransactionFailedAsync
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="eventData"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task TransactionFailedAsync(DbTransaction transaction, TransactionErrorEventData eventData, CancellationToken cancellationToken = default)
        {
            MonitorEFCoreCache.TransactionFailedCount();
            return base.TransactionFailedAsync(transaction, eventData, cancellationToken);
        }

        /// <summary>
        /// TransactionRolledBack
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="eventData"></param>
        public override void TransactionRolledBack(DbTransaction transaction, TransactionEndEventData eventData)
        {
            MonitorEFCoreCache.RollBackCount();
            base.TransactionRolledBack(transaction, eventData);
        }

        /// <summary>
        /// TransactionRolledBackAsync
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="eventData"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task TransactionRolledBackAsync(DbTransaction transaction, TransactionEndEventData eventData, CancellationToken cancellationToken = default)
        {
            MonitorEFCoreCache.RollBackCount();
            return base.TransactionRolledBackAsync(transaction, eventData, cancellationToken);
        }

        /// <summary>
        /// TransactionStarted
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override DbTransaction TransactionStarted(DbConnection connection, TransactionEndEventData eventData, DbTransaction result)
        {
            MonitorEFCoreCache.CreateTransactionCount();
            return base.TransactionStarted(connection, eventData, result);
        }

        /// <summary>
        /// TransactionStartedAsync
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override ValueTask<DbTransaction> TransactionStartedAsync(DbConnection connection, TransactionEndEventData eventData, DbTransaction result, CancellationToken cancellationToken = default)
        {
            MonitorEFCoreCache.CreateTransactionCount();
            return base.TransactionStartedAsync(connection, eventData, result, cancellationToken);
        }


    }
}
