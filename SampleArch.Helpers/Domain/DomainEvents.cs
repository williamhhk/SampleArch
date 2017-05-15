

using Autofac;

namespace SampleArch.Helpers.Domain
{
    public static class DomainEvents
    {
        public static IEventDispatcher Dispatcher { get; set; }

        public static void Raise<T>(T @event) where T : IDomainEvent
        {
            Dispatcher.Dispatch(@event);
        }

    }
}
