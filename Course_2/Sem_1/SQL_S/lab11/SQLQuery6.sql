/*6. ����������� ��� �������� A � B �� ������� ���� ������ X_UNIVER. 
�������� A ������������ ����� ����� ���������� � ������� ��������������� REPEATABLE READ. �����-��� B � ����� ���������� � ������� ��������������� READ COMMITED. 
�������� A ������ �����-����������, ��� ������� REAPETABLE READ �� ��-������� ����������������� ������ � ���������������� ������, �� ��� ���� �������� ��������� ������. 
*/

USE UNIVER;
--------A---------
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
BEGIN TRANSACTION
SELECT PULPIT FROM PULPIT WHERE FACULTY = '��';
--------T1---------
--------T2---------
SELECT CASE
WHEN PULPIT = '��' THEN 'INSERT'  
ELSE ' ' 
END,
PULPIT FROM PULPIT WHERE FACULTY = '��'
COMMIT


--- B ---	
BEGIN TRANSACTION 	  
--------T1---------
UPDATE PULPIT SET FACULTY = '��' WHERE PULPIT = '��';
COMMIT
--------T2---------