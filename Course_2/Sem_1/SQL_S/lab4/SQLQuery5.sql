USE UNIVER;
SELECT STUDENT.[NAME],
       FACULTY.FACULTY,
       PULPIT.PULPIT,
       PROFESSION.PROFESSION_NAME,
       SUBJECT.SUBJECT_NAME,
       case
           when (PROGRESS.NOTE = 6) then 'шесть'
           when (PROGRESS.NOTE = 7) then 'семь'
           when (PROGRESS.NOTE = 8) then 'восемь'
           end [Oценка]
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

USE [Ободов ПРОДАЖИ]
SELECT Товары.Наименование, ЗАКАЗЫ.Дата_поставки,
		Case
		when (ЗАКАЗЫ.Цена_продажи between 1 and 100) then 'цена<100'
		when (ЗАКАЗЫ.Цена_продажи between 100 and 200) then 'цена от 100 до 200'
		else 'цена больше 200'
		end [Пределы цен]
	FROM ТОВАРЫ Inner Join ЗАКАЗЫ
	ON ТОВАРЫ.Наименование=ЗАКАЗЫ.Наименование_товара
ORDER BY
(Case 
	when (Заказы.Цена_продажи between 1 and 100) then 3
	when (Заказы.Цена_продажи between 100 and 200) then 2
	else 1
	end
)




