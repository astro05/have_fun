/*
https://www.hackerrank.com/challenges/weather-observation-station-9/problem?isFullScreen=true&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
*/


select distinct city from station
where not ( substring(city,1,1) = 'a' or substring(city,1,1) = 'e' or substring(city,1,1) = 'i' or substring(city,1,1) = 'o' or substring(city,1,1) = 'u' );


/*
select distinct city from station
where not (left(city,1) = 'a' or left(city,1) = 'e' or left(city,1) = 'i' or left(city,1) = 'o' or left(city,1) = 'u');
*/
