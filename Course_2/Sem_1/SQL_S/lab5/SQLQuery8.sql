use UNIVER;
/*8. ����������� SELECT-������, �����-���������� ������� ���������� 
ANY ��������� � �����������.*/
use UNIVER
select SUBJECT, NOTE, IDSTUDENT from PROGRESS
	where NOTE =all (select NOTE from PROGRESS
		where IDSTUDENT=1019 and SUBJECT like '��%')