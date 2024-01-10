// <auto-generated/>
#pragma warning disable
using Marten;
using Marten.Events.Aggregation;
using Marten.Internal.Storage;
using System;
using System.Linq;

namespace Marten.Generated.EventStore
{
    // START: SingleStreamProjectionLiveAggregation1597856106
    public class SingleStreamProjectionLiveAggregation1597856106 : Marten.Events.Aggregation.SyncLiveAggregatorBase<Ztp.Domain.Products.Product>
    {
        private readonly Marten.Events.Aggregation.SingleStreamProjection<Ztp.Domain.Products.Product> _singleStreamProjection;

        public SingleStreamProjectionLiveAggregation1597856106(Marten.Events.Aggregation.SingleStreamProjection<Ztp.Domain.Products.Product> singleStreamProjection)
        {
            _singleStreamProjection = singleStreamProjection;
        }



        public override Ztp.Domain.Products.Product Build(System.Collections.Generic.IReadOnlyList<Marten.Events.IEvent> events, Marten.IQuerySession session, Ztp.Domain.Products.Product snapshot)
        {
            if (!events.Any()) return null;
            Ztp.Domain.Products.Product product = null;
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


        public Ztp.Domain.Products.Product Create(Marten.Events.IEvent @event, Marten.IQuerySession session)
        {
            return null;
        }


        public Ztp.Domain.Products.Product CreateDefault(Marten.Events.IEvent @event)
        {
            return new Ztp.Domain.Products.Product();
        }


        public Ztp.Domain.Products.Product Apply(Marten.Events.IEvent @event, Ztp.Domain.Products.Product aggregate, Marten.IQuerySession session)
        {
            switch (@event)
            {
                case Marten.Events.IEvent<Ztp.Domain.Products.Events.ProductCreated> event_ProductCreated7:
                    aggregate.Apply(event_ProductCreated7.Data);
                    break;
                case Marten.Events.IEvent<Ztp.Domain.Products.Events.ProductUpdated> event_ProductUpdated8:
                    aggregate.Apply(event_ProductUpdated8.Data);
                    break;
            }

            return aggregate;
        }

    }

    // END: SingleStreamProjectionLiveAggregation1597856106
    
    
    // START: SingleStreamProjectionInlineHandler1597856106
    public class SingleStreamProjectionInlineHandler1597856106 : Marten.Events.Aggregation.AggregationRuntime<Ztp.Domain.Products.Product, System.Guid>
    {
        private readonly Marten.IDocumentStore _store;
        private readonly Marten.Events.Aggregation.IAggregateProjection _projection;
        private readonly Marten.Events.Aggregation.IEventSlicer<Ztp.Domain.Products.Product, System.Guid> _slicer;
        private readonly Marten.Internal.Storage.IDocumentStorage<Ztp.Domain.Products.Product, System.Guid> _storage;
        private readonly Marten.Events.Aggregation.SingleStreamProjection<Ztp.Domain.Products.Product> _singleStreamProjection;

        public SingleStreamProjectionInlineHandler1597856106(Marten.IDocumentStore store, Marten.Events.Aggregation.IAggregateProjection projection, Marten.Events.Aggregation.IEventSlicer<Ztp.Domain.Products.Product, System.Guid> slicer, Marten.Internal.Storage.IDocumentStorage<Ztp.Domain.Products.Product, System.Guid> storage, Marten.Events.Aggregation.SingleStreamProjection<Ztp.Domain.Products.Product> singleStreamProjection) : base(store, projection, slicer, storage)
        {
            _store = store;
            _projection = projection;
            _slicer = slicer;
            _storage = storage;
            _singleStreamProjection = singleStreamProjection;
        }



        public override async System.Threading.Tasks.ValueTask<Ztp.Domain.Products.Product> ApplyEvent(Marten.IQuerySession session, Marten.Events.Projections.EventSlice<Ztp.Domain.Products.Product, System.Guid> slice, Marten.Events.IEvent evt, Ztp.Domain.Products.Product aggregate, System.Threading.CancellationToken cancellationToken)
        {
            switch (evt)
            {
                case Marten.Events.IEvent<Ztp.Domain.Products.Events.ProductCreated> event_ProductCreated9:
                    aggregate ??= new Ztp.Domain.Products.Product();
                    aggregate.Apply(event_ProductCreated9.Data);
                    return aggregate;
                case Marten.Events.IEvent<Ztp.Domain.Products.Events.ProductUpdated> event_ProductUpdated10:
                    aggregate ??= new Ztp.Domain.Products.Product();
                    aggregate.Apply(event_ProductUpdated10.Data);
                    return aggregate;
            }

            return aggregate;
        }


        public Ztp.Domain.Products.Product Create(Marten.Events.IEvent @event, Marten.IQuerySession session)
        {
            return null;
        }


        public Ztp.Domain.Products.Product CreateDefault(Marten.Events.IEvent @event)
        {
            return new Ztp.Domain.Products.Product();
        }

    }

    // END: SingleStreamProjectionInlineHandler1597856106
    
    
}

