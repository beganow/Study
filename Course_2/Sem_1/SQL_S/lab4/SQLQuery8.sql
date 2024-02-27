use UNIVER;

    SELECT NAME, YEAR_FIRST
    From GROUPS
             Left OUTER JOIN STUDENT S2 on GROUPS.IDGROUP = S2.IDGROUP

    SELECT NAME, YEAR_FIRST
    From GROUPS
             RIGHT outer join STUDENT S3 on GROUPS.IDGROUP = S3.IDGROUP

select PULPIT.FACULTY, PULPIT.PULPIT, PULPIT.PULPIT_NAME
from PULPIT full outer join TEACHER
on PULPIT.PULPIT = TEACHER.PULPIT
where TEACHER.TEACHER is null

select TEACHER.TEACHER_NAME, TEACHER.TEACHER, TEACHER.PULPIT,TEACHER.GENDER
from PULPIT full outer join TEACHER
on PULPIT.PULPIT=TEACHER.PULPIT
where TEACHER.TEACHER is not null

select * from PULPIT full outer join TEACHER
on PULPIT.PULPIT = TEACHER.PULPIT

use [Ободов ПРОДАЖИ] 
select * from ТОВАРЫ at FULL OUTER JOIN ЗАКАЗЫ aa
 on aa.Наименование_товара=at.Наименование
	ORDER BY aa.Наименование_товара,at.Наименование
select COUNT(*) from ТОВАРЫ at FULL OUTER JOIN ЗАКАЗЫ aa
	on aa.Наименование_товара=at.Наименование
		Where Номер_заказа is NULL

