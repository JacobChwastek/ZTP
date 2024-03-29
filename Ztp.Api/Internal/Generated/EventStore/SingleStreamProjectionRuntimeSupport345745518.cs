// <auto-generated/>
#pragma warning disable
using Marten;
using Marten.Events.Aggregation;
using Marten.Internal.Storage;
using System;
using System.Linq;

namespace Marten.Generated.EventStore
{
    // START: SingleStreamProjectionLiveAggregation345745518
    public class SingleStreamProjectionLiveAggregation345745518 : Marten.Events.Aggregation.SyncLiveAggregatorBase<Ztp.Domain.Customers.Customer>
    {
        private readonly Marten.Events.Aggregation.SingleStreamProjection<Ztp.Domain.Customers.Customer> _singleStreamProjection;

        public SingleStreamProjectionLiveAggregation345745518(Marten.Events.Aggregation.SingleStreamProjection<Ztp.Domain.Customers.Customer> singleStreamProjection)
        {
            _singleStreamProjection = singleStreamProjection;
        }


        public System.Func<Ztp.Domain.Customers.Customer> AggregateBuilder {get; set;}

        public System.Action<Ztp.Domain.Customers.Customer, Ztp.Domain.Contracts.v0.Customers.Events.CustomerAdded> Lambda1 {get; set;}


        public override Ztp.Domain.Customers.Customer Build(System.Collections.Generic.IReadOnlyList<Marten.Events.IEvent> events, Marten.IQuerySession session, Ztp.Domain.Customers.Customer snapshot)
        {
            if (!events.Any()) return null;
            Ztp.Domain.Customers.Customer customer = null;
            var usedEventOnCreate = snapshot is null;
            snapshot ??= Create(events[0], session);;
            if (snapshot is null)
            {
                usedEventOnCreate = false;
                snapshot = CreateDefault(events[0]);
            }

            foreach (var @event in events.Skip(usedEventOnCreate ? 1 : 0))
            {
                snapshot = Apply(@event, snapshot, session);
            }

            return snapshot;
        }


        public Ztp.Domain.Customers.Customer Create(Marten.Events.IEvent @event, Marten.IQuerySession session)
        {
            return null;
        }


        public Ztp.Domain.Customers.Customer CreateDefault(Marten.Events.IEvent @event)
        {
            return AggregateBuilder();
        }


        public Ztp.Domain.Customers.Customer Apply(Marten.Events.IEvent @event, Ztp.Domain.Customers.Customer aggregate, Marten.IQuerySession session)
        {
            switch (@event)
            {
                case Marten.Events.IEvent<Ztp.Domain.Contracts.v0.Customers.Events.CustomerAdded> event_CustomerAdded1:
                    Lambda1.Invoke(aggregate, event_CustomerAdded1.Data);
                    break;
            }

            return aggregate;
        }

    }

    // END: SingleStreamProjectionLiveAggregation345745518
    
    
    // START: SingleStreamProjectionInlineHandler345745518
    public class SingleStreamProjectionInlineHandler345745518 : Marten.Events.Aggregation.AggregationRuntime<Ztp.Domain.Customers.Customer, System.Guid>
    {
        private readonly Marten.IDocumentStore _store;
        private readonly Marten.Events.Aggregation.IAggregateProjection _projection;
        private readonly Marten.Events.Aggregation.IEventSlicer<Ztp.Domain.Customers.Customer, System.Guid> _slicer;
        private readonly Marten.Internal.Storage.IDocumentStorage<Ztp.Domain.Customers.Customer, System.Guid> _storage;
        private readonly Marten.Events.Aggregation.SingleStreamProjection<Ztp.Domain.Customers.Customer> _singleStreamProjection;

        public SingleStreamProjectionInlineHandler345745518(Marten.IDocumentStore store, Marten.Events.Aggregation.IAggregateProjection projection, Marten.Events.Aggregation.IEventSlicer<Ztp.Domain.Customers.Customer, System.Guid> slicer, Marten.Internal.Storage.IDocumentStorage<Ztp.Domain.Customers.Customer, System.Guid> storage, Marten.Events.Aggregation.SingleStreamProjection<Ztp.Domain.Customers.Customer> singleStreamProjection) : base(store, projection, slicer, storage)
        {
            _store = store;
            _projection = projection;
            _slicer = slicer;
            _storage = storage;
            _singleStreamProjection = singleStreamProjection;
        }


        public System.Func<Ztp.Domain.Customers.Customer> AggregateBuilder {get; set;}

        public System.Action<Ztp.Domain.Customers.Customer, Ztp.Domain.Contracts.v0.Customers.Events.CustomerAdded> Lambda1 {get; set;}


        public override async System.Threading.Tasks.ValueTask<Ztp.Domain.Customers.Customer> ApplyEvent(Marten.IQuerySession session, Marten.Events.Projections.EventSlice<Ztp.Domain.Customers.Customer, System.Guid> slice, Marten.Events.IEvent evt, Ztp.Domain.Customers.Customer aggregate, System.Threading.CancellationToken cancellationToken)
        {
            switch (evt)
            {
                case Marten.Events.IEvent<Ztp.Domain.Contracts.v0.Customers.Events.CustomerAdded> event_CustomerAdded2:
                    aggregate ??= AggregateBuilder();
                    Lambda1.Invoke(aggregate, event_CustomerAdded2.Data);
                    return aggregate;
            }

            return aggregate;
        }


        public Ztp.Domain.Customers.Customer Create(Marten.Events.IEvent @event, Marten.IQuerySession session)
        {
            return null;
        }


        public Ztp.Domain.Customers.Customer CreateDefault(Marten.Events.IEvent @event)
        {
            return AggregateBuilder();
        }

    }

    // END: SingleStreamProjectionInlineHandler345745518
    
    
}

