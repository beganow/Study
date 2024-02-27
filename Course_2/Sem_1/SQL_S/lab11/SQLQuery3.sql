/*3.Разработать сценарий, демон-стрирующий применение опе-ратора SAVE TRAN на при-мере базы данных X_UNIVER. 
В блоке CATCH преду-смотреть выдачу соответству-ющих сообщений об ошибках. 
Опробовать работу сцена-рия при использовании раз-личных контрольных точек и различных операторов моди-фикации таблиц.
 */

 USE UNIVER;
DECLARE @POINT VARCHAR(32);

BEGIN TRY
	BEGIN TRAN                           
		SET @POINT = 'P1'; 
		SAVE TRAN @POINT; 
		INSERT PULPIT VALUES
		       
			   ('ПП', ' Полиграфических производств', 'ИДиП')
  
		SET @POINT = 'P2'; 
		SAVE TRAN @POINT; 
		INSERT PULPIT VALUES
		       ('ИСиТ', 'Информационных систем и технологий ', 'ИТ'); 
	COMMIT TRAN;                                              
END TRY

BEGIN CATCH
	PRINT 'ERROR: '+ CASE 
		WHEN ERROR_NUMBER() = 2627 AND PATINDEX('%PULPIT_PK%', ERROR_MESSAGE()) > 0 
		THEN 'ER' 
		ELSE 'OTHER ERROR:: '+ CAST(ERROR_NUMBER() AS  VARCHAR(5)) + ERROR_MESSAGE()  
	END; 


    IF @@TRANCOUNT > 0
	BEGIN
	   PRINT 'Контрольная точка: '+ @POINT;
	   ROLLBACK TRAN @POINT; 
	   COMMIT TRAN; 
	END;     
END CATCH;

SELECT * FROM PULPIT; 