/*
1. ����������� ������������� � ������ ���-����������. ������������� ������ ���� ��-�������
�� ������ SELECT-������� � ������� TEACHER � ��������� ��������� �������:
��� (TEACHER), ��� ������������� (TEACHER_NAME),
��� (GENDER), ��� ������� (PULPIT). */

USE UNIVER;
go
CREATE VIEW [�������������] 
as select
TEACHER.TEACHER [���],
TEACHER.TEACHER_NAME [��� �������������],
TEACHER.GENDER [���],
TEACHER.PULPIT [��� �������]
FROM TEACHER;
go
SELECT * FROM [�������������]
GO
DROP VIEW [�������������]