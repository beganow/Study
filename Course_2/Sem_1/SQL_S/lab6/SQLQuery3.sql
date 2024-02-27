/*3. ����������� ������ �� ������ ������� PROGRESS, ������� �������� ���������� ��������������� ������ � �������� �����-����. ��� ���� ������, ��� ���������� ����� ������ �������������� � �������, �������� �������� ������; ����� �������� � ������� ���������� ������ ���� ����� ���������� ����� � ������� PROGRESS.
������������ ��������� � ������ FROM, � ���������� ��������� GROUP BY, ���-������� ����������� �� ������� �������. � ������ GROUP BY, � SELECT-������ ���������� � � ORDER BY �������� �����-�� ��������� CASE. */

use UNIVER

Select *
from (select case
                 when (PROGRESS.NOTE in (6, 7)) then '6-7'
                 when (PROGRESS.NOTE in (8, 9)) then '8-9'
                 when (PROGRESS.NOTE in (4, 5)) then '4-5'
                 when (PROGRESS.NOTE = 10) then '10'
                 end  [������],
             count(*) [����������]
      from PROGRESS
      group by case
                   when (PROGRESS.NOTE in (6, 7)) then '6-7'
                   when (PROGRESS.NOTE in (8, 9)) then '8-9'
                   when (PROGRESS.NOTE in (4, 5)) then '4-5'
                   when (PROGRESS.NOTE = 10) then '10'
                   end
     ) as a
order by case a.������
               when '6-7' then 3
               when '8-9' then 2
               when '4-5' then 4
               when '10' then 1
               end