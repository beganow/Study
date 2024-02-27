/*1. � ������� SSMS ���������� ��� �������, ������� ������� � �� UNIVER. ����������,
����� �� ��� �������� �����������������, � ��-��� �������������������. 
������� ��������� ��������� �������. ��������� �� ������� (�� ����� 1000 �����). 
����������� SELECT-������. ��-������ ���� ������� � ���������� ��� ���������. 
������� ���������������� ������, ����������� ��������� SELECT-�������.
-- �������� ��������*/
USE UNIVER;

EXEC SP_HELPINDEX 'AUDITORIUM_TYPE' 

CREATE TABLE #TIMETEST
(INDEX_ INT, 
MESSAGES_
NVARCHAR(20))

SET NOCOUNT ON

DECLARE @I INT = 0
WHILE @I < 1000
BEGIN
INSERT #TIMETEST(INDEX_, MESSAGES_) VALUES (FLOOR(20000*RAND()), REPLICATE('������ ', 3))
IF (@I % 100 = 0) PRINT @I;
SET @I = @I + 1
END

SELECT * FROM #TIMETEST WHERE INDEX_ BETWEEN 1000 AND 1500 ORDER BY INDEX_ 

CHECKPOINT; 

DBCC DROPCLEANBUFFERS

CREATE CLUSTERED INDEX TIMETEST_CL ON #TIMETEST(INDEX_ asc)

SELECT * FROM #TIMETEST WHERE INDEX_ BETWEEN 1500 AND 2500 ORDER BY INDEX_

DROP INDEX TIMETEST_CL ON #TIMETEST