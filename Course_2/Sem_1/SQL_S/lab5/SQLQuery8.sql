use UNIVER;
/*8. Разработать SELECT-запрос, демон-стрирующий принцип применения 
ANY совместно с подзапросом.*/
use UNIVER
select SUBJECT, NOTE, IDSTUDENT from PROGRESS
	where NOTE =all (select NOTE from PROGRESS
		where IDSTUDENT=1019 and SUBJECT like 'КГ%')