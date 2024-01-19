START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240119164743_AddIsDeletedToProduct') THEN
ALTER TABLE products ADD "IsDeleted" boolean NOT NULL DEFAULT FALSE;
END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240119164743_AddIsDeletedToProduct') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20240119164743_AddIsDeletedToProduct', '8.0.0');
END IF;
END $EF$;
COMMIT;

