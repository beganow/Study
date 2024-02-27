/*На основе таблицы AUDITORIUM сформировать список аудиторий 
самых больших вместимостей (столбец AUDI-TORIUM_CAPACITY) для каждого типа аудитории
(AUDITORIUM_TYPE). При этом результат следует отсортировать в порядке убывания вместимости.
Примеча-ние: использовать коррелируемый подза-прос c секциями TOP и ORDER BY*.*/

use UNIVER

select distinct  AUDITORIUM_TYPE, AUDITORIUM_CAPACITY from AUDITORIUM as a
where AUDITORIUM_CAPACITY =	 
(select top(1) AUDITORIUM_CAPACITY from AUDITORIUM as b
where  b.AUDITORIUM_TYPE= a.AUDITORIUM_TYPE order by AUDITORIUM_CAPACITY desc 
)
order by AUDITORIUM_CAPACITY desc 