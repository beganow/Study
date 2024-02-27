use UNIVER;
select SUBJECT,
       count(NOTE) as [Кол-во]
from PROGRESS
group by SUBJECT, NOTE
HAVING NOTE in (8, 9)