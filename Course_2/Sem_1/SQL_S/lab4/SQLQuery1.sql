USE UNIVER;
SELECT AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
FROM AUDITORIUM_TYPE
         Inner Join AUDITORIUM
                    on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE;

go
USE [������ �������]
SELECT ������.[������������_������],������.����, ������.����_�������
			FROM ������ Inner Join ������ 
			on ������.[������������_������]=������.������������ AND ������.������������_������ LIKE '%�%'