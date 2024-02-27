USE UNIVER;
SELECT STUDENT.[NAME],
       FACULTY.FACULTY,
       PULPIT.PULPIT,
       PROFESSION.PROFESSION_NAME,
       SUBJECT.SUBJECT_NAME,
       case
           when (PROGRESS.NOTE = 6) then '�����'
           when (PROGRESS.NOTE = 7) then '����'
           when (PROGRESS.NOTE = 8) then '������'
           end [O�����]
from PROGRESS
          join STUDENT on PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
          join [SUBJECT] on [SUBJECT].[SUBJECT] = PROGRESS.[SUBJECT]
          join GROUPS on GROUPS.IDGROUP = STUDENT.IDGROUP
          join PROFESSION on PROFESSION.PROFESSION = GROUPS.PROFESSION
          join PULPIT on PULPIT.PULPIT = [SUBJECT].PULPIT
          join FACULTY on FACULTY.FACULTY = PULPIT.FACULTY
where PROGRESS.NOTE between 6 and 8
order by (case
              when (PROGRESS.NOTE = 6) then 3
              when (PROGRESS.NOTE = 7) then 2
              when (PROGRESS.NOTE = 8) then 1
    end);

USE [������ �������]
SELECT ������.������������, ������.����_��������,
		Case
		when (������.����_������� between 1 and 100) then '����<100'
		when (������.����_������� between 100 and 200) then '���� �� 100 �� 200'
		else '���� ������ 200'
		end [������� ���]
	FROM ������ Inner Join ������
	ON ������.������������=������.������������_������
ORDER BY
(Case 
	when (������.����_������� between 1 and 100) then 3
	when (������.����_������� between 100 and 200) then 2
	else 1
	end
)




