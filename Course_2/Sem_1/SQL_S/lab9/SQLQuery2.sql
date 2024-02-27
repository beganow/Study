/*������� ��������� ��������� �������. ��������� �� ������� (10000 ����� ��� ������). 
����������� SELECT-������. �������� ���� ������� � ������-���� ��� ���������. 
������� ������������������ ��-���������� ��������� ������. 
������� ��������� ������ ��-��������.
*/

USE UNIVER;
DROP TABLE #TEST2;
CREATE TABLE #TEST2
(
INFO NVARCHAR (20),
ITERATOR INT IDENTITY(1,1),
INDEX_ INT 
)
/*���������� � ������� 10000 �����*/
DECLARE @X INT =0;
WHILE @X <= 20000
BEGIN
INSERT INTO #TEST2(INFO,INDEX_)
VALUES ('������' + CAST(@X AS NVARCHAR),FLOOR(20000*RAND()))
SET @X +=1;
END

SELECT count(*) [���������� �����] from #TEST2
SELECT * FROM #TEST2
SELECT * FROM #TEST2 WHERE INFO = '������2' AND INDEX_ >= 1000 

CHECKPOINT;

DBCC DROPCLEANBUFFERS
/*������� ������������������ ��-���������� ��������� ������*/
CREATE INDEX #TEST2_NONCL ON #TEST2(INFO,INDEX_)
SELECT * FROM #TEST2 WHERE INFO = '������2' AND INDEX_ >= 1000

DROP INDEX #TEST2_NONCL ON #TEST2