use UNIVER;

select PULPIT.PULPIT_NAME [�������], isnull(TEACHER.TEACHER_NAME, '***') [�������������]
from PULPIT
         Left outer join TEACHER
                         on PULPIT.PULPIT = TEACHER.PULPIT;
use [������ �������]
select distinct isnull (������.������������_������, '***')[�����],
������.����������
	From ������ Left Outer JOIN ������
			On ������.������������=������.������������_������