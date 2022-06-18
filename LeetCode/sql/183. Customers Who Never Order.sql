/* https://leetcode.com/problems/customers-who-never-order/  */

/*
select customers.name as 'Customers' from customers
where customers.id not in (select customerid from orders)

*/


select name as 'Customers'
from customers c
left join orders o 
on c.Id = o.customerId
where o.customerId is null

