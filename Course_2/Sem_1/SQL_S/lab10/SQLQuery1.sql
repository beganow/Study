/*1. ����������� ��������, �����-������ ������ ��������� �� �����-�� ����. 
� ����� ������ ���� ��-������ ������� �������� (���� SUBJECT) �� ������� SUBJECT � ���� ������ ����� �������. 
������������ ���������� ����-��� RTRIM.
*/

USE UNIVER

DECLARE @ONE NVARCHAR(20), @ALL NVARCHAR(300) = '';
DECLARE LINES CURSOR FOR SELECT SUBJECT FROM SUBJECT

OPEN LINES
FETCH LINES INTO @ONE
PRINT '��������'
WHILE @@FETCH_STATUS = 0
BEGIN
SET @ALL = RTRIM(@ONE) + ', ' + @ALL 
FETCH LINES INTO @ONE
END
PRINT RTRIM(@ALL) + ' ��������� ��������'
CLOSE LINES