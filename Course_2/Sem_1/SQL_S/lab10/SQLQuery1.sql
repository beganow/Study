/*1. Разработать сценарий, форми-рующий список дисциплин на кафед-ре ИСиТ. 
В отчет должны быть вы-ведены краткие названия (поле SUBJECT) из таблицы SUBJECT в одну строку через запятую. 
Использовать встроенную функ-цию RTRIM.
*/

USE UNIVER

DECLARE @ONE NVARCHAR(20), @ALL NVARCHAR(300) = '';
DECLARE LINES CURSOR FOR SELECT SUBJECT FROM SUBJECT

OPEN LINES
FETCH LINES INTO @ONE
PRINT 'Предметы'
WHILE @@FETCH_STATUS = 0
BEGIN
SET @ALL = RTRIM(@ONE) + ', ' + @ALL 
FETCH LINES INTO @ONE
END
PRINT RTRIM(@ALL) + ' Остальные предметы'
CLOSE LINES