/*4. ����������� � ������� ������������� � ������ ����������_���������. 
������������� ������ ���� ��������� �� ������ SELECT-������� � ������� AUDITORIUM � ��������� ��������� �������: ��� (AUDITORIUM), ������������ ��������� (AUDITORIUM_NAME). 
������������� ������ ���������� ������ ���������� ��������� (� ������� AUDITORIUM_TYPE ������, ������������ � �������� ��). 
���������� INSERT � UPDATE �����������, �� � ������ �����������, ����������� ������ WITH CHECK OPTION. */

USE UNIVER;
GO 
CREATE VIEW  [���������� ���������] (AUDITORIUM_TYPE,AUDITORIUM)
as select AUDITORIUM.AUDITORIUM_TYPE as [������������ ���������],
AUDITORIUM.AUDITORIUM as [���]
FROM AUDITORIUM
WHERE AUDITORIUM.AUDITORIUM_TYPE LIKE '��%' WITH CHECK OPTION
go
SELECT * FROM [���������� ���������]