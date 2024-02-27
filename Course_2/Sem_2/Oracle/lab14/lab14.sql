CREATE TABLE STUDENTS (
  id NUMBER PRIMARY KEY,
  name VARCHAR2(50),
  age NUMBER,
  email VARCHAR2(100)
);

DROP TABLE STUDENTS;

ALTER TRIGGER prevent_table_drop_trigger DISABLE;



CREATE OR REPLACE TRIGGER prevent_table_drop_trigger
BEFORE DROP ON SCHEMA
DECLARE
  v_object_name VARCHAR2(128);
BEGIN
  SELECT object_name INTO v_object_name
  FROM user_objects
  WHERE object_type = 'TABLE' AND object_name = 'STUDENTS';

  IF v_object_name = 'STUDENTS' THEN     
  DBMS_OUTPUT.PUT_LINE('Trigger: нельзая удалить таблицу ');
    RAISE_APPLICATION_ERROR(-20001, 'Dropping the table "STUDENTS" is not allowed.');
 
  END IF;
END;

INSERT INTO STUDENTS (id, name, age, email)
VALUES (1, 'John Doe', 30, 'johndoe@example.com');

INSERT INTO STUDENTS (id, name, age, email)
VALUES (2, 'Jane Smith', 25, 'janesmith@example.com');

INSERT INTO STUDENTS (id, name, age, email)
VALUES (3, 'Michael Johnson', 40, 'michaeljohnson@example.com');

INSERT INTO STUDENTS (id, name, age, email)
VALUES (4, 'Emily Davis', 28, 'emilydavis@example.com');

INSERT INTO STUDENTS (id, name, age, email)
VALUES (5, 'Daniel Wilson', 35, 'danielwilson@example.com');

INSERT INTO STUDENTS (id, name, age, email)
VALUES (6, 'Sarah Brown', 32, 'sarahbrown@example.com');

INSERT INTO STUDENTS (id, name, age, email)
VALUES (7, 'Matthew Taylor', 27, 'matthewtaylor@example.com');

INSERT INTO STUDENTS (id, name, age, email)
VALUES (8, 'Olivia Anderson', 29, 'oliviaanderson@example.com');

INSERT INTO STUDENTS (id, name, age, email)
VALUES (9, 'James Martinez', 33, 'jamesmartinez@example.com');

INSERT INTO STUDENTS (id, name, age, email)
VALUES (10, 'Sophia Thompson', 31, 'sophiathompson@example.com');




select * from Students;


CREATE USER Pavel IDENTIFIED BY 123;

GRANT CREATE TRIGGER TO Pavel;

GRANT SELECT, INSERT, UPDATE, DELETE ON STUDENTS TO Pavel;
GRANT CREATE SESSION, CONNECT TO Pavel;
GRANT CREATE TABLE TO Pavel;
GRANT SELECT,INSERT ON Pavel.STUDENTS TO Pavel;
GRANT INSERT ANY TABLE TO Pavel;
GRANT ALL PRIVILEGES to Pavel;

CREATE OR REPLACE TRIGGER students_trigger
BEFORE INSERT OR DELETE OR UPDATE
ON Pavel.STUDENTS
DECLARE
  v_event VARCHAR2(10);
BEGIN
  IF INSERTING THEN
    v_event := 'INSERT';
  ELSIF DELETING THEN
    v_event := 'DELETE';
  ELSIF UPDATING THEN
    v_event := 'UPDATE';
  END IF;
  
  DBMS_OUTPUT.PUT_LINE('Trigger name: my_trigger');
  DBMS_OUTPUT.PUT_LINE('Event: ' || v_event);
  -- Дополнительный код, который нужно выполнить перед INSERT/DELETE/UPDATE
    -- Обработка исключений
  BEGIN
    -- Дополнительный код для проверки нарушения целостности по первичному ключу
    -- Если нарушение обнаружено, генерируем исключение
    RAISE_APPLICATION_ERROR(-20001, 'Violation of primary key integrity constraint');
  EXCEPTION
    WHEN OTHERS THEN
      -- Обработка исключений, например, вывод сообщения об ошибке
      DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
  END;
END;

drop trigger students_trigger;


INSERT INTO STUDENTS (id, name, age, email)
VALUES (15, 'Svdsvddvs', 35, 'sophifewathompson@example.com');

UPDATE STUDENTS
SET NAME = 'ПД'
WHERE id = 3;

delete from STUDENTS where id = 5;


CREATE OR REPLACE TRIGGER students_trigger_for_row
BEFORE INSERT OR DELETE OR UPDATE
ON Pavel.STUDENTS 
FOR EACH ROW
DECLARE
  v_event VARCHAR2(10);
BEGIN
  IF INSERTING THEN
    v_event := 'INSERT';
  ELSIF DELETING THEN
    v_event := 'DELETE';
  ELSIF UPDATING THEN
    v_event := 'UPDATE';
  END IF;
  
  DBMS_OUTPUT.PUT_LINE('Trigger name: students_trigger_for_row');
  DBMS_OUTPUT.PUT_LINE('Event: ' || v_event);
  -- Additional code to execute before INSERT/DELETE/UPDATE
  BEGIN
    -- Дополнительный код для проверки нарушения целостности по первичному ключу
    -- Если нарушение обнаружено, генерируем исключение
    RAISE_APPLICATION_ERROR(-20001, 'Violation of primary key integrity constraint');
  EXCEPTION
    WHEN OTHERS THEN
      -- Обработка исключений, например, вывод сообщения об ошибке
      DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
  END;
END;



INSERT INTO STUDENTS (id, name, age, email)
VALUES (12, 'Svdsvfewdvs', 55, 'sophifewdqwathompson@example.com');

INSERT INTO STUDENTS (id, name, age, email)
VALUES (13, 'wdqwdqdwq', 65, 'sophifewwdqathompson@example.com');

UPDATE STUDENTS
SET NAME = 'ПД'
WHERE id = 3;

delete from STUDENTS where id = 5;



CREATE OR REPLACE TRIGGER students_after_trigger
AFTER INSERT OR DELETE OR UPDATE ON Pavel.STUDENTS
DECLARE
  v_event VARCHAR2(10);
BEGIN
  IF INSERTING THEN
    v_event := 'INSERT';
  ELSIF DELETING THEN
    v_event := 'DELETE';
  ELSIF UPDATING THEN
    v_event := 'UPDATE';
  END IF;
  
  DBMS_OUTPUT.PUT_LINE('Trigger name: students_after_trigger');
  DBMS_OUTPUT.PUT_LINE('Event: ' || v_event); 
  BEGIN
    -- Дополнительный код для проверки нарушения целостности по первичному ключу
    -- Если нарушение обнаружено, генерируем исключение
    RAISE_APPLICATION_ERROR(-20001, 'Violation of primary key integrity constraint');
  EXCEPTION
    WHEN OTHERS THEN
      -- Обработка исключений, например, вывод сообщения об ошибке
      DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
  END;
END;



CREATE OR REPLACE TRIGGER students_after_trigger_for_row
AFTER INSERT OR DELETE OR UPDATE ON Pavel.STUDENTS
FOR EACH ROW
DECLARE
  v_event VARCHAR2(10);
BEGIN
  IF INSERTING THEN
    v_event := 'INSERT';
  ELSIF DELETING THEN
    v_event := 'DELETE';
  ELSIF UPDATING THEN
    v_event := 'UPDATE';
  END IF;
  
  DBMS_OUTPUT.PUT_LINE('Trigger name: students_after_trigger_for_ROW');
  DBMS_OUTPUT.PUT_LINE('Event: ' || v_event);  
  BEGIN
    -- Дополнительный код для проверки нарушения целостности по первичному ключу
    -- Если нарушение обнаружено, генерируем исключение
    RAISE_APPLICATION_ERROR(-20001, 'Violation of primary key integrity constraint');
  EXCEPTION
    WHEN OTHERS THEN
      -- Обработка исключений, например, вывод сообщения об ошибке
      DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
  END;
END;




CREATE TABLE AUDITa (
  OperationDate DATE,
  OperationType VARCHAR2(20),
  TriggerName VARCHAR2(50) ,
  Data VARCHAR2(200)
);

DROP TABLE AUDITa;

INSERT INTO AUDITa (OperationDate, OperationType, TriggerName, Data)
VALUES (SYSDATE, 'INSERT', 'trigger_name', 'data_values');

CREATE OR REPLACE TRIGGER audita_trigger
BEFORE INSERT OR DELETE OR UPDATE
ON Pavel.audita
DECLARE
  v_event VARCHAR2(10);
BEGIN
  IF INSERTING THEN
    v_event := 'INSERT';
  ELSIF DELETING THEN
    v_event := 'DELETE';
  ELSIF UPDATING THEN
    v_event := 'UPDATE';
  END IF;
  
  DBMS_OUTPUT.PUT_LINE('Trigger name: my_trigger');
  DBMS_OUTPUT.PUT_LINE('Event: ' || v_event);
  -- Дополнительный код, который нужно выполнить перед INSERT/DELETE/UPDATE
  BEGIN
    -- Дополнительный код для проверки нарушения целостности по первичному ключу
    -- Если нарушение обнаружено, генерируем исключение
    RAISE_APPLICATION_ERROR(-20001, 'Violation of primary key integrity constraint');
  EXCEPTION
    WHEN OTHERS THEN
      -- Обработка исключений, например, вывод сообщения об ошибке
      DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
  END;
END;


CREATE OR REPLACE TRIGGER audita_trigger_for_row
BEFORE INSERT OR DELETE OR UPDATE
ON Pavel.audita 
FOR EACH ROW
DECLARE
  v_event VARCHAR2(10);
BEGIN
  IF INSERTING THEN
    v_event := 'INSERT';
  ELSIF DELETING THEN
    v_event := 'DELETE';
  ELSIF UPDATING THEN
    v_event := 'UPDATE';
  END IF;
  
  DBMS_OUTPUT.PUT_LINE('Trigger name: students_trigger_for_row');
  DBMS_OUTPUT.PUT_LINE('Event: ' || v_event);
  -- Additional code to execute before INSERT/DELETE/UPDATE
  BEGIN
    -- Дополнительный код для проверки нарушения целостности по первичному ключу
    -- Если нарушение обнаружено, генерируем исключение
    RAISE_APPLICATION_ERROR(-20001, 'Violation of primary key integrity constraint');
  EXCEPTION
    WHEN OTHERS THEN
      -- Обработка исключений, например, вывод сообщения об ошибке
      DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
  END;
END;



CREATE OR REPLACE TRIGGER audita_after_trigger
AFTER INSERT OR DELETE OR UPDATE ON Pavel.audita
DECLARE
  v_event VARCHAR2(10);
BEGIN
  IF INSERTING THEN
    v_event := 'INSERT';
  ELSIF DELETING THEN
    v_event := 'DELETE';
  ELSIF UPDATING THEN
    v_event := 'UPDATE';
  END IF;
  
  DBMS_OUTPUT.PUT_LINE('Trigger name: students_after_trigger');
  DBMS_OUTPUT.PUT_LINE('Event: ' || v_event); 
  BEGIN
    -- Дополнительный код для проверки нарушения целостности по первичному ключу
    -- Если нарушение обнаружено, генерируем исключение
    RAISE_APPLICATION_ERROR(-20001, 'Violation of primary key integrity constraint');
  EXCEPTION
    WHEN OTHERS THEN
      -- Обработка исключений, например, вывод сообщения об ошибке
      DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
  END;
END;


CREATE OR REPLACE TRIGGER audita_after_trigger_for_row
AFTER INSERT OR DELETE OR UPDATE ON Pavel.audita
FOR EACH ROW
DECLARE
  v_event VARCHAR2(10);
BEGIN
  IF INSERTING THEN
    v_event := 'INSERT';
  ELSIF DELETING THEN
    v_event := 'DELETE';
  ELSIF UPDATING THEN
    v_event := 'UPDATE';
  END IF;
  
  DBMS_OUTPUT.PUT_LINE('Trigger name: students_after_trigger_for_ROW');
  DBMS_OUTPUT.PUT_LINE('Event: ' || v_event);  
  BEGIN
    -- Дополнительный код для проверки нарушения целостности по первичному ключу
    -- Если нарушение обнаружено, генерируем исключение
    RAISE_APPLICATION_ERROR(-20001, 'Violation of primary key integrity constraint');
  EXCEPTION
    WHEN OTHERS THEN
      -- Обработка исключений, например, вывод сообщения об ошибке
      DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
  END;
END;

select * from audita;



CREATE OR REPLACE VIEW STUDENTS_VIEW AS
SELECT * FROM STUDENTS;

select * from STUDENTS_VIEW;

ALTER TABLE STUDENTS
ADD is_valid NUMBER DEFAULT 1;

CREATE OR REPLACE TRIGGER students_update_trigger
INSTEAD OF UPDATE ON students_view
FOR EACH ROW
BEGIN
  -- Добавляем новую строку в таблицу STUDENTS
  INSERT INTO students (id, name, age, is_valid, email)
  VALUES (:NEW.id, :NEW.name, :NEW.age, 1, :NEW.email);
  
  -- Помечаем старую строку как недействительную
  UPDATE students
  SET is_valid = 0
  WHERE id = :OLD.id;
END;




UPDATE STUDENTS_VIEW
SET age = 25,
    id= 100
WHERE id = 1;




CREATE OR REPLACE TRIGGER trigger1
BEFORE INSERT ON your_table
FOR EACH ROW
BEGIN
  -- Логика первого триггера
  NULL;
END;
/

-- Создание второго триггера
CREATE OR REPLACE TRIGGER trigger2
BEFORE INSERT ON your_table
FOR EACH ROW
FOLLOWS trigger1 -- Указываем, что trigger2 следует за trigger1
BEGIN
  -- Логика второго триггера
  NULL;
END;
/

-- Создание третьего триггера
CREATE OR REPLACE TRIGGER trigger3
BEFORE INSERT ON your_table
FOR EACH ROW
FOLLOWS trigger2 -- Указываем, что trigger3 следует за trigger2
BEGIN
  -- Логика третьего триггера
  NULL;
END;
