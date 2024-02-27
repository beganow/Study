use UNIVER
select AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPE
from AUDITORIUM cross join AUDITORIUM_TYPE
where AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE;

use [Ободов ПРОДАЖИ]
select distinct ТОВАРЫ.Наименование,ТОВАРЫ.Цена,ЗАКАЗЫ.Цена_продажи
from ЗАКАЗЫ Cross JOIN ТОВАРЫ
Where ЗАКАЗЫ.Наименование_товара=ТОВАРЫ.Наименование