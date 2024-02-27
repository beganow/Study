use UNIVER;

select * from FACULTY 
where not exists (select * from PULPIT where PULPIT.FACULTY = FACULTY.FACULTY);