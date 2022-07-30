/*
Database task:
	1. Import the provided excel sheet into any relational database
	2. Answers these questions:		
Note: provide all the queries in a text file
*/

-- 1. Which drink has the highest calories from the dataset ?
SELECT Beverage, Calories
FROM [dbo].[drinkMenu]
WHERE Calories = (SELECT MAX(Calories) FROM [dbo].[drinkMenu])
Order by Beverage
;

-- 2. What is the average calorie amount for each drink category ?
SELECT Beverage_category, AVG(Calories) 'Average Calories'
FROM [dbo].[drinkMenu]
GROUP BY Beverage_category
Order BY Beverage_category
;

-- 3. Which drinks have below average calorie amount ?
SELECT Beverage, Calories
FROM [dbo].[drinkMenu]
WHERE Calories < (SELECT AVG(Calories) FROM[dbo].[drinkMenu])
ORDER BY Beverage
;