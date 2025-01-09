CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
   "MigrationId" character varying(150) NOT NULL,
   "ProductVersion" character varying(32) NOT NULL,
   CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

DO $EF$
    BEGIN
        IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250108154339_Create_Articles_Table') THEN
            IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'blog') THEN
                CREATE SCHEMA blog;
            END IF;
        END IF;
    END $EF$;

DO $EF$
    BEGIN
        IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250108154339_Create_Articles_Table') THEN
            CREATE TABLE blog.articles (
               id uuid NOT NULL,
               title character varying(100) NOT NULL,
               author character varying(100) NOT NULL,
               content character varying(500) NOT NULL,
               "isDraft" boolean NOT NULL DEFAULT FALSE,
               "releaseDate" date,
               CONSTRAINT "PK_articles" PRIMARY KEY (id)
            );
        END IF;
    END $EF$;

DO $EF$
    BEGIN
        IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250108154339_Create_Articles_Table') THEN
            INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
            VALUES ('20250108154339_Create_Articles_Table', '9.0.0');
        END IF;
    END $EF$;
COMMIT;
