/*zad 1*/
SELECT tablespace_name, contents
FROM dba_tablespaces;
SELECT tablespace_name
FROM dba_tablespaces
WHERE contents = 'PERMANENT';
SELECT tablespace_name
FROM dba_tablespaces
WHERE contents = 'TEMPORARY';
SELECT tablespace_name
FROM dba_tablespaces
WHERE contents = 'UNDO';

/zad 2/

SELECT tablespace_name, file_name
FROM dba_data_files
SELECT tablespace_name, file_name
FROM dba_temp_files
SELECT tablespace_name, file_id, file_name
FROM dba_data_files
WHERE tablespace_name LIKE 'UNDO%';

/zad 3/
SELECT GROUP# 
FROM V$LOG
ORDER BY GROUP#;

SELECT GROUP# 
FROM V$LOG
WHERE STATUS = 'CURRENT';

/zad 4/

SELECT member 
FROM V$LOGFILE
ORDER BY GROUP#, MEMBER;

/zad 5/
ALTER SYSTEM SWITCH LOGFILE;
SELECT MIN(SEQUENCE#) AS min_seq, MAX(SEQUENCE#) AS max_seq, MIN(FIRST_CHANGE#) AS min_scn, MAX(NEXT_CHANGE#) AS max_scn
FROM V$LOG_HISTORY;

/zad 6/
ALTER DATABASE ADD LOGFILE GROUP 6 (
  'D:\ORACLEBD\ORADATA\ORCL\REDO07.LOG',
  'D:\ORACLEBD\ORADATA\ORCL\REDO08.LOG',
  'D:\ORACLEBD\ORADATA\ORCL\REDO09.LOG'
) SIZE 300M;

/zad 7/
ALTER DATABASE DROP LOGFILE GROUP 6;

/zad 8/  
SELECT log_mode FROM v$database;
--ALTER DATABASE NOARCHIVELOG;

/zad 9/
SELECT MAX(sequence#) 
FROM v$archived_log;

/zad 10/

SHUTDOWN IMMEDIATE;
STARTUP MOUNT;
ALTER DATABASE ARCHIVELOG;
ALTER DATABASE OPEN;

/zad 11/
SELECT log_mode FROM v$database;
ALTER SYSTEM ARCHIVE LOG CURRENT;
SHOW PARAMETER LOG_ARCHIVE_DEST_1;
SELECT name, sequence#, first_change#, next_change# FROM v$archived_log ORDER BY sequence#;
SELECT name, first_time, next_time, sequence#, first_change#, next_change# FROM v$archived_log ORDER BY sequence#;

/zad 12/
SELECT log_mode FROM v$database;

/zad 13/
SELECT name FROM v$controlfile;


/zad 14/
SELECT * FROM v$controlfile;

/zad 15/
SELECT GROUP# 
FROM V$LOG
ORDER BY GROUP#;

/*вопрос 17
log_archive_dest_state_X*/

/*вопрос 20
SQL> archive log list;

»спользу€ представление V$RECOVERY_FILE_DEST:

SQL> SELECT * FROM V$RECOVERY_FILE_DEST;*/
