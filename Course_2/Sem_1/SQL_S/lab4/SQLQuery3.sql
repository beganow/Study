USE UNIVER;

SELECT AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
FROM AUDITORIUM_TYPE,
     AUDITORIUM
WHERE AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE;

SELECT T2.AUDITORIUM, T1.AUDITORIUM_TYPENAME
FROM AUDITORIUM_TYPE As T1,
     AUDITORIUM As T2
WHERE T1.AUDITORIUM_TYPE = T2.AUDITORIUM_TYPE AND T1.AUDITORIUM_TYPENAME Like '%���������%';

go
USE [������ �������]
SELECT ������.������������,������.����, ������.����_�������
FROM ������,������ 
Where ������.[������������_������]=������.������������ 

SELECT T3.������������,T3.����,T4.����_�������
		From ������ As T4, ������ As T3
			Where T4.������������_������=T3.������������ AND T4.������������_������ LIKE '�%'