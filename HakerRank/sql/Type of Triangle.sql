/*
https://www.hackerrank.com/challenges/what-type-of-triangle/problem?isFullScreen=true
*/

select case
    when a+b>c and b+c>a and c+a> b then
        case    
            when a=b and b=c then 'Equilateral'
            when a=b or b=c or c=a then 'Isosceles'
            else 'Scalene'
        end
    else 'Not A Triangle'
    end
from Triangles;

/*
SELECT CASE
    WHEN 2 * GREATEST(A, B, C) >= (A + B + C) THEN "Not A Triangle"
    WHEN A = B AND A = C                      THEN "Equilateral"
    WHEN A = B OR A = C OR B = C              THEN "Isosceles"
                                              ELSE "Scalene"
    END
FROM TRIANGLES
*/


/*

The general rule/condition for a valid triangle is that the longest side should be less than the sum of the two other sides:

longestSide < sumOfOtherSides (1)

For example, if you have A, B, and C, where B is the longest side, then the condition B < (A+C) is true for a valid triangle, and false otherwise.

Now, the sum of all the sides of the triangle is (A+B+C). Given B is the longest side, if you want to get the sum of other sides, you have to remove B from the sum of all sides, thus (A+C) = (A+B+C) - (B) or in other words:

sumOfOtherSides = sumOfAllSides - longestSide (2)

With this in mind, the first inequation (1) can now be written as :

longestSide < sumOfAllSides - longestSide

which is equivalent to

longestSide + longestSide < sumOfAllSides

or

2 * longestSide < sumOfAllSides (3)

So, a triangle is valid if and only if inequation (3) is true. If (3) is false, then we have 2 * longestSide >= sumOfAllSides. In MySQL and Oracle SQL, the GREATEST() function returns the greatest value of the guiven arguments. Hence, you have longestSide = GREATEST(A, B, C).

Everything above put together, the final formula to check if a triangle is NOT valid is :

2 * GREATEST(A, B, C) >= (A + B + C)

*/
