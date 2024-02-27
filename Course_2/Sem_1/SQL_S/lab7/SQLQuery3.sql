/*
3. Разработать и создать представление с именем Аудитории. Представление должно 
быть построено на основе таблицы AUDITO-RIUM и содержать столбцы: код (AUDITO-RIUM)
, наименование аудитории (AUDITO-RIUM_NAME). 
Представление должно отображать только лекционные аудитории (в столбце AUDITO-RIUM_ 
TYPE строка, начинающаяся с симво-ла ЛК) и допускать выполнение оператора IN-SERT, UPDATE и DELETE.
*/
CREATE VIEW [Auditor] (AUDITORIUM_TYPE,AUDITORIUM)
as select AUDITORIUM.AUDITORIUM_TYPE as [наименование аудитории],
AUDITORIUM.AUDITORIUM as [код]
FROM AUDITORIUM
WHERE AUDITORIUM.AUDITORIUM_TYPE LIKE 'ЛК%'
go
INSERT  [Auditor] VALUES ('ЛК','ЛК')
DELETE FROM Auditor where AUDITORIUM='ЛК'
UPDATE Auditor SET  AUDITORIUM = 'TEST' 
WHERE AUDITORIUM = 'ЛК'
select * from Auditor
drop view Auditor