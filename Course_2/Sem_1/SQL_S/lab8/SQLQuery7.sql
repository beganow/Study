/*7.Создать временную локальную табли-цу из трех столбцов и 10 строк, запол-нить ее и вывести содержимое. Ис-пользовать оператор WHILE.*/


CREATE TABLE #TASK(
	ID INT,
	NAME VARCHAR(20),
	MESSAGE VARCHAR(10)
	)
GO

DECLARE @INDEX INT = 0
WHILE @INDEX < 10
BEGIN
INSERT #TASK VALUES (@INDEX, 'NAME ' + CAST(@INDEX AS VARCHAR), 'MESSAGE ' + CAST(@INDEX AS VARCHAR))
SET @INDEX += 1
END

SELECT * FROM #TASK