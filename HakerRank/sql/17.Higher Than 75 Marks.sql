/*
https://www.hackerrank.com/challenges/more-than-75-marks/problem?isFullScreen=true&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
*/

/*
select name from students
where marks >75
order by substring(name,len(name)-2,len(name)),id asc
*/

select name from students
where marks >75
order by right(name,3),id asc ;
