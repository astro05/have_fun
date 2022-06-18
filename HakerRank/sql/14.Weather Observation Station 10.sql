/*
https://www.hackerrank.com/challenges/weather-observation-station-10/problem?isFullScreen=true&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
*/

/*
select distinct city from station
where not ( substring(city,len(city),len(city)) = 'a' or 
substring(city,len(city),len(city)) = 'e' or 
substring(city,len(city),len(city)) = 'i' or
substring(city,len(city),len(city)) = 'o' or 
substring(city,len(city),len(city)) = 'u' );

*/


select distinct city from station
where not( right(city,1) = 'a' or right(city,1) = 'e' or right(city,1) = 'i' or right(city,1) = 'o' or right(city,1) = 'u' );
