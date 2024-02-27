CREATE TABLE my_table (
  id NUMBER,
  name VARCHAR2(50),
  CONSTRAINT my_table_pk PRIMARY KEY (id)
)
STORAGE (
  BUFFER_POOL KEEP
)
TABLESPACE OPA_QDATA;

INSERT INTO my_table (id, name) values (1,'Pavel');
INSERT INTO my_table (id, name) values (2,'Enste');
INSERT INTO my_table (id, name) values (3,'Cube');
INSERT INTO my_table (id, name) values (4,'Alex');
SELECT * from my_table;

SELECT * FROM V$SEGMENT_STATISTICS
WHERE object_name = 'MY_TABLE';


CREATE TABLE my_table1 (
  id NUMBER,
  name VARCHAR2(50),
  CONSTRAINT my_table1_pk PRIMARY KEY (id)
)
STORAGE (
  BUFFER_POOL DEFAULT
)
TABLESPACE OPA_QDATA;

INSERT INTO my_table1 (id, name) values (1,'Pavel');
INSERT INTO my_table1 (id, name) values (2,'Enste');
INSERT INTO my_table1 (id, name) values (3,'Cube');
INSERT INTO my_table1 (id, name) values (4,'Alex');