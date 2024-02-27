/* task3 */
CREATE TABLE OPA_T1 (
  id NUMBER(10) PRIMARY KEY,
  value VARCHAR2(50)
);
SELECT table_name, tablespace_name 
FROM all_tables 
WHERE table_name = 'OPA_T1';
DROP TABLE OPA_T1
INSERT ALL
  INTO OPA_T1 (id, value) VALUES (1, 'Pavel')
  INTO OPA_T1 (id, value) VALUES (2, 'Alex')
  INTO OPA_T1 (id, value) VALUES (3, 'Mary')
SELECT * FROM dual;

SELECT * FROM OPA_T1;

/*task7*/
SELECT object_name, original_name, type
FROM user_recyclebin;


/*task8*/
FLASHBACK TABLE OPA_T1 TO BEFORE DROP;


/* task 9*/

DECLARE
  v_id NUMBER := 20; 
  i NUMBER := 1;
 
BEGIN
  WHILE i <= 10000 LOOP
    INSERT INTO opa_t1 (id, value)
    VALUES (v_id, dbms_random.string('U', 10));
    v_id:= v_id + 1;
    i := i + 1;
  END LOOP;
  COMMIT;
END;

DELETE FROM OPA_T1 WHERE rownum = 1;
INSERT INTO OPA_T1 (id, value) VALUES (1111, 'restored_value');
UPDATE OPA_T1 SET value = 'new' WHERE id = 1111;

/* task 12*/
SELECT ROWID FROM OPA_T1;

SELECT id, value, ORA_ROWSCN, rowe_id FROM OPA_T1;


ALTER TABLE OPA_T1 ADD rowe_id ROWID;

UPDATE OPA_T1 SET rowe_id = ROWID;

--ALTER TABLE OPA_T1 ADD PRIMARY KEY (row_id);


SELECT column_name, data_type FROM user_tab_columns WHERE table_name = 'OPA_T1';
