CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
                                                       "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
    );

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240117212031_CreateCustomersTable') THEN
CREATE TABLE customers (
                           "Id" uuid NOT NULL,
                           "FirstName" character varying(200) NOT NULL,
                           "LastName" character varying(500) NOT NULL,
                           "Email" text,
                           "CreatedAt" timestamp with time zone NOT NULL,
                           "UpdatedAt" timestamp with time zone NOT NULL,
                           CONSTRAINT "PK_customers" PRIMARY KEY ("Id")
);
END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240117212031_CreateCustomersTable') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20240117212031_CreateCustomersTable', '8.0.0');
END IF;
END $EF$;
COMMIT;

