/*5. ����������� ��� �������� A � B �� ������� ���� ���-��� X_UNIVER. 
�������� A � �  ��������-���� ����� ����� ���������� � ������� ��������������� READ COMMITED. 
�������� A ������ �����-����������, ��� ������� READ COMMITED �� �����-���� ����������������� ���-���, �� ��� ���� �������� ��������������� � ��������� ������. 
*/

USE UNIVER;
-- A ---
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRANSACTION
SELECT * FROM SUBJECT WHERE SUBJECT = '��';
-------------------------- T1 ------------------
-------------------------- T2 -----------------
SELECT * FROM SUBJECT WHERE SUBJECT = '��';
COMMIT TRAN;

-----B----
BEGIN TRANSACTION
------T1-----
UPDATE PULPIT SET FACULTY = '��' WHERE PULPIT = '��';
------T2------
ROLLBACK