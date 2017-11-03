IF EXISTS
(
    SELECT *
    FROM sys.tables
    WHERE tables.name = 'DMVEntries'
)
BEGIN
    DROP TABLE dbo.DMVEntries
END