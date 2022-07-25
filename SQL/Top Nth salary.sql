/*

Select Max(Salary) from Employees where Salary < (Select Max(Salary) from Employees)

*/


/*
SELECT TOP 1 SALARY
FROM (
      SELECT DISTINCT TOP N SALARY
      FROM EMPLOYEES
      ORDER BY SALARY DESC
      ) RESULT
ORDER BY SALARY


*/


/*

WITH RESULT AS
(
    SELECT SALARY,
           DENSE_RANK() OVER (ORDER BY SALARY DESC) AS DENSERANK
    FROM EMPLOYEES
)
SELECT TOP 1 SALARY
FROM RESULT
WHERE DENSERANK = N


*/




/*

select max(GrossValue) from SalesOrders 
where OrderDate between '1 Jan 2022' and '5 jan 2022'
and SalesPointID = 35 and GrossValue != 0 and
GrossValue <
(
	select max(GrossValue) from SalesOrders 
	where OrderDate between '1 Jan 2022' and '5 jan 2022'
	and SalesPointID = 35 and GrossValue != 0
)

*/

/*

declare @n int = 9
select top 1 GrossValue
from (
	select TOP (@n) GrossValue from SalesOrders 
	where OrderDate between '1 Jan 2022' and '5 jan 2022'
	and SalesPointID = 35 and GrossValue != 0
	order by GrossValue desc
	)gv
order by GrossValue 


*/
