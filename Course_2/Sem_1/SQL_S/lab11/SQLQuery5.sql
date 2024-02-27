/*5. Разработать два сценария A и B на примере базы дан-ных X_UNIVER. 
Сценарии A и В  представ-ляют собой явные транзакции с уровнем изолированности READ COMMITED. 
Сценарий A должен демон-стрировать, что уровень READ COMMITED не допус-кает неподтвержденного чте-ния, но при этом возможно неповторяющееся и фантомное чтение. 
*/

USE UNIVER;
-- A ---
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRANSACTION
SELECT * FROM SUBJECT WHERE SUBJECT = 'БД';
-------------------------- T1 ------------------
-------------------------- T2 -----------------
SELECT * FROM SUBJECT WHERE SUBJECT = 'БД';
COMMIT TRAN;

-----B----
BEGIN TRANSACTION
------T1-----
UPDATE PULPIT SET FACULTY = 'ИТ' WHERE PULPIT = 'ТЛ';
------T2------
ROLLBACK