/*
Разработать и создать представление с именем Количество кафедр. Представление должно
быть построено на основе SELECT-запроса к таблицам FACULTY и PULPIT.
Представление должно содержать следую-щие столбцы: факультет (FACUL-TY.FACULTY_ NAME),
количество кафедр (вычисляется на основе строк таблицы PULPIT). 
 
*/
USE UNIVER;
GO
CREATE VIEW [Количество кафедр]
AS SELECT
FACULTY.FACULTY_NAME [Факультет],
COUNT(PULPIT.PULPIT)[Количество кафедр]
FROM FACULTY 
JOIN PULPIT ON FACULTY.FACULTY=PULPIT.FACULTY
GROUP BY FACULTY_NAME
go
SELECT * FROM [Количество кафедр];