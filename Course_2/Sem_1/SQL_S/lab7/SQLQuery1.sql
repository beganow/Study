/*
1. Разработать представление с именем Пре-подаватель. Представление должно быть по-строено
на основе SELECT-запроса к таблице TEACHER и содержать следующие столбцы:
код (TEACHER), имя преподавателя (TEACHER_NAME),
пол (GENDER), код кафедры (PULPIT). */

USE UNIVER;
go
CREATE VIEW [Преподаватель] 
as select
TEACHER.TEACHER [Код],
TEACHER.TEACHER_NAME [Имя преподавателя],
TEACHER.GENDER [Пол],
TEACHER.PULPIT [Код кафедры]
FROM TEACHER;
go
SELECT * FROM [Преподаватель]
GO
DROP VIEW [Преподаватель]