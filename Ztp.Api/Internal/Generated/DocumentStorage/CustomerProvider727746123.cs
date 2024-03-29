// <auto-generated/>
#pragma warning disable
using Marten.Internal;
using Marten.Internal.Storage;
using Marten.Schema;
using Marten.Schema.Arguments;
using Npgsql;
using System;
using System.Collections.Generic;
using Weasel.Core;
using Weasel.Postgresql;
using Ztp.Domain.Customers;

namespace Marten.Generated.DocumentStorage
{
    // START: UpsertCustomerOperation727746123
    public class UpsertCustomerOperation727746123 : Marten.Internal.Operations.StorageOperation<Ztp.Domain.Customers.Customer, System.Guid>
    {
        private readonly Ztp.Domain.Customers.Customer _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public UpsertCustomerOperation727746123(Ztp.Domain.Customers.Customer document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select public.mt_upsert_customer(?, ?, ?, ?)";


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
        }


        public override System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            // Nothing
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Upsert;
        }


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[2].Value = document.AggregateId;
            setVersionParameter(parameters[3]);
        }

    }

    // END: UpsertCustomerOperation727746123
    
    
    // START: InsertCustomerOperation727746123
    public class InsertCustomerOperation727746123 : Marten.Internal.Operations.StorageOperation<Ztp.Domain.Customers.Customer, System.Guid>
    {
        private readonly Ztp.Domain.Customers.Customer _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public InsertCustomerOperation727746123(Ztp.Domain.Customers.Customer document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select public.mt_insert_customer(?, ?, ?, ?)";


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
        }


        public override System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            // Nothing
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Insert;
        }


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[2].Value = document.AggregateId;
            setVersionParameter(parameters[3]);
        }

    }

    // END: InsertCustomerOperation727746123
    
    
    // START: UpdateCustomerOperation727746123
    public class UpdateCustomerOperation727746123 : Marten.Internal.Operations.StorageOperation<Ztp.Domain.Customers.Customer, System.Guid>
    {
        private readonly Ztp.Domain.Customers.Customer _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public UpdateCustomerOperation727746123(Ztp.Domain.Customers.Customer document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select public.mt_update_customer(?, ?, ?, ?)";


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
            postprocessUpdate(reader, exceptions);
        }


        public override async System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            await postprocessUpdateAsync(reader, exceptions, token);
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Update;
        }


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[2].Value = document.AggregateId;
            setVersionParameter(parameters[3]);
        }

    }

    // END: UpdateCustomerOperation727746123
    
    
    // START: QueryOnlyCustomerSelector727746123
    public class QueryOnlyCustomerSelector727746123 : Marten.Internal.CodeGeneration.DocumentSelectorWithOnlySerializer, Marten.Linq.Selectors.ISelector<Ztp.Domain.Customers.Customer>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public QueryOnlyCustomerSelector727746123(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Ztp.Domain.Customers.Customer Resolve(System.Data.Common.DbDataReader reader)
        {

            Ztp.Domain.Customers.Customer document;
            document = _serializer.FromJson<Ztp.Domain.Customers.Customer>(reader, 0);
            return document;
        }


        public async System.Threading.Tasks.Task<Ztp.Domain.Customers.Customer> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {

            Ztp.Domain.Customers.Customer document;
            document = await _serializer.FromJsonAsync<Ztp.Domain.Customers.Customer>(reader, 0, token).ConfigureAwait(false);
            return document;
        }

    }

    // END: QueryOnlyCustomerSelector727746123
    
    
    // START: LightweightCustomerSelector727746123
    public class LightweightCustomerSelector727746123 : Marten.Internal.CodeGeneration.DocumentSelectorWithVersions<Ztp.Domain.Customers.Customer, System.Guid>, Marten.Linq.Selectors.ISelector<Ztp.Domain.Customers.Customer>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public LightweightCustomerSelector727746123(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Ztp.Domain.Customers.Customer Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);

            Ztp.Domain.Customers.Customer document;
            document = _serializer.FromJson<Ztp.Domain.Customers.Customer>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }


        public async System.Threading.Tasks.Task<Ztp.Domain.Customers.Customer> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);

            Ztp.Domain.Customers.Customer document;
            document = await _serializer.FromJsonAsync<Ztp.Domain.Customers.Customer>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }

    }

    // END: LightweightCustomerSelector727746123
    
    
    // START: IdentityMapCustomerSelector727746123
    public class IdentityMapCustomerSelector727746123 : Marten.Internal.CodeGeneration.DocumentSelectorWithIdentityMap<Ztp.Domain.Customers.Customer, System.Guid>, Marten.Linq.Selectors.ISelector<Ztp.Domain.Customers.Customer>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public IdentityMapCustomerSelector727746123(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Ztp.Domain.Customers.Customer Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Ztp.Domain.Customers.Customer document;
            document = _serializer.FromJson<Ztp.Domain.Customers.Customer>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }


        public async System.Threading.Tasks.Task<Ztp.Domain.Customers.Customer> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Ztp.Domain.Customers.Customer document;
            document = await _serializer.FromJsonAsync<Ztp.Domain.Customers.Customer>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }

    }

    // END: IdentityMapCustomerSelector727746123
    
    
    // START: DirtyTrackingCustomerSelector727746123
    public class DirtyTrackingCustomerSelector727746123 : Marten.Internal.CodeGeneration.DocumentSelectorWithDirtyChecking<Ztp.Domain.Customers.Customer, System.Guid>, Marten.Linq.Selectors.ISelector<Ztp.Domain.Customers.Customer>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public DirtyTrackingCustomerSelector727746123(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Ztp.Domain.Customers.Customer Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Ztp.Domain.Customers.Customer document;
            document = _serializer.FromJson<Ztp.Domain.Customers.Customer>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }


        public async System.Threading.Tasks.Task<Ztp.Domain.Customers.Customer> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Ztp.Domain.Customers.Customer document;
            document = await _serializer.FromJsonAsync<Ztp.Domain.Customers.Customer>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }

    }

    // END: DirtyTrackingCustomerSelector727746123
    
    
    // START: QueryOnlyCustomerDocumentStorage727746123
    public class QueryOnlyCustomerDocumentStorage727746123 : Marten.Internal.Storage.QueryOnlyDocumentStorage<Ztp.Domain.Customers.Customer, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public QueryOnlyCustomerDocumentStorage727746123(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Ztp.Domain.Customers.Customer document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.AggregateId == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.AggregateId;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateCustomerOperation727746123
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Customers.Customer, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertCustomerOperation727746123
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Customers.Customer, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertCustomerOperation727746123
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Customers.Customer, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Ztp.Domain.Customers.Customer document)
        {
            return document.AggregateId;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.QueryOnlyCustomerSelector727746123(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(System.Guid id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Guid[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: QueryOnlyCustomerDocumentStorage727746123
    
    
    // START: LightweightCustomerDocumentStorage727746123
    public class LightweightCustomerDocumentStorage727746123 : Marten.Internal.Storage.LightweightDocumentStorage<Ztp.Domain.Customers.Customer, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public LightweightCustomerDocumentStorage727746123(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Ztp.Domain.Customers.Customer document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.AggregateId == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.AggregateId;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateCustomerOperation727746123
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Customers.Customer, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertCustomerOperation727746123
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Customers.Customer, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertCustomerOperation727746123
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Customers.Customer, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Ztp.Domain.Customers.Customer document)
        {
            return document.AggregateId;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.LightweightCustomerSelector727746123(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(System.Guid id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Guid[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: LightweightCustomerDocumentStorage727746123
    
    
    // START: IdentityMapCustomerDocumentStorage727746123
    public class IdentityMapCustomerDocumentStorage727746123 : Marten.Internal.Storage.IdentityMapDocumentStorage<Ztp.Domain.Customers.Customer, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public IdentityMapCustomerDocumentStorage727746123(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Ztp.Domain.Customers.Customer document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.AggregateId == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.AggregateId;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateCustomerOperation727746123
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Customers.Customer, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertCustomerOperation727746123
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Customers.Customer, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertCustomerOperation727746123
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Customers.Customer, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Ztp.Domain.Customers.Customer document)
        {
            return document.AggregateId;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.IdentityMapCustomerSelector727746123(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(System.Guid id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Guid[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: IdentityMapCustomerDocumentStorage727746123
    
    
    // START: DirtyTrackingCustomerDocumentStorage727746123
    public class DirtyTrackingCustomerDocumentStorage727746123 : Marten.Internal.Storage.DirtyCheckedDocumentStorage<Ztp.Domain.Customers.Customer, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public DirtyTrackingCustomerDocumentStorage727746123(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Ztp.Domain.Customers.Customer document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.AggregateId == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.AggregateId;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateCustomerOperation727746123
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Customers.Customer, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertCustomerOperation727746123
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Customers.Customer, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertCustomerOperation727746123
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Customers.Customer, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Ztp.Domain.Customers.Customer document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Ztp.Domain.Customers.Customer document)
        {
            return document.AggregateId;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.DirtyTrackingCustomerSelector727746123(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(System.Guid id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Guid[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: DirtyTrackingCustomerDocumentStorage727746123
    
    
    // START: CustomerBulkLoader727746123
    public class CustomerBulkLoader727746123 : Marten.Internal.CodeGeneration.BulkLoader<Ztp.Domain.Customers.Customer, System.Guid>
    {
        private readonly Marten.Internal.Storage.IDocumentStorage<Ztp.Domain.Customers.Customer, System.Guid> _storage;

        public CustomerBulkLoader727746123(Marten.Internal.Storage.IDocumentStorage<Ztp.Domain.Customers.Customer, System.Guid> storage) : base(storage)
        {
            _storage = storage;
        }


        public const string MAIN_LOADER_SQL = "COPY public.mt_doc_customer(\"mt_dotnet_type\", \"id\", \"mt_version\", \"data\") FROM STDIN BINARY";

        public const string TEMP_LOADER_SQL = "COPY mt_doc_customer_temp(\"mt_dotnet_type\", \"id\", \"mt_version\", \"data\") FROM STDIN BINARY";

        public const string COPY_NEW_DOCUMENTS_SQL = "insert into public.mt_doc_customer (\"id\", \"data\", \"mt_version\", \"mt_dotnet_type\", mt_last_modified) (select mt_doc_customer_temp.\"id\", mt_doc_customer_temp.\"data\", mt_doc_customer_temp.\"mt_version\", mt_doc_customer_temp.\"mt_dotnet_type\", transaction_timestamp() from mt_doc_customer_temp left join public.mt_doc_customer on mt_doc_customer_temp.id = public.mt_doc_customer.id where public.mt_doc_customer.id is null)";

        public const string OVERWRITE_SQL = "update public.mt_doc_customer target SET data = source.data, mt_version = source.mt_version, mt_dotnet_type = source.mt_dotnet_type, mt_last_modified = transaction_timestamp() FROM mt_doc_customer_temp source WHERE source.id = target.id";

        public const string CREATE_TEMP_TABLE_FOR_COPYING_SQL = "create temporary table mt_doc_customer_temp as select * from public.mt_doc_customer limit 0";


        public override string CreateTempTableForCopying()
        {
            return CREATE_TEMP_TABLE_FOR_COPYING_SQL;
        }


        public override string CopyNewDocumentsFromTempTable()
        {
            return COPY_NEW_DOCUMENTS_SQL;
        }


        public override string OverwriteDuplicatesFromTempTable()
        {
            return OVERWRITE_SQL;
        }


        public override void LoadRow(Npgsql.NpgsqlBinaryImporter writer, Ztp.Domain.Customers.Customer document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer)
        {
            writer.Write(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar);
            writer.Write(document.AggregateId, NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb);
        }


        public override async System.Threading.Tasks.Task LoadRowAsync(Npgsql.NpgsqlBinaryImporter writer, Ztp.Domain.Customers.Customer document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer, System.Threading.CancellationToken cancellation)
        {
            await writer.WriteAsync(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar, cancellation);
            await writer.WriteAsync(document.AggregateId, NpgsqlTypes.NpgsqlDbType.Uuid, cancellation);
            await writer.WriteAsync(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid, cancellation);
            await writer.WriteAsync(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb, cancellation);
        }


        public override string MainLoaderSql()
        {
            return MAIN_LOADER_SQL;
        }


        public override string TempLoaderSql()
        {
            return TEMP_LOADER_SQL;
        }

    }

    // END: CustomerBulkLoader727746123
    
    
    // START: CustomerProvider727746123
    public class CustomerProvider727746123 : Marten.Internal.Storage.DocumentProvider<Ztp.Domain.Customers.Customer>
    {
        private readonly Marten.Schema.DocumentMapping _mapping;

        public CustomerProvider727746123(Marten.Schema.DocumentMapping mapping) : base(new CustomerBulkLoader727746123(new QueryOnlyCustomerDocumentStorage727746123(mapping)), new QueryOnlyCustomerDocumentStorage727746123(mapping), new LightweightCustomerDocumentStorage727746123(mapping), new IdentityMapCustomerDocumentStorage727746123(mapping), new DirtyTrackingCustomerDocumentStorage727746123(mapping))
        {
            _mapping = mapping;
        }


    }

    // END: CustomerProvider727746123
    
    
}

