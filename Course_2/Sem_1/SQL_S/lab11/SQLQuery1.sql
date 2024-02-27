/*����������� ��������, �����-���������� ������ � ������ ������� ����������.
���������������� ������, ����������� ������, � ����-��� ��������� ������� �, � ��-����� �������� ��� ������ �������.
*/


SET NOCOUNT ON;
IF EXISTS (SELECT * FROM SYS.OBJECTS
WHERE OBJECT_ID = OBJECT_ID(N'DBO.X')) -- ������� X ����?
DROP TABLE X;

DECLARE @C INT, @FLAG CHAR = 'C'
SET IMPLICIT_TRANSACTIONS ON;-- �����. ����� ������� ����������
CREATE TABLE X (VAL INT);-- ������ ���������� 
INSERT X VALUES (1), (2), (3);
SET @C = (SELECT COUNT(*) FROM X);
PRINT '���������� ����� � ������� X: ' + CONVERT(VARCHAR, @C);
IF @FLAG = 'C'-- ���������� ����������: �������� 
COMMIT;
ELSE
ROLLBACK;-- ���������� ����������: �����  
SET IMPLICIT_TRANSACTIONS OFF;--������. ����� ������� ����������

IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'DBO.X'))
PRINT '������� X ����';
ELSE
PRINT '������� X ���';
