/*3.Создать временную локальную таблицу. Заполнить ее данными (не менее 10000 строк). 
Разработать SELECT-запрос. Получить план запроса и опреде-лить его стоимость. 
Создать некластеризованный ин-декс покрытия, уменьшающий стоимость SELECT-запроса. 
*/


USE UNIVER;
CREATE TABLE #TASK3
(
INFO NVARCHAR (20),
ITERATOR INT IDENTITY(1,1),
INDEX_ INT 
)

DECLARE @X INT =0;
WHILE @X <= 10000
BEGIN
INSERT INTO #TASK3(INFO,INDEX_)
VALUES ('СТРОКА' + CAST(@X AS NVARCHAR),FLOOR(20000*RAND()))
SET @X +=1;
END
SELECT Count(*)[Количество строк] FROM #TASK3
SELECT * FROM #TASK3
SELECT INFO FROM #TASK3 WHERE ITERATOR <= 10000 

CHECKPOINT;

DBCC DROPCLEANBUFFERS

CREATE INDEX #NONCLUSTPOK ON #TASK3 (ITERATOR) INCLUDE (INFO)

SELECT INFO FROM #TASK3 WHERE ITERATOR <= 10000 

DROP INDEX #NONCLUSTPOK ON #TASK3POK

DROP TABLE #TASK3