/*
3. ����������� � ������� ������������� � ������ ���������. ������������� ������ 
���� ��������� �� ������ ������� AUDITO-RIUM � ��������� �������: ��� (AUDITO-RIUM)
, ������������ ��������� (AUDITO-RIUM_NAME). 
������������� ������ ���������� ������ ���������� ��������� (� ������� AUDITO-RIUM_ 
TYPE ������, ������������ � �����-�� ��) � ��������� ���������� ��������� IN-SERT, UPDATE � DELETE.
*/
CREATE VIEW [Auditor] (AUDITORIUM_TYPE,AUDITORIUM)
as select AUDITORIUM.AUDITORIUM_TYPE as [������������ ���������],
AUDITORIUM.AUDITORIUM as [���]
FROM AUDITORIUM
WHERE AUDITORIUM.AUDITORIUM_TYPE LIKE '��%'
go
INSERT  [Auditor] VALUES ('��','��')
DELETE FROM Auditor where AUDITORIUM='��'
UPDATE Auditor SET  AUDITORIUM = 'TEST' 
WHERE AUDITORIUM = '��'
select * from Auditor
drop view Auditor