/* 2. Разработать сценарий, демон-стрирующий свойство ато-марности явной транзакции на примере базы данных X_UNIVER. 
В блоке CATCH преду-смотреть выдачу соответству-ющих сообщений об ошибках. 
Опробовать работу сцена-рия при использовании раз-личных операторов модифи-кации таблиц.
*/
USE UNIVER;
BEGIN TRY        
	BEGIN TRAN                 
		INSERT AUDITORIUM VALUES ('2', 'ЛБ-К', '15', '206-1');
	    INSERT AUDITORIUM VALUES ('206-1', 'ЛК', '30', '206-1');
	COMMIT TRAN;               
END TRY

BEGIN CATCH
	PRINT 'ERROR: '+ CASE 
		WHEN ERROR_NUMBER() = 2627 AND PATINDEX('%AUDITORIUM_PK%', ERROR_MESSAGE()) > 0 
		THEN 'ERROR'	
		ELSE 'OTHER ERROR: '+ CAST(ERROR_NUMBER() AS  VARCHAR(5))+ ERROR_MESSAGE()  
	END;
	IF @@TRANCOUNT > 0 ROLLBACK TRAN; 	  
END CATCH;

SELECT * FROM AUDITORIUM;