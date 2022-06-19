/* 
https://leetcode.com/problems/delete-duplicate-emails/
 */

/*
delete p1
from person p1, person p2
where p1.email = p2.email and p1.id > p2.id 
*/


/*
DELETE FROM Person
    WHERE Id IN
    (SELECT P1.Id FROM Person AS P1, Person AS P2 
	     WHERE P1.Id > P2.Id AND P1.Email = P2.Email);
         
*/

delete p1 from Person as p1
inner join Person as p2
on p1.email = p2.email and p1.id>p2.id
         
