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

use [������ �������] 
select * from ������ at FULL OUTER JOIN ������ aa
 on aa.������������_������=at.������������
	ORDER BY aa.������������_������,at.������������
select COUNT(*) from ������ at FULL OUTER JOIN ������ aa
	on aa.������������_������=at.������������
		Where �����_������ is NULL

