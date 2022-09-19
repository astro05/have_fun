-- 177. Nth Highest Salary 
-- https://leetcode.com/problems/nth-highest-salary/



-- CREATE FUNCTION getNthHighestSalary(@n INT) RETURNS INT AS
-- BEGIN
-- RETURN (
-- ISNULL(
--         (SELECT DISTINCT salary as getNthHighestSalary from Employee 
--         ORDER BY salary DESC 
--         OFFSET (@n-1) ROWS  
--         FETCH NEXT 1 ROWS ONLY 
--         ), null
--       )
--     );   
    
-- END





CREATE FUNCTION getNthHighestSalary(@n INT) RETURNS INT AS
BEGIN
RETURN (
SELECT 
        (SELECT DISTINCT salary as getNthHighestSalary from Employee 
        ORDER BY salary DESC 
        OFFSET (@n-1) ROWS  
        FETCH NEXT 1 ROWS ONLY 
        ) AS getNthHighestSalary
      
    );   
    
END



--SELECT dbo.getNthHighestSalary(2)

