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
using Ztp.Domain.Products;

namespace Marten.Generated.DocumentStorage
{
    // START: UpsertProductOperation1921493051
    public class UpsertProductOperation1921493051 : Marten.Internal.Operations.StorageOperation<Ztp.Domain.Products.Product, System.Guid>
    {
        private readonly Ztp.Domain.Products.Product _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public UpsertProductOperation1921493051(Ztp.Domain.Products.Product document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select product_event_store.mt_upsert_product(?, ?, ?, ?)";


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


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
        }

    }

    // END: UpsertProductOperation1921493051
    
    
    // START: InsertProductOperation1921493051
    public class InsertProductOperation1921493051 : Marten.Internal.Operations.StorageOperation<Ztp.Domain.Products.Product, System.Guid>
    {
        private readonly Ztp.Domain.Products.Product _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public InsertProductOperation1921493051(Ztp.Domain.Products.Product document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select product_event_store.mt_insert_product(?, ?, ?, ?)";


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


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
        }

    }

    // END: InsertProductOperation1921493051
    
    
    // START: UpdateProductOperation1921493051
    public class UpdateProductOperation1921493051 : Marten.Internal.Operations.StorageOperation<Ztp.Domain.Products.Product, System.Guid>
    {
        private readonly Ztp.Domain.Products.Product _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public UpdateProductOperation1921493051(Ztp.Domain.Products.Product document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select product_event_store.mt_update_product(?, ?, ?, ?)";


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


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
        }

    }

    // END: UpdateProductOperation1921493051
    
    
    // START: QueryOnlyProductSelector1921493051
    public class QueryOnlyProductSelector1921493051 : Marten.Internal.CodeGeneration.DocumentSelectorWithOnlySerializer, Marten.Linq.Selectors.ISelector<Ztp.Domain.Products.Product>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public QueryOnlyProductSelector1921493051(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Ztp.Domain.Products.Product Resolve(System.Data.Common.DbDataReader reader)
        {

            Ztp.Domain.Products.Product document;
            document = _serializer.FromJson<Ztp.Domain.Products.Product>(reader, 0);
            return document;
        }


        public async System.Threading.Tasks.Task<Ztp.Domain.Products.Product> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {

            Ztp.Domain.Products.Product document;
            document = await _serializer.FromJsonAsync<Ztp.Domain.Products.Product>(reader, 0, token).ConfigureAwait(false);
            return document;
        }

    }

    // END: QueryOnlyProductSelector1921493051
    
    
    // START: LightweightProductSelector1921493051
    public class LightweightProductSelector1921493051 : Marten.Internal.CodeGeneration.DocumentSelectorWithVersions<Ztp.Domain.Products.Product, System.Guid>, Marten.Linq.Selectors.ISelector<Ztp.Domain.Products.Product>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public LightweightProductSelector1921493051(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Ztp.Domain.Products.Product Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);

            Ztp.Domain.Products.Product document;
            document = _serializer.FromJson<Ztp.Domain.Products.Product>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }


        public async System.Threading.Tasks.Task<Ztp.Domain.Products.Product> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);

            Ztp.Domain.Products.Product document;
            document = await _serializer.FromJsonAsync<Ztp.Domain.Products.Product>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }

    }

    // END: LightweightProductSelector1921493051
    
    
    // START: IdentityMapProductSelector1921493051
    public class IdentityMapProductSelector1921493051 : Marten.Internal.CodeGeneration.DocumentSelectorWithIdentityMap<Ztp.Domain.Products.Product, System.Guid>, Marten.Linq.Selectors.ISelector<Ztp.Domain.Products.Product>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public IdentityMapProductSelector1921493051(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Ztp.Domain.Products.Product Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Ztp.Domain.Products.Product document;
            document = _serializer.FromJson<Ztp.Domain.Products.Product>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }


        public async System.Threading.Tasks.Task<Ztp.Domain.Products.Product> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Ztp.Domain.Products.Product document;
            document = await _serializer.FromJsonAsync<Ztp.Domain.Products.Product>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }

    }

    // END: IdentityMapProductSelector1921493051
    
    
    // START: DirtyTrackingProductSelector1921493051
    public class DirtyTrackingProductSelector1921493051 : Marten.Internal.CodeGeneration.DocumentSelectorWithDirtyChecking<Ztp.Domain.Products.Product, System.Guid>, Marten.Linq.Selectors.ISelector<Ztp.Domain.Products.Product>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public DirtyTrackingProductSelector1921493051(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Ztp.Domain.Products.Product Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Ztp.Domain.Products.Product document;
            document = _serializer.FromJson<Ztp.Domain.Products.Product>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }


        public async System.Threading.Tasks.Task<Ztp.Domain.Products.Product> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Ztp.Domain.Products.Product document;
            document = await _serializer.FromJsonAsync<Ztp.Domain.Products.Product>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }

    }

    // END: DirtyTrackingProductSelector1921493051
    
    
    // START: QueryOnlyProductDocumentStorage1921493051
    public class QueryOnlyProductDocumentStorage1921493051 : Marten.Internal.Storage.QueryOnlyDocumentStorage<Ztp.Domain.Products.Product, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public QueryOnlyProductDocumentStorage1921493051(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Ztp.Domain.Products.Product document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateProductOperation1921493051
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Products.Product, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertProductOperation1921493051
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Products.Product, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertProductOperation1921493051
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Products.Product, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Ztp.Domain.Products.Product document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.QueryOnlyProductSelector1921493051(session, _document);
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

    // END: QueryOnlyProductDocumentStorage1921493051
    
    
    // START: LightweightProductDocumentStorage1921493051
    public class LightweightProductDocumentStorage1921493051 : Marten.Internal.Storage.LightweightDocumentStorage<Ztp.Domain.Products.Product, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public LightweightProductDocumentStorage1921493051(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Ztp.Domain.Products.Product document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateProductOperation1921493051
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Products.Product, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertProductOperation1921493051
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Products.Product, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertProductOperation1921493051
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Products.Product, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Ztp.Domain.Products.Product document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.LightweightProductSelector1921493051(session, _document);
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

    // END: LightweightProductDocumentStorage1921493051
    
    
    // START: IdentityMapProductDocumentStorage1921493051
    public class IdentityMapProductDocumentStorage1921493051 : Marten.Internal.Storage.IdentityMapDocumentStorage<Ztp.Domain.Products.Product, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public IdentityMapProductDocumentStorage1921493051(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Ztp.Domain.Products.Product document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateProductOperation1921493051
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Products.Product, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertProductOperation1921493051
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Products.Product, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertProductOperation1921493051
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Products.Product, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Ztp.Domain.Products.Product document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.IdentityMapProductSelector1921493051(session, _document);
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

    // END: IdentityMapProductDocumentStorage1921493051
    
    
    // START: DirtyTrackingProductDocumentStorage1921493051
    public class DirtyTrackingProductDocumentStorage1921493051 : Marten.Internal.Storage.DirtyCheckedDocumentStorage<Ztp.Domain.Products.Product, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public DirtyTrackingProductDocumentStorage1921493051(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Ztp.Domain.Products.Product document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateProductOperation1921493051
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Products.Product, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertProductOperation1921493051
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Products.Product, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertProductOperation1921493051
            (
                document, Identity(document),
                session.Versions.ForType<Ztp.Domain.Products.Product, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Ztp.Domain.Products.Product document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Ztp.Domain.Products.Product document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.DirtyTrackingProductSelector1921493051(session, _document);
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

    // END: DirtyTrackingProductDocumentStorage1921493051
    
    
    // START: ProductBulkLoader1921493051
    public class ProductBulkLoader1921493051 : Marten.Internal.CodeGeneration.BulkLoader<Ztp.Domain.Products.Product, System.Guid>
    {
        private readonly Marten.Internal.Storage.IDocumentStorage<Ztp.Domain.Products.Product, System.Guid> _storage;

        public ProductBulkLoader1921493051(Marten.Internal.Storage.IDocumentStorage<Ztp.Domain.Products.Product, System.Guid> storage) : base(storage)
        {
            _storage = storage;
        }


        public const string MAIN_LOADER_SQL = "COPY product_event_store.mt_doc_product(\"mt_dotnet_type\", \"id\", \"mt_version\", \"data\") FROM STDIN BINARY";

        public const string TEMP_LOADER_SQL = "COPY mt_doc_product_temp(\"mt_dotnet_type\", \"id\", \"mt_version\", \"data\") FROM STDIN BINARY";

        public const string COPY_NEW_DOCUMENTS_SQL = "insert into product_event_store.mt_doc_product (\"id\", \"data\", \"mt_version\", \"mt_dotnet_type\", mt_last_modified) (select mt_doc_product_temp.\"id\", mt_doc_product_temp.\"data\", mt_doc_product_temp.\"mt_version\", mt_doc_product_temp.\"mt_dotnet_type\", transaction_timestamp() from mt_doc_product_temp left join product_event_store.mt_doc_product on mt_doc_product_temp.id = product_event_store.mt_doc_product.id where product_event_store.mt_doc_product.id is null)";

        public const string OVERWRITE_SQL = "update product_event_store.mt_doc_product target SET data = source.data, mt_version = source.mt_version, mt_dotnet_type = source.mt_dotnet_type, mt_last_modified = transaction_timestamp() FROM mt_doc_product_temp source WHERE source.id = target.id";

        public const string CREATE_TEMP_TABLE_FOR_COPYING_SQL = "create temporary table mt_doc_product_temp as select * from product_event_store.mt_doc_product limit 0";


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


        public override void LoadRow(Npgsql.NpgsqlBinaryImporter writer, Ztp.Domain.Products.Product document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer)
        {
            writer.Write(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar);
            writer.Write(document.Id, NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb);
        }


        public override async System.Threading.Tasks.Task LoadRowAsync(Npgsql.NpgsqlBinaryImporter writer, Ztp.Domain.Products.Product document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer, System.Threading.CancellationToken cancellation)
        {
            await writer.WriteAsync(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar, cancellation);
            await writer.WriteAsync(document.Id, NpgsqlTypes.NpgsqlDbType.Uuid, cancellation);
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

    // END: ProductBulkLoader1921493051
    
    
    // START: ProductProvider1921493051
    public class ProductProvider1921493051 : Marten.Internal.Storage.DocumentProvider<Ztp.Domain.Products.Product>
    {
        private readonly Marten.Schema.DocumentMapping _mapping;

        public ProductProvider1921493051(Marten.Schema.DocumentMapping mapping) : base(new ProductBulkLoader1921493051(new QueryOnlyProductDocumentStorage1921493051(mapping)), new QueryOnlyProductDocumentStorage1921493051(mapping), new LightweightProductDocumentStorage1921493051(mapping), new IdentityMapProductDocumentStorage1921493051(mapping), new DirtyTrackingProductDocumentStorage1921493051(mapping))
        {
            _mapping = mapping;
        }


    }

    // END: ProductProvider1921493051
    
    
}

