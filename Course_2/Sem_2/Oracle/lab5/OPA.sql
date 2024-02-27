/* task1 */
SELECT tablespace_name FROM dba_tablespaces;

/* task2 */

CREATE TABLESPACE OPA_QDATA
    DATAFILE 'OPA_QDATA.dbf'
    SIZE 10M
    EXTENT MANAGEMENT LOCAL
    ONLINE;
    
    ALTER TABLESPACE OPA_QDATA OFFLINE;
     ALTER TABLESPACE OPA_QDATA ONLINE;
     
     CREATE ROLE RL_OPAQDATA;
     alter session set "_ORACLE_SCRIPT"=true;
        GRANT CONNECT TO RL_OPAQDATA;
        GRANT CREATE SESSION, CONNECT, CREATE TABLE, CREATE VIEW, CREATE PROCEDURE TO RL_OPAQDATA;
     COMMIT;
     
     CREATE PROFILE PF_OPAQDATA LIMIT 
    PASSWORD_LIFE_TIME 180 -- ���������� ���� ����� ������
    SESSIONS_PER_USER 3 -- ���������� ������ ��� �������������
    FAILED_LOGIN_ATTEMPTS 7 -- ���������� ������� ����� 
    PASSWORD_LOCK_TIME 1 -- ���������� ���� ������������ ����� ������
    PASSWORD_REUSE_TIME 10 -- ����� ������� ���� ����� ��������� ������
    PASSWORD_GRACE_TIME DEFAULT -- ���������� ���� �������������� � ����� ������ 
    CONNECT_TIME 180 -- ����� ����������, �����
    IDLE_TIME 30; -- ���������� ����� �������
     
     CREATE USER OPAUSERQDATA IDENTIFIED BY p123
    DEFAULT TABLESPACE OPA_QDATA QUOTA 2M ON OPA_QDATA
    PROFILE PF_OPAQDATA
    ACCOUNT UNLOCK
    PASSWORD EXPIRE;
    
    GRANT RL_OPAQDATA TO OPAUSERQDATA;
    
    
    /*task4*/
    SELECT owner, segment_name, segment_type, tablespace_name
FROM dba_extents
WHERE tablespace_name = 'OPA_QDATA'

/*task 5*/
SELECT owner, segment_name, segment_type, tablespace_name
FROM dba_segments
WHERE segment_name = 'OPA_T1'
  AND segment_type = 'TABLE';
  
  /*task 6*/
  SELECT owner, segment_name, segment_type, tablespace_name
FROM dba_segments



/* task10*/
SELECT segment_name, extent_id, blocks, bytes
FROM dba_extents
WHERE segment_name = 'OPA_T1';

/* task11*/
SELECT tablespace_name, segment_type, owner, segment_name, extent_id, file_id, block_id, blocks
FROM dba_extents;


DROP TABLESPACE OPA_QDATA INCLUDING CONTENTS AND DATAFILES;