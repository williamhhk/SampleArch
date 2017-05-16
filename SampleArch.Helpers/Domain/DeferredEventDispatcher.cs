using Autofac;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SampleArch.Helpers.Domain
{
    public class DeferredEventDispatcher : IEventDispatcher
    {
        private readonly ConcurrentQueue<Action> _pendingHandlers = new ConcurrentQueue<Action>();
        private readonly IDbStateTracker _dbState;

        private readonly IContainer _container;

        public DeferredEventDispatcher(IContainer kernel, IDbStateTracker dbState)
        {
            _container = kernel;
            _dbState = dbState;

            _dbState.TransactionComplete += this.Flush;
            _dbState.Disposing += this.FlushOrClear;
        }


        public void Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent
        {
            foreach (var handler in _container.Resolve<IEnumerable<IDomainHandler<TEvent>>>())
            {
                handler.Handle(eventToDispatch);
            }


            //if (allHandlers != null && allHandlers.Length > 0)
            //{
            //    IHandles<T>[] handlersToEnqueue = null;
            //    IHandles<T>[] handlersToFire = allHandlers;

            //    if (_dbState.HasPendingChanges())
            //    {
            //        handlersToEnqueue = allHandlers.Where(h => h.Deferred).ToArray();

            //        if (handlersToEnqueue.Length > 0)
            //        {
            //            lock (_pendingHandlers)
            //                foreach (var handler in handlersToEnqueue)
            //                    _pendingHandlers.Enqueue(() => handler.Handle(domainEvent));

            //            handlersToFire = allHandlers.Except(handlersToEnqueue).ToArray();
            //        }
            //    }

            //    foreach (var handler in handlersToFire)
            //        handler.Handle(domainEvent);
            //}
        }

        private void Flush()
        {
            Action dispatch;
            lock (_pendingHandlers)
                while (_pendingHandlers.TryDequeue(out dispatch))
                    dispatch();
        }


        private void FlushOrClear()
        {
            if (!_dbState.HasPendingChanges())
                Flush();
            else
            {
                Clear();
            }
        }

        private void Clear()
        {
            Action dispatch;
            lock (_pendingHandlers)
                while (_pendingHandlers.TryDequeue(out dispatch)) ;
        }

    }
}
