START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240117213505_CreateProductsTable') THEN
CREATE TABLE products (
                          "Id" uuid NOT NULL,
                          "Name" character varying(200) NOT NULL,
                          "Description" text,
                          "Amount" numeric NOT NULL,
                          "Currency" text NOT NULL,
                          "Quantity" integer NOT NULL,
                          "CreatedAt" timestamp with time zone NOT NULL,
                          "UpdatedAt" timestamp with time zone NOT NULL,
                          CONSTRAINT "PK_products" PRIMARY KEY ("Id")
);
END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240117213505_CreateProductsTable') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20240117213505_CreateProductsTable', '8.0.0');
END IF;
END $EF$;
COMMIT;

