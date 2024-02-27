/*4. ����������� ��� �������� A � B �� ������� ���� ���-��� X_UNIVER. 
�������� A ������������ ����� ����� ���������� � ������� ��������������� READ UNCOMMITED,
�����-��� B � ����� ���������� � ������� ��������������� READ COMMITED (�� ����-�����). 
�������� A ������ �����-����������, ��� ������� READ UNCOMMITED �����-���� ����������������, ����-����������� � ��������� ������. 
*/
USE UNIVER;

------A------
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
BEGIN TRANSACTION
-----T1---------
SELECT @@SPID, 'INSERT FACULTY' 'RESULT', *
FROM FACULTY WHERE FACULTY = '���';

SELECT @@SPID, 'UPDATE PULPIT' 'RESULT', *
FROM PULPIT WHERE FACULTY = '���';
COMMIT;

ROLLBACK;

SELECT * FROM FACULTY;
SELECT * FROM PULPIT;

-----B�-------

BEGIN TRANSACTION
SELECT @@SPID
INSERT FACULTY VALUES('���','��������� �������������� �����������');
UPDATE PULPIT SET FACULTY = '����' WHERE PULPIT = '��'
-----T1----------
-----T2----------
ROLLBACK;

DELETE FACULTY WHERE FACULTY = '��';
SELECT * FROM FACULTY;