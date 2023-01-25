/*Finding the data types of a SQL temporary table*/

--to get columns name with data type - Using SP_HELP
EXEC tempdb.dbo.sp_help N'#temp_table_name';

--to get columns name with data type - Using SP_COLUMNS
EXEC TempDB..SP_COLUMNS '#temp_table_name';

--to get specific columns name with data type - Using SP_COLUMNS
SELECT * 
FROM tempdb.sys.columns 
WHERE [object_id] = OBJECT_ID(N'tempdb..#temp_table_name');

-- Using System Tables like INFORMATION_SCHEMA.COLUMNS, SYS.COLUMNS, SYS.TABLES
SELECT * FROM TempDB.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME IN (
SELECT NAME FROM TempDB.SYS.TABLES WHERE OBJECT_ID=OBJECT_ID('TempDB.dbo.#TempTable')
);
GO

SELECT * FROM TempDB.SYS.COLUMNS WHERE OBJECT_ID=OBJECT_ID('TempDB.dbo.#TempTable');
GO

SELECT * FROM TempDB.SYS.TABLES WHERE OBJECT_ID=OBJECT_ID('TempDB.dbo.#TempTable');
GO

/* ------------------- */
