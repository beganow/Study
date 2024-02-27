/*Создать временную локальную таблицу. Заполнить ее данными (10000 строк или больше). 
Разработать SELECT-запрос. Получить план запроса и опреде-лить его стоимость. 
Создать некластеризованный не-уникальный составной индекс. 
Оценить процедуры поиска ин-формации.
*/

USE UNIVER;
DROP TABLE #TEST2;
CREATE TABLE #TEST2
(
INFO NVARCHAR (20),
ITERATOR INT IDENTITY(1,1),
INDEX_ INT 
)
/*добавление в таблицу 10000 строк*/
DECLARE @X INT =0;
WHILE @X <= 20000
BEGIN
INSERT INTO #TEST2(INFO,INDEX_)
VALUES ('СТРОКА' + CAST(@X AS NVARCHAR),FLOOR(20000*RAND()))
SET @X +=1;
END

SELECT count(*) [количество строк] from #TEST2
SELECT * FROM #TEST2
SELECT * FROM #TEST2 WHERE INFO = 'СТРОКА2' AND INDEX_ >= 1000 

CHECKPOINT;

DBCC DROPCLEANBUFFERS
/*Создать некластеризованный не-уникальный составной индекс*/
CREATE INDEX #TEST2_NONCL ON #TEST2(INFO,INDEX_)
SELECT * FROM #TEST2 WHERE INFO = 'СТРОКА2' AND INDEX_ >= 1000

DROP INDEX #TEST2_NONCL ON #TEST2