use UNIVER;

select PULPIT.PULPIT_NAME [Кафедра], isnull(TEACHER.TEACHER_NAME, '***') [Преподаватель]
from PULPIT
         Left outer join TEACHER
                         on PULPIT.PULPIT = TEACHER.PULPIT;
use [Ободов ПРОДАЖИ]
select distinct isnull (Заказы.Наименование_товара, '***')[Товар],
Товары.Количество
	From ТОВАРЫ Left Outer JOIN ЗАКАЗЫ
			On ТОВАРЫ.Наименование=ЗАКАЗЫ.Наименование_товара