use UNIVER
/*3. ���������� ������, ����������� 1 ����� ��� ������������� ����������.
����������: ������������ ���������� INNER JOIN ���� ������. */
	   select  distinct PULPIT_NAME from PULPIT
	 join FACULTY 
               on PULPIT.FACULTY = FACULTY.FACULTY
			 join PROFESSION 
			   on   FACULTY.FACULTY  = PROFESSION.FACULTY 
		where PROFESSION_NAME LIKE '%���������%'