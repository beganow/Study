use UNIVER
select  Name, BDAY from STUDENT a
where BDAY in ( select BDAY from STUDENT group by BDAY having count(BDAY)>1 )
order by BDAY