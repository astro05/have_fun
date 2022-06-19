/* https://leetcode.com/problems/calculate-special-bonus/  */


/*
select 
	 (case when employee_id%2=1 and name not like 'M%' 
			then employee_id 
     else employee_id end) as employee_id ,
     (case when employee_id%2=1 and name not like 'M%' 
			 then salary 
     else 0 end) as bonus
from employees order by employee_id;

*/

/*
select employee_id, salary * (employee_id %2 = 1 ) * (name not like 'M%') as bonus
from employees;
*/


/*
SELECT employee_id,
IF (employee_id%2 AND name not like "M%", salary, 0) as bonus
FROM employees;
*/


SELECT employee_id,
CASE
	WHEN employee_id%2 = 1 AND name NOT LIKE 'M%' THEN salary
	ELSE 0
END AS bonus
FROM employees
order by employee_id;
