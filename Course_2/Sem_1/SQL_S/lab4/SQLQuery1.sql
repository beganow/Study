USE UNIVER;
SELECT AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
FROM AUDITORIUM_TYPE
         Inner Join AUDITORIUM
                    on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE;

go
USE [Ободов ПРОДАЖИ]
SELECT ЗАКАЗЫ.[Наименование_товара],ТОВАРЫ.Цена, Заказы.Цена_продажи
			FROM Заказы Inner Join Товары 
			on Заказы.[Наименование_товара]=Товары.Наименование AND ЗАКАЗЫ.Наименование_товара LIKE '%ш%'