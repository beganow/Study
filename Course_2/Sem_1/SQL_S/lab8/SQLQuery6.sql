/*6. Разработать сценарий, в котором с помощью CASE анализируются оцен-ки, полученные студентами некоторо-го факультета при сдаче экзаменов.*/


USE UNIVER;

SELECT (CASE
WHEN NOTE BETWEEN 0 AND 3 THEN 'ПЛОХО'
WHEN NOTE BETWEEN 4 AND 5 THEN 'СРЕДНЕ'
WHEN NOTE BETWEEN 6 AND 7 THEN 'ХОРОШО'
WHEN NOTE BETWEEN 8 AND 10 THEN 'ОТЛИЧНО'
END) КАЧЕСТВО, COUNT(*) [ОАИП×СУБД] FROM PROGRESS
GROUP BY (CASE
WHEN NOTE BETWEEN 0 AND 3 THEN 'ПЛОХО'
WHEN NOTE BETWEEN 4 AND 5 THEN 'СРЕДНЕ'
WHEN NOTE BETWEEN 6 AND 7 THEN 'ХОРОШО'
WHEN NOTE BETWEEN 8 AND 10 THEN 'ОТЛИЧНО'
END)