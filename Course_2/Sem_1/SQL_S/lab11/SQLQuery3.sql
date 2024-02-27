/*3.����������� ��������, �����-���������� ���������� ���-������ SAVE TRAN �� ���-���� ���� ������ X_UNIVER. 
� ����� CATCH �����-�������� ������ �����������-���� ��������� �� �������. 
���������� ������ �����-��� ��� ������������� ���-������ ����������� ����� � ��������� ���������� ����-������� ������.
 */

 USE UNIVER;
DECLARE @POINT VARCHAR(32);

BEGIN TRY
	BEGIN TRAN                           
		SET @POINT = 'P1'; 
		SAVE TRAN @POINT; 
		INSERT PULPIT VALUES
		       
			   ('��', ' ��������������� �����������', '����')
  
		SET @POINT = 'P2'; 
		SAVE TRAN @POINT; 
		INSERT PULPIT VALUES
		       ('����', '�������������� ������ � ���������� ', '��'); 
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
	   PRINT '����������� �����: '+ @POINT;
	   ROLLBACK TRAN @POINT; 
	   COMMIT TRAN; 
	END;     
END CATCH;

SELECT * FROM PULPIT; 