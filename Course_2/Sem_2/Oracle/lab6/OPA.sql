/*task 1*/
show parameter pfile

SELECT value
FROM v$parameter
WHERE name = 'spfile';

/*cmd task2*/
dir D:\ORACLE\DATABASE\SPFILEORCL.ORA 

/*task 3*/
CREATE PFILE='D:\Oracle\database\OPA_PFILE.ora' FROM SPFILE;

/* task5 */
CREATE SPFILE='SPFILEORCL1.ORA' FROM PFILE='D:\Oracle\database\OPA_PFILE.ora';
ALTER SYSTEM SET OPEN_CURSORS = 400 SCOPE=SPFILE

/* task 6*/
select name, value from v$parameter where name='open_cursors';

/* task 8*/
SELECT * FROM v$controlfile;

SELECT * from v$controlfile_record_section;

/* task 9*/
ALTER DATABASE BACKUP CONTROLFILE TO TRACE AS 'D:\OracleBD\oradata\ORCL\controlfile.bak';


SELECT value FROM v$parameter WHERE name = 'diagnostic_dest'

/* task 12 */

select * from v$diag_info;

