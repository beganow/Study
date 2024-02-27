CREATE TABLE employees (
    employee_id   NUMBER Primary key,
    first_name    VARCHAR2(50),
    last_name     VARCHAR2(50)
);

CREATE TABLE departments (
    department_id   NUMBER PRIMARY KEY,
    department_name VARCHAR2(50),
    manager_id      NUMBER,
    CONSTRAINT fk_manager
        FOREIGN KEY (manager_id)
        REFERENCES employees (employee_id)
);
INSERT INTO departments (department_id, department_name, manager_id)
VALUES (10, 'Sales', 100);

INSERT INTO departments (department_id, department_name, manager_id)
VALUES (20, 'Marketing', 50);


--drop table employees
select * from employees;
select * from departments;
INSERT INTO employees (employee_id, first_name, last_name)
VALUES (100, 'John', 'Doe');
--task1
DECLARE
   -- Объявляем переменные для хранения значений из запроса
   v_employee_id   employees.employee_id%TYPE;
   v_first_name    employees.first_name%TYPE;
   v_last_name     employees.last_name%TYPE;
BEGIN
   -- Открываем неявный курсор с помощью оператора SELECT
   SELECT employee_id, first_name, last_name
   INTO v_employee_id, v_first_name, v_last_name
   FROM employees
   WHERE employee_id = 100; -- Указываем условие для выборки

   -- Выводим результаты запроса
   DBMS_OUTPUT.PUT_LINE('Employee ID: ' || v_employee_id);


EXCEPTION
   -- Обработка исключений, если происходит ошибка в запросе
   WHEN NO_DATA_FOUND THEN
      DBMS_OUTPUT.PUT_LINE('Employee not found.');

   WHEN OTHERS THEN
      DBMS_OUTPUT.PUT_LINE('An error occurred: ' || SQLCODE || ' - ' || SQLERRM);
END;



--task2
DECLARE
   -- Объявляем переменные для хранения значений из запроса
   v_employee_id   employees.employee_id%TYPE;
   v_first_name    employees.first_name%TYPE;
   v_last_name     employees.last_name%TYPE;

BEGIN
   -- Открываем неявный курсор с помощью оператора SELECT
   SELECT employee_id, first_name, last_name
   INTO v_employee_id, v_first_name, v_last_name
   FROM employees
   WHERE employee_id = 50; -- Указываем условие для выборки

   -- Выводим результаты запроса
   DBMS_OUTPUT.PUT_LINE('Employee ID: ' || v_employee_id);
   DBMS_OUTPUT.PUT_LINE('First Name: ' || v_first_name);
   DBMS_OUTPUT.PUT_LINE('Last Name: ' || v_last_name);

EXCEPTION
   WHEN OTHERS THEN
      DBMS_OUTPUT.PUT_LINE('An error occurred: ' || SQLCODE || ' - ' || SQLERRM);
END;


--task3

DECLARE
   -- Объявляем переменные для хранения значений из запроса
   v_employee_id   employees.employee_id%TYPE;
   v_first_name    employees.first_name%TYPE;
   v_last_name     employees.last_name%TYPE;

BEGIN
   -- Открываем неявный курсор с помощью оператора SELECT
   SELECT employee_id, first_name, last_name
   INTO v_employee_id, v_first_name, v_last_name
   FROM employees
   WHERE last_name = 'Doe'; -- Указываем условие для выборки

   -- Выводим результаты запроса
   DBMS_OUTPUT.PUT_LINE('Employee ID: ' || v_employee_id);
   DBMS_OUTPUT.PUT_LINE('First Name: ' || v_first_name);
   DBMS_OUTPUT.PUT_LINE('Last Name: ' || v_last_name);

EXCEPTION
   -- Обработка исключений, если происходит ошибка в запросе
   WHEN NO_DATA_FOUND THEN
      DBMS_OUTPUT.PUT_LINE('Employee not found.');

   WHEN TOO_MANY_ROWS THEN
      DBMS_OUTPUT.PUT_LINE('Multiple employees found.');

   WHEN OTHERS THEN
      DBMS_OUTPUT.PUT_LINE('An error occurred: ' || SQLCODE || ' - ' || SQLERRM);
END;


--task4
DECLARE
   -- Объявляем переменные для хранения значений из запроса
   v_employee_id   employees.employee_id%TYPE;
   v_first_name    employees.first_name%TYPE;
   v_last_name     employees.last_name%TYPE;

BEGIN
   -- Открываем неявный курсор с помощью оператора SELECT
   SELECT employee_id, first_name, last_name
   INTO v_employee_id, v_first_name, v_last_name
   FROM employees
   WHERE employee_id = 999; -- Указываем условие для выборки

   -- Выводим результаты запроса
   DBMS_OUTPUT.PUT_LINE('Employee ID: ' || v_employee_id);
   DBMS_OUTPUT.PUT_LINE('First Name: ' || v_first_name);
   DBMS_OUTPUT.PUT_LINE('Last Name: ' || v_last_name);

EXCEPTION
   -- Обработка исключений, если происходит ошибка в запросе
   WHEN NO_DATA_FOUND THEN
      DBMS_OUTPUT.PUT_LINE('Employee not found.');

   WHEN OTHERS THEN
      DBMS_OUTPUT.PUT_LINE('An error occurred: ' || SQLCODE || ' - ' || SQLERRM);
END;


--task5
DECLARE
   v_employee_id   employees.employee_id%TYPE;
   v_first_name    employees.first_name%TYPE;
   v_last_name     employees.last_name%TYPE;

   -- Исключение для обработки нарушения уникального ограничения
   DUP_VAL_EXCEPTION EXCEPTION;
   PRAGMA EXCEPTION_INIT(DUP_VAL_EXCEPTION, -00001);

   -- Исключение для обработки нарушения ограничения ссылочной целостности
   FOREIGN_KEY_EXCEPTION EXCEPTION;
   PRAGMA EXCEPTION_INIT(FOREIGN_KEY_EXCEPTION, -02292);

BEGIN
   -- INSERT: Вставка записи без нарушения ограничений
   BEGIN
      INSERT INTO employees (employee_id, first_name, last_name)
      VALUES (100, 'John', 'Doe');
      COMMIT;
   EXCEPTION
      WHEN DUP_VAL_EXCEPTION THEN
         DBMS_OUTPUT.PUT_LINE('Ошибка при вставке: нарушение уникального ограничения.');
   END;

   -- UPDATE: Обновление записи с нарушением ограничения ссылочной целостности
   BEGIN
      UPDATE employees
      SET employee_id = 999
      WHERE employee_id = 100;
   EXCEPTION
      WHEN FOREIGN_KEY_EXCEPTION THEN
         DBMS_OUTPUT.PUT_LINE('Ошибка при обновлении: нарушение ограничения ссылочной целостности.');
   END;

   -- DELETE: Удаление записи с нарушением ограничения ссылочной целостности
   BEGIN
      DELETE FROM employees
      WHERE employee_id = 100;
   EXCEPTION
      WHEN FOREIGN_KEY_EXCEPTION THEN
         DBMS_OUTPUT.PUT_LINE('Ошибка при удалении: нарушение ограничения ссылочной целостности.');
   END;
END;

--task6 
CREATE TABLE teacher (
   teacher_id   NUMBER PRIMARY KEY,
   first_name   VARCHAR2(50),
   last_name    VARCHAR2(50)
);

-- Вставка данных в таблицу TEACHER
INSERT INTO teacher (teacher_id, first_name, last_name)
VALUES (1, 'John', 'Doe');

INSERT INTO teacher (teacher_id, first_name, last_name)
VALUES (2, 'Jane', 'Smith');

-- Проверка данных в таблице TEACHER
SELECT * FROM teacher;


DECLARE
   -- Объявление переменных с использованием опции %TYPE
   v_teacher_id   teacher.teacher_id%TYPE;
   v_first_name   teacher.first_name%TYPE;
   v_last_name    teacher.last_name%TYPE;

   -- Объявление явного курсора
   CURSOR c_teacher IS
      SELECT teacher_id, first_name, last_name
      FROM teacher;

BEGIN
   -- Открытие явного курсора
   OPEN c_teacher;

   -- Цикл LOOP для чтения данных и вывода на печать
   LOOP
      -- Чтение данных в переменные
      FETCH c_teacher INTO v_teacher_id, v_first_name, v_last_name;

      -- Выход из цикла, если достигнут конец набора данных
      EXIT WHEN c_teacher%NOTFOUND;

      -- Вывод данных на печать
      DBMS_OUTPUT.PUT_LINE('Teacher ID: ' || v_teacher_id);
      DBMS_OUTPUT.PUT_LINE('First Name: ' || v_first_name);
      DBMS_OUTPUT.PUT_LINE('Last Name: ' || v_last_name);
      DBMS_OUTPUT.PUT_LINE('---------------------------');
   END LOOP;

   -- Закрытие явного курсора
   CLOSE c_teacher;

EXCEPTION
   WHEN OTHERS THEN
      DBMS_OUTPUT.PUT_LINE('Произошла ошибка: ' || SQLCODE || ' - ' || SQLERRM);
END;


--task7

-- Создание таблицы SUBJECT
CREATE TABLE subject (
   subject_id   NUMBER PRIMARY KEY,
   subject_name VARCHAR2(50)
);
drop table subject;

-- Вставка данных в таблицу SUBJECT
INSERT INTO subject (subject_id, subject_name)
VALUES (1, 'Mathematics');

INSERT INTO subject (subject_id, subject_name)
VALUES (2, 'Science');

-- Проверка данных в таблице SUBJECT
SELECT * FROM subject;


DECLARE
  -- Объявляем курсор
  CURSOR subject_cursor IS
    SELECT *
    FROM SUBJECT;
    
  -- Объявляем переменную для записи данных
  subject_record SUBJECT%ROWTYPE;
BEGIN
  -- Открываем курсор
  OPEN subject_cursor;
  
  -- Читаем данные из курсора и записываем их в переменную
  LOOP
    FETCH subject_cursor INTO subject_record;
    EXIT WHEN subject_cursor%NOTFOUND;
    
    -- Выводим данные на печать
    DBMS_OUTPUT.PUT_LINE('Subject ID: ' || subject_record.subject_id);
    DBMS_OUTPUT.PUT_LINE('Subject Name: ' || subject_record.subject_name);
    DBMS_OUTPUT.PUT_LINE('------------------------');
  END LOOP;
  
  -- Закрываем курсор
  CLOSE subject_cursor;
END;


--task8
CREATE TABLE AUDITORIUM (
    AuditoriumID INT primary key,
    AuditoriumName varchar2(50),
    Capacity INT
);
 
 drop table AUDITORIUM;

INSERT ALL
  INTO AUDITORIUM (AuditoriumID, AuditoriumName, Capacity) VALUES (1, 'Аудитория 1', 15)
  INTO AUDITORIUM (AuditoriumID, AuditoriumName, Capacity) VALUES (2, 'Аудитория 2', 25)
  INTO AUDITORIUM (AuditoriumID, AuditoriumName, Capacity) VALUES (3, 'Аудитория 3', 35)
  INTO AUDITORIUM (AuditoriumID, AuditoriumName, Capacity) VALUES (4, 'Аудитория 4', 45)
  INTO AUDITORIUM (AuditoriumID, AuditoriumName, Capacity) VALUES (5, 'Аудитория 5', 55)
  INTO AUDITORIUM (AuditoriumID, AuditoriumName, Capacity) VALUES (6, 'Аудитория 6', 65)
  INTO AUDITORIUM (AuditoriumID, AuditoriumName, Capacity) VALUES (7, 'Аудитория 7', 75)
  INTO AUDITORIUM (AuditoriumID, AuditoriumName, Capacity) VALUES (8, 'Аудитория 8', 85)
  INTO AUDITORIUM (AuditoriumID, AuditoriumName, Capacity) VALUES (9, 'Аудитория 9', 95)
SELECT * FROM DUAL;

-- Проверка содержимого таблицы
SELECT * FROM AUDITORIUM

CREATE OR REPLACE PROCEDURE print_auditorium_lists AS
  CURSOR c_auditoriums(p_capacity_min INT, p_capacity_max INT) IS
    SELECT *
    FROM AUDITORIUM
    WHERE Capacity >= p_capacity_min AND Capacity <= p_capacity_max;

  v_auditorium AUDITORIUM%ROWTYPE;
BEGIN
  -- Список аудиторий с вместимостью меньше 20
  OPEN c_auditoriums(0, 20);
  DBMS_OUTPUT.PUT_LINE('Список аудиторий с вместимостью меньше 20:');
  LOOP
    FETCH c_auditoriums INTO v_auditorium;
    EXIT WHEN c_auditoriums%NOTFOUND;
    DBMS_OUTPUT.PUT_LINE(v_auditorium.AuditoriumID || ' ' || v_auditorium.AuditoriumName || ' ' || v_auditorium.Capacity);
  END LOOP;
  CLOSE c_auditoriums;

  -- Список аудиторий с вместимостью от 21 до 30
  OPEN c_auditoriums(21, 30);
  DBMS_OUTPUT.PUT_LINE('Список аудиторий с вместимостью от 21 до 30:');
  LOOP
    FETCH c_auditoriums INTO v_auditorium;
    EXIT WHEN c_auditoriums%NOTFOUND;
    DBMS_OUTPUT.PUT_LINE(v_auditorium.AuditoriumID || ' ' || v_auditorium.AuditoriumName || ' ' || v_auditorium.Capacity);
  END LOOP;
  CLOSE c_auditoriums;

  -- Список аудиторий с вместимостью от 31 до 60
  OPEN c_auditoriums(31, 60);
  DBMS_OUTPUT.PUT_LINE('Список аудиторий с вместимостью от 31 до 60:');
  LOOP
    FETCH c_auditoriums INTO v_auditorium;
    EXIT WHEN c_auditoriums%NOTFOUND;
    DBMS_OUTPUT.PUT_LINE(v_auditorium.AuditoriumID || ' ' || v_auditorium.AuditoriumName || ' ' || v_auditorium.Capacity);
  END LOOP;
  CLOSE c_auditoriums;

  -- Список аудиторий с вместимостью от 61 до 80
  OPEN c_auditoriums(61, 80);
  DBMS_OUTPUT.PUT_LINE('Список аудиторий с вместимостью от 61 до 80:');
  LOOP
    FETCH c_auditoriums INTO v_auditorium;
    EXIT WHEN c_auditoriums%NOTFOUND;
    DBMS_OUTPUT.PUT_LINE(v_auditorium.AuditoriumID || ' ' || v_auditorium.AuditoriumName || ' ' || v_auditorium.Capacity);
  END LOOP;
  CLOSE c_auditoriums;

  -- Список аудиторий с вместимостью 81 и выше
  OPEN c_auditoriums(81, 9999);
  DBMS_OUTPUT.PUT_LINE('Список аудиторий с вместимостью 81 и выше:');
  LOOP
    FETCH c_auditoriums INTO v_auditorium;
    EXIT WHEN c_auditoriums%NOTFOUND;
    DBMS_OUTPUT.PUT_LINE(v_auditorium.AuditoriumID || ' ' || v_auditorium.AuditoriumName || ' ' || v_auditorium.Capacity);
  END LOOP;
  CLOSE c_auditoriums;
END;

BEGIN
  print_auditorium_lists;
END;



--task9

CREATE OR REPLACE PROCEDURE demonstrate_refcursor(
  min_capacity INT,
  max_capacity INT
) AS
  v_cursor SYS_REFCURSOR;
  v_auditorium AUDITORIUM%ROWTYPE;
BEGIN
  -- Открываем курсорную переменную с помощью курсора с параметрами
  OPEN v_cursor FOR
    SELECT *
    FROM AUDITORIUM
    WHERE Capacity >= min_capacity AND Capacity <= max_capacity;

  -- Извлекаем и печатаем данные из курсорной переменной
  LOOP
    FETCH v_cursor INTO v_auditorium;
    EXIT WHEN v_cursor%NOTFOUND;
    DBMS_OUTPUT.PUT_LINE(v_auditorium.AuditoriumID || ' ' || v_auditorium.AuditoriumName || ' ' || v_auditorium.Capacity);
  END LOOP;

  -- Закрываем курсорную переменную
  CLOSE v_cursor;
END;


BEGIN
  -- Вызываем процедуру и передаем параметры
  demonstrate_refcursor(min_capacity => 21, max_capacity => 80);
END;


--task10

CREATE OR REPLACE PROCEDURE decrease_capacity AS
  CURSOR c_auditoriums IS
    SELECT *
    FROM AUDITORIUM
    WHERE Capacity >= 40 AND Capacity <= 80
    FOR UPDATE OF Capacity;

  v_auditorium AUDITORIUM%ROWTYPE;
BEGIN
  -- Изменяем вместимость всех аудиторий с помощью явного курсора
  FOR v_auditorium IN c_auditoriums LOOP
    UPDATE AUDITORIUM
    SET Capacity = Capacity * 0.9
    WHERE CURRENT OF c_auditoriums;
  END LOOP;

  -- Коммит изменений
  COMMIT;
END;

BEGIN
  decrease_capacity;
END;


select * from AUDITORIUM;