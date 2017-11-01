IF EXISTS
(
    SELECT *
    FROM INFORMATION_SCHEMA
    WHERE table_name = 'db_UP' AND table_schema = 'dbo'
)
BEGIN
    DROP TABLE dbo.db_UP
END