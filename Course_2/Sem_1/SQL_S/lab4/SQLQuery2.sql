use UNIVER
select AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
from AUDITORIUM_TYPE
         Inner Join AUDITORIUM
                    on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE And
                       AUDITORIUM_TYPE.AUDITORIUM_TYPENAME Like '%���������%';

go
USE [������ �������]
SELECT ������.[������������_������],������.����, ������.����_�������
			FROM ������ Inner Join ������ 
			on ������.[������������_������]=������.������������ AND ������.������������_������ LIKE '%�%'