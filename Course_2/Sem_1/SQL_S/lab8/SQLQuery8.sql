/*8. Разработать скрипт, демонстрирую-щий использование оператора RE-TURN. */


DECLARE @I INT = 20;
PRINT @I+1;
PRINT POWER(@I,3);
RETURN
PRINT @I+10;
go
DECLARE @INDEX INT = 0;
WHILE @INDEX <10
BEGIN
  IF @INDEX =5
  BEGIN
  PRINT 'THE END - 5'
  RETURN
  END
  PRINT @INDEX
  SET @INDEX +=1;
END