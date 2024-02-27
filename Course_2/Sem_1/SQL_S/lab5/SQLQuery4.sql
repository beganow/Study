/*�� ������ ������� AUDITORIUM ������������ ������ ��������� 
����� ������� ������������ (������� AUDI-TORIUM_CAPACITY) ��� ������� ���� ���������
(AUDITORIUM_TYPE). ��� ���� ��������� ������� ������������� � ������� �������� �����������.
�������-���: ������������ ������������� �����-���� c �������� TOP � ORDER BY*.*/

use UNIVER

select distinct  AUDITORIUM_TYPE, AUDITORIUM_CAPACITY from AUDITORIUM as a
where AUDITORIUM_CAPACITY =	 
(select top(1) AUDITORIUM_CAPACITY from AUDITORIUM as b
where  b.AUDITORIUM_TYPE= a.AUDITORIUM_TYPE order by AUDITORIUM_CAPACITY desc 
)
order by AUDITORIUM_CAPACITY desc 