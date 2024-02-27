use UNIVER;
select PULPIT.PULPIT_NAME [Кафедра], isnull(TEACHER.TEACHER_NAME, '***') [Преподаватель]
from TEACHER
         left outer join PULPIT
                         on PULPIT.PULPIT = TEACHER.PULPIT;


select PULPIT.PULPIT_NAME as 'Кафедра', isnull(TEACHER.TEACHER_NAME, '***') as 'Преподаватель'
from TEACHER
         right outer join PULPIT
                          on PULPIT.PULPIT = TEACHER.PULPIT;