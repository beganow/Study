/*Разработать сценарий, демон-стрирующий работу в режиме неявной транзакции.
Проанализировать пример, приведенный справа, в кото-ром создается таблица Х, и со-здать сценарий для другой таблицы.
*/


SET NOCOUNT ON;
IF EXISTS (SELECT * FROM SYS.OBJECTS
WHERE OBJECT_ID = OBJECT_ID(N'DBO.X')) -- таблица X есть?
DROP TABLE X;

DECLARE @C INT, @FLAG CHAR = 'C'
SET IMPLICIT_TRANSACTIONS ON;-- включ. режим неявной транзакции
CREATE TABLE X (VAL INT);-- начало транзакции 
INSERT X VALUES (1), (2), (3);
SET @C = (SELECT COUNT(*) FROM X);
PRINT 'количество строк в таблице X: ' + CONVERT(VARCHAR, @C);
IF @FLAG = 'C'-- завершение транзакции: фиксация 
COMMIT;
ELSE
ROLLBACK;-- завершение транзакции: откат  
SET IMPLICIT_TRANSACTIONS OFF;--выключ. режим неявной транзакции

IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'DBO.X'))
PRINT 'таблица X есть';
ELSE
PRINT 'таблицы X нет';
