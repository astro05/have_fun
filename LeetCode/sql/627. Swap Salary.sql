/* https://leetcode.com/problems/swap-salary/ */


update salary
set 
   sex = case sex
             when 'm' then 'f'
             else 'm'
         end;
             


/*
update salary set sex = CHAR(ASCII('f') ^ ASCII('m') ^ ASCII(sex)); --XOR operation

*/
