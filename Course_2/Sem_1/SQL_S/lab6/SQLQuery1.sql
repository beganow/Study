use UNIVER
Select max(AUDITORIUM_CAPACITY) as [������������ ���������������],
 min(AUDITORIUM_CAPACITY) as [����������� ���������������],
 avg(AUDITORIUM_CAPACITY) as [������� ���������������],
 count(*) as [����� ���-�� ���������]
From AUDITORIUM
