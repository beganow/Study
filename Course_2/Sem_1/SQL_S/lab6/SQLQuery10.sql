use UNIVER;
select SUBJECT,
       count(NOTE) as [���-��]
from PROGRESS
group by SUBJECT, NOTE
HAVING NOTE in (8, 9)