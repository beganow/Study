/* 2. ����������� ��������, �����-���������� �������� ���-�������� ����� ���������� �� ������� ���� ������ X_UNIVER. 
� ����� CATCH �����-�������� ������ �����������-���� ��������� �� �������. 
���������� ������ �����-��� ��� ������������� ���-������ ���������� ������-����� ������.
*/
USE UNIVER;
BEGIN TRY        
	BEGIN TRAN                 
		INSERT AUDITORIUM VALUES ('2', '��-�', '15', '206-1');
	    INSERT AUDITORIUM VALUES ('206-1', '��', '30', '206-1');
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