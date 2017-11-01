IF EXISTS
(
    SELECT *
    FROM sys.tables
    WHERE tables.name = 'db_UP'
)
BEGIN
    DROP TABLE dbo.db_UP
END