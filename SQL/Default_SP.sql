--to get columns name with data type use this
EXEC tempdb.dbo.sp_help N'#temp_table_name';

--to get specific columns name with data type use this
SELECT * 
FROM tempdb.sys.columns 
WHERE [object_id] = OBJECT_ID(N'tempdb..#temp');
