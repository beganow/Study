use UNIVER
select AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
from AUDITORIUM_TYPE
         Inner Join AUDITORIUM
                    on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE And
                       AUDITORIUM_TYPE.AUDITORIUM_TYPENAME Like '%компьютер%';

go
USE [Ободов ПРОДАЖИ]
SELECT ЗАКАЗЫ.[Наименование_товара],ТОВАРЫ.Цена, Заказы.Цена_продажи
			FROM Заказы Inner Join Товары 
			on Заказы.[Наименование_товара]=Товары.Наименование AND ЗАКАЗЫ.Наименование_товара LIKE '%ш%'