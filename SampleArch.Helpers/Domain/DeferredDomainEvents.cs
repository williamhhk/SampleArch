using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleArch.Helpers.Domain
{
    public interface IDbStateTracker : IDisposable
    {
        ///
        /// Triggered when disposing
        /// 

        event Action Disposing;

        ///
        /// Triggered when the transaction is completed
        /// 

        event Action TransactionComplete;

        ///
        /// Returns true if there are uncommitted pending changes. Otherwise, returns false.
        /// 

        bool HasPendingChanges();
    }

    public static class DeferredDomainEvents
    {
        public static IEventDispatcher Dispatcher { get; set; }

        public static void Raise<T>(T @event) where T : IDomainEvent
        {
            Dispatcher.Dispatch(@event);
        }

    }
}
