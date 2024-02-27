/*4. Разработать два сценария A и B на примере базы дан-ных X_UNIVER. 
Сценарий A представляет собой явную транзакцию с уровнем изолированности READ UNCOMMITED,
сцена-рий B – явную транзакцию с уровнем изолированности READ COMMITED (по умол-чанию). 
Сценарий A должен демон-стрировать, что уровень READ UNCOMMITED допус-кает неподтвержденное, непо-вторяющееся и фантомное чтение. 
*/
USE UNIVER;

------A------
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
BEGIN TRANSACTION
-----T1---------
SELECT @@SPID, 'INSERT FACULTY' 'RESULT', *
FROM FACULTY WHERE FACULTY = 'ИИТ';

SELECT @@SPID, 'UPDATE PULPIT' 'RESULT', *
FROM PULPIT WHERE FACULTY = 'ТОВ';
COMMIT;

ROLLBACK;

SELECT * FROM FACULTY;
SELECT * FROM PULPIT;

-----B–-------

BEGIN TRANSACTION
SELECT @@SPID
INSERT FACULTY VALUES('ИИТ','Факультет информационных технологиий');
UPDATE PULPIT SET FACULTY = 'ТОВе' WHERE PULPIT = 'ОХ'
-----T1----------
-----T2----------
ROLLBACK;

DELETE FACULTY WHERE FACULTY = 'ИТ';
SELECT * FROM FACULTY;