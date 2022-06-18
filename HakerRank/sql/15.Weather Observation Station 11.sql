/*
https://www.hackerrank.com/challenges/weather-observation-station-11/problem?isFullScreen=true
*/



select distinct city from station
where not(
    substring(city,len(city),len(city)) = 'a' or 
substring(city,len(city),len(city)) = 'e' or 
substring(city,len(city),len(city)) = 'i' or
substring(city,len(city),len(city)) = 'o' or 
substring(city,len(city),len(city)) = 'u'
)or not  (
     substring(city,1,1) = 'a' or substring(city,1,1) = 'e' or substring(city,1,1) = 'i' or substring(city,1,1) = 'o' or substring(city,1,1) = 'u'
);


/*
select distinct city from station
where not (
right(city,1) = 'a' or right(city,1) = 'e' or right(city,1) = 'i' or right(city,1) = 'o' or right(city,1) = 'u'
) or not(
left(city,1) = 'a' or left(city,1) = 'e' or left(city,1) = 'i' or left(city,1) = 'o' or left(city,1) = 'u'
);
*/
