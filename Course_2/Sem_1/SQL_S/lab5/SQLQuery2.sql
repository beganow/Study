use UNIVER;
/*	2. Переписать запрос пункта 1 таким образом, чтобы тот же подзапрос
                            был за-писан в конструкции INNER JOIN секции FROM внешнего запроса. 
                            При этом ре-зультат выполнения запроса должен быть аналогичным результату 
                            исходного запро-са. */
select PULPIT.PULPIT_NAME from PULPIT inner join FACULTY on  PULPIT.FACULTY = FACULTY.FACULTY
  and FACULTY.FACULTY in (select PROFESSION.FACULTY
                        from PROFESSION
                         where PROFESSION_NAME LIKE ('%технология%')
                            or PROFESSION_NAME LIKE ('%технологии%'))