use [������ �������];
SELECT ������.������������_������, ������.����_��������, ������.����
FROM ������,������
Where ������.������������_������=������.������������ 
AND �������� in (Select ������������_����� FROM ��������� Where (����� Like 'G%'))
use UNIVER;
/*1. �� ������ ������ FACULTY, PUL-PIT � PROFESSION ������������ ���-���
������������ ������ (������� PUL-PIT_NAME), ������� ��������� �� ��-�������� 
(������� FACULTY), ��������-������ ���������� �� �������������, � ������������
(������� PROFESSION_ NAME) �������� ���������� ����� ���-������� ��� ����������.
����������: ������������ � ������ WHERE �������� IN c ����������������� �����������
� ������� PROFESSION. */
select PULPIT_NAME from PULPIT, FACULTY 
where PULPIT.FACULTY = FACULTY.FACULTY
  and FACULTY.FACULTY in (select PROFESSION.FACULTY
                         from PROFESSION
                         where PROFESSION_NAME LIKE ('%����������%')
                            or PROFESSION_NAME LIKE ('%����������%'))