-- 176. Second Highest Salary
-- https://leetcode.com/problems/second-highest-salary/

--######### Null case not handeled

-- SELECT TOP 1 salary  AS SecondHighestSalary
-- FROM(
--       SELECT TOP 2 salary
--       FROM employee
--       ORDER BY salary DESC
--     )result
-- ORDER BY salary



-- SELECT TOP 1 id, salary  AS SecondHighestSalary
-- FROM(
--       SELECT TOP 2 id, salary
--       FROM employee
--       ORDER BY salary DESC
--     )result
-- ORDER BY salary


-- ####### Null case handeled


-- SELECT MAX(Salary) AS SecondHighestSalary
-- FROM   Employee
-- WHERE  Salary NOT IN
-- (SELECT MAX(Salary) FROM   Employee)



-- SELECT (
-- SELECT DISTINCT
--     Salary
-- FROM
--     Employee
-- ORDER BY Salary DESC
-- OFFSET 1 ROWS
-- FETCH NEXT 1 ROWS ONLY
-- ) AS SecondHighestSalary


SELECT
    NULLIF(
      (SELECT DISTINCT Salary
       FROM Employee
       ORDER BY Salary DESC
         OFFSET 1 ROWS
         FETCH NEXT 1 ROWS ONLY),
    NULL) AS SecondHighestSalary
    
    

    
