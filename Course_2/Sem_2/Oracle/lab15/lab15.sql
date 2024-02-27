--zad1
--DROP TABLE T_RANGE;
CREATE TABLE T_RANGE (
  id NUMBER,
  data VARCHAR2(100),
  CONSTRAINT pk_t_range PRIMARY KEY (id)
)
PARTITION BY RANGE (id) (
  PARTITION p1 VALUES LESS THAN (1000),
  PARTITION p2 VALUES LESS THAN (2000),
  PARTITION p3 VALUES LESS THAN (3000),
  PARTITION p4 VALUES LESS THAN (MAXVALUE)
);

INSERT INTO T_RANGE (id, data) VALUES (500, 'Data for p1');
INSERT INTO T_RANGE (id, data) VALUES (1500, 'Data for p2');
INSERT INTO T_RANGE (id, data) VALUES (2500, 'Data for p3');
INSERT INTO T_RANGE (id, data) VALUES (3500, 'Data for p4');

-- SELECT запрос для проверки
SELECT * FROM T_RANGE PARTITION (p1);


-- Изменение ключа секционирования для строки с id = 500
UPDATE T_RANGE
SET data = 'Data for update p1'
WHERE id = 500;


ALTER TABLE T_RANGE
MERGE PARTITIONS p1,p2
    INTO PARTITION P12;



-- Данные после изменения ключа секционирования
SELECT * FROM T_RANGE PARTITION (P12);
--zad2

CREATE TABLE T_INTERVAL (
  id NUMBER,
  event_date DATE,
  data VARCHAR2(100),
  CONSTRAINT pk_t_interval PRIMARY KEY (id)
)
PARTITION BY RANGE (event_date)
INTERVAL(NUMTOYMINTERVAL(1, 'MONTH'))
(
  PARTITION p1 VALUES LESS THAN (TO_DATE('2023-01-01', 'YYYY-MM-DD')),
  PARTITION p2 VALUES LESS THAN (TO_DATE('2024-01-01', 'YYYY-MM-DD'))
);

INSERT INTO T_INTERVAL (id, event_date, data) VALUES (1, TO_DATE('2023-06-01', 'YYYY-MM-DD'), 'Data for p1');
INSERT INTO T_INTERVAL (id, event_date, data) VALUES (2, TO_DATE('2023-08-01', 'YYYY-MM-DD'), 'Data for p2');
INSERT INTO T_INTERVAL (id, event_date, data) VALUES (3, TO_DATE('2023-10-01', 'YYYY-MM-DD'), 'Data for p3');
INSERT INTO T_INTERVAL (id, event_date, data) VALUES (4, TO_DATE('2024-02-01', 'YYYY-MM-DD'), 'Data for p4');


UPDATE T_INTERVAL
SET id = 5
WHERE id = 3;

-- SELECT запрос для проверки
SELECT * FROM T_INTERVAL Partition (p1B);

ALTER TABLE T_INTERVAL
SPLIT PARTITION p1
    INTO (PARTITION  P1A VALUES LESS THAN (TO_DATE('2022-01-01', 'YYYY-MM-DD')), PARTITION P1B)

--zad3
CREATE TABLE T_HASH (
  id NUMBER,
  key_value VARCHAR2(100),
  data VARCHAR2(100),
  CONSTRAINT pk_t_hash PRIMARY KEY (id)
)
PARTITION BY HASH (key_value)
PARTITIONS 8;

INSERT INTO T_HASH (id, key_value, data) VALUES (1, 'A', 'Data for p1');
INSERT INTO T_HASH (id, key_value, data) VALUES (2, 'B', 'Data for p2');
INSERT INTO T_HASH (id, key_value, data) VALUES (3, 'C', 'Data for p3');
INSERT INTO T_HASH (id, key_value, data) VALUES (4, 'D', 'Data for p4');


UPDATE T_HASH
SET id = 5
WHERE id = 3;
-- SELECT запрос для проверки
SELECT * FROM T_HASH;

CREATE TABLE T_HASH_EXCHANGE (
  id NUMBER,
  key_value VARCHAR2(100),
  data VARCHAR2(100),
  CONSTRAINT pk_t_hash_exchange PRIMARY KEY (id)
);

-- Загрузка данных во вспомогательную таблицу
INSERT INTO T_HASH_EXCHANGE (id, key_value, data)
VALUES (10, 'AAA', 'Data for AAA');


-- Проверка содержимого вспомогательной таблицы
SELECT * FROM T_HASH_EXCHANGE;

-- Выполнение операции обмена секциями
ALTER TABLE T_HASH
EXCHANGE PARTITION FOR ('AAA')
WITH TABLE T_HASH_EXCHANGE;

SELECT * FROM T_HASH;
--zad4
CREATE TABLE T_LIST (
  id NUMBER,
  category CHAR(1),
  data VARCHAR2(100),
  CONSTRAINT pk_t_list PRIMARY KEY (id)
)
PARTITION BY LIST (category)
(
  PARTITION p1 VALUES ('A'),
  PARTITION p2 VALUES ('B'),
  PARTITION p3 VALUES (DEFAULT)
);

INSERT INTO T_LIST (id, category, data) VALUES (1, 'A', 'Data for p1');
INSERT INTO T_LIST (id, category, data) VALUES (2, 'B', 'Data for p2');
INSERT INTO T_LIST (id, category, data) VALUES (3, 'C', 'Data for p3');
INSERT INTO T_LIST (id, category, data) VALUES (4, 'D', 'Data for p4');

UPDATE T_LIST
SET id = 5
WHERE id = 3;

SELECT * FROM T_LIST;

--zad10

select table_name
from user_tab_partitions
GROUP BY table_name;


select partition_name
from user_tab_partitions
where table_name='T_RANGE';

select * from t_range partition (p12);

SELECT ROWID
FROM T_LIST 
WHERE id=2;

select * from T_LIST where ROWID = 'AAASqYAABAAAcfpAAA';