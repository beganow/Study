USE UNIVER;

SELECT AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
FROM AUDITORIUM_TYPE,
     AUDITORIUM
WHERE AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE;

SELECT T2.AUDITORIUM, T1.AUDITORIUM_TYPENAME
FROM AUDITORIUM_TYPE As T1,
     AUDITORIUM As T2
WHERE T1.AUDITORIUM_TYPE = T2.AUDITORIUM_TYPE AND T1.AUDITORIUM_TYPENAME Like '%компьютер%';

go
USE [Ободов ПРОДАЖИ]
SELECT ТОВАРЫ.Наименование,ТОВАРЫ.Цена, Заказы.Цена_продажи
FROM Заказы,Товары 
Where Заказы.[Наименование_товара]=Товары.Наименование 

SELECT T3.Наименование,T3.Цена,T4.Цена_продажи
		From Заказы As T4, Товары As T3
			Where T4.Наименование_товара=T3.Наименование AND T4.Наименование_товара LIKE 'ш%'