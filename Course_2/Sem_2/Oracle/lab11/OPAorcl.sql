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
   -- ��������� ���������� ��� �������� �������� �� �������
   v_employee_id   employees.employee_id%TYPE;
   v_first_name    employees.first_name%TYPE;
   v_last_name     employees.last_name%TYPE;
BEGIN
   -- ��������� ������� ������ � ������� ��������� SELECT
   SELECT employee_id, first_name, last_name
   INTO v_employee_id, v_first_name, v_last_name
   FROM employees
   WHERE employee_id = 100; -- ��������� ������� ��� �������

   -- ������� ���������� �������
   DBMS_OUTPUT.PUT_LINE('Employee ID: ' || v_employee_id);


EXCEPTION
   -- ��������� ����������, ���� ���������� ������ � �������
   WHEN NO_DATA_FOUND THEN
      DBMS_OUTPUT.PUT_LINE('Employee not found.');

   WHEN OTHERS THEN
      DBMS_OUTPUT.PUT_LINE('An error occurred: ' || SQLCODE || ' - ' || SQLERRM);
END;



--task2
DECLARE
   -- ��������� ���������� ��� �������� �������� �� �������
   v_employee_id   employees.employee_id%TYPE;
   v_first_name    employees.first_name%TYPE;
   v_last_name     employees.last_name%TYPE;

BEGIN
   -- ��������� ������� ������ � ������� ��������� SELECT
   SELECT employee_id, first_name, last_name
   INTO v_employee_id, v_first_name, v_last_name
   FROM employees
   WHERE employee_id = 50; -- ��������� ������� ��� �������

   -- ������� ���������� �������
   DBMS_OUTPUT.PUT_LINE('Employee ID: ' || v_employee_id);
   DBMS_OUTPUT.PUT_LINE('First Name: ' || v_first_name);
   DBMS_OUTPUT.PUT_LINE('Last Name: ' || v_last_name);

EXCEPTION
   WHEN OTHERS THEN
      DBMS_OUTPUT.PUT_LINE('An error occurred: ' || SQLCODE || ' - ' || SQLERRM);
END;


--task3

DECLARE
   -- ��������� ���������� ��� �������� �������� �� �������
   v_employee_id   employees.employee_id%TYPE;
   v_first_name    employees.first_name%TYPE;
   v_last_name     employees.last_name%TYPE;

BEGIN
   -- ��������� ������� ������ � ������� ��������� SELECT
   SELECT employee_id, first_name, last_name
   INTO v_employee_id, v_first_name, v_last_name
   FROM employees
   WHERE last_name = 'Doe'; -- ��������� ������� ��� �������

   -- ������� ���������� �������
   DBMS_OUTPUT.PUT_LINE('Employee ID: ' || v_employee_id);
   DBMS_OUTPUT.PUT_LINE('First Name: ' || v_first_name);
   DBMS_OUTPUT.PUT_LINE('Last Name: ' || v_last_name);

EXCEPTION
   -- ��������� ����������, ���� ���������� ������ � �������
   WHEN NO_DATA_FOUND THEN
      DBMS_OUTPUT.PUT_LINE('Employee not found.');

   WHEN TOO_MANY_ROWS THEN
      DBMS_OUTPUT.PUT_LINE('Multiple employees found.');

   WHEN OTHERS THEN
      DBMS_OUTPUT.PUT_LINE('An error occurred: ' || SQLCODE || ' - ' || SQLERRM);
END;


--task4
DECLARE
   -- ��������� ���������� ��� �������� �������� �� �������
   v_employee_id   employees.employee_id%TYPE;
   v_first_name    employees.first_name%TYPE;
   v_last_name     employees.last_name%TYPE;

BEGIN
   -- ��������� ������� ������ � ������� ��������� SELECT
   SELECT employee_id, first_name, last_name
   INTO v_employee_id, v_first_name, v_last_name
   FROM employees
   WHERE employee_id = 999; -- ��������� ������� ��� �������

   -- ������� ���������� �������
   DBMS_OUTPUT.PUT_LINE('Employee ID: ' || v_employee_id);
   DBMS_OUTPUT.PUT_LINE('First Name: ' || v_first_name);
   DBMS_OUTPUT.PUT_LINE('Last Name: ' || v_last_name);

EXCEPTION
   -- ��������� ����������, ���� ���������� ������ � �������
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

   -- ���������� ��� ��������� ��������� ����������� �����������
   DUP_VAL_EXCEPTION EXCEPTION;
   PRAGMA EXCEPTION_INIT(DUP_VAL_EXCEPTION, -00001);

   -- ���������� ��� ��������� ��������� ����������� ��������� �����������
   FOREIGN_KEY_EXCEPTION EXCEPTION;
   PRAGMA EXCEPTION_INIT(FOREIGN_KEY_EXCEPTION, -02292);

BEGIN
   -- INSERT: ������� ������ ��� ��������� �����������
   BEGIN
      INSERT INTO employees (employee_id, first_name, last_name)
      VALUES (100, 'John', 'Doe');
      COMMIT;
   EXCEPTION
      WHEN DUP_VAL_EXCEPTION THEN
         DBMS_OUTPUT.PUT_LINE('������ ��� �������: ��������� ����������� �����������.');
   END;

   -- UPDATE: ���������� ������ � ���������� ����������� ��������� �����������
   BEGIN
      UPDATE employees
      SET employee_id = 999
      WHERE employee_id = 100;
   EXCEPTION
      WHEN FOREIGN_KEY_EXCEPTION THEN
         DBMS_OUTPUT.PUT_LINE('������ ��� ����������: ��������� ����������� ��������� �����������.');
   END;

   -- DELETE: �������� ������ � ���������� ����������� ��������� �����������
   BEGIN
      DELETE FROM employees
      WHERE employee_id = 100;
   EXCEPTION
      WHEN FOREIGN_KEY_EXCEPTION THEN
         DBMS_OUTPUT.PUT_LINE('������ ��� ��������: ��������� ����������� ��������� �����������.');
   END;
END;

--task6 
CREATE TABLE teacher (
   teacher_id   NUMBER PRIMARY KEY,
   first_name   VARCHAR2(50),
   last_name    VARCHAR2(50)
);

-- ������� ������ � ������� TEACHER
INSERT INTO teacher (teacher_id, first_name, last_name)
VALUES (1, 'John', 'Doe');

INSERT INTO teacher (teacher_id, first_name, last_name)
VALUES (2, 'Jane', 'Smith');

-- �������� ������ � ������� TEACHER
SELECT * FROM teacher;


DECLARE
   -- ���������� ���������� � �������������� ����� %TYPE
   v_teacher_id   teacher.teacher_id%TYPE;
   v_first_name   teacher.first_name%TYPE;
   v_last_name    teacher.last_name%TYPE;

   -- ���������� ������ �������
   CURSOR c_teacher IS
      SELECT teacher_id, first_name, last_name
      FROM teacher;

BEGIN
   -- �������� ������ �������
   OPEN c_teacher;

   -- ���� LOOP ��� ������ ������ � ������ �� ������
   LOOP
      -- ������ ������ � ����������
      FETCH c_teacher INTO v_teacher_id, v_first_name, v_last_name;

      -- ����� �� �����, ���� ��������� ����� ������ ������
      EXIT WHEN c_teacher%NOTFOUND;

      -- ����� ������ �� ������
      DBMS_OUTPUT.PUT_LINE('Teacher ID: ' || v_teacher_id);
      DBMS_OUTPUT.PUT_LINE('First Name: ' || v_first_name);
      DBMS_OUTPUT.PUT_LINE('Last Name: ' || v_last_name);
      DBMS_OUTPUT.PUT_LINE('---------------------------');
   END LOOP;

   -- �������� ������ �������
   CLOSE c_teacher;

EXCEPTION
   WHEN OTHERS THEN
      DBMS_OUTPUT.PUT_LINE('��������� ������: ' || SQLCODE || ' - ' || SQLERRM);
END;


--task7

-- �������� ������� SUBJECT
CREATE TABLE subject (
   subject_id   NUMBER PRIMARY KEY,
   subject_name VARCHAR2(50)
);
drop table subject;

-- ������� ������ � ������� SUBJECT
INSERT INTO subject (subject_id, subject_name)
VALUES (1, 'Mathematics');

INSERT INTO subject (subject_id, subject_name)
VALUES (2, 'Science');

-- �������� ������ � ������� SUBJECT
SELECT * FROM subject;


DECLARE
  -- ��������� ������
  CURSOR subject_cursor IS
    SELECT *
    FROM SUBJECT;
    
  -- ��������� ���������� ��� ������ ������
  subject_record SUBJECT%ROWTYPE;
BEGIN
  -- ��������� ������
  OPEN subject_cursor;
  
  -- ������ ������ �� ������� � ���������� �� � ����������
  LOOP
    FETCH subject_cursor INTO subject_record;
    EXIT WHEN subject_cursor%NOTFOUND;
    
    -- ������� ������ �� ������
    DBMS_OUTPUT.PUT_LINE('Subject ID: ' || subject_record.subject_id);
    DBMS_OUTPUT.PUT_LINE('Subject Name: ' || subject_record.subject_name);
    DBMS_OUTPUT.PUT_LINE('------------------------');
  END LOOP;
  
  -- ��������� ������
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
  INTO AUDITORIUM (AuditoriumID, AuditoriumName, Capacity) VALUES (1, '��������� 1', 15)
  INTO AUDITORIUM (AuditoriumID, AuditoriumName, Capacity) VALUES (2, '��������� 2', 25)
  INTO AUDITORIUM (AuditoriumID, AuditoriumName, Capacity) VALUES (3, '��������� 3', 35)
  INTO AUDITORIUM (AuditoriumID, AuditoriumName, Capacity) VALUES (4, '��������� 4', 45)
  INTO AUDITORIUM (AuditoriumID, AuditoriumName, Capacity) VALUES (5, '��������� 5', 55)
  INTO AUDITORIUM (AuditoriumID, AuditoriumName, Capacity) VALUES (6, '��������� 6', 65)
  INTO AUDITORIUM (AuditoriumID, AuditoriumName, Capacity) VALUES (7, '��������� 7', 75)
  INTO AUDITORIUM (AuditoriumID, AuditoriumName, Capacity) VALUES (8, '��������� 8', 85)
  INTO AUDITORIUM (AuditoriumID, AuditoriumName, Capacity) VALUES (9, '��������� 9', 95)
SELECT * FROM DUAL;

-- �������� ����������� �������
SELECT * FROM AUDITORIUM

CREATE OR REPLACE PROCEDURE print_auditorium_lists AS
  CURSOR c_auditoriums(p_capacity_min INT, p_capacity_max INT) IS
    SELECT *
    FROM AUDITORIUM
    WHERE Capacity >= p_capacity_min AND Capacity <= p_capacity_max;

  v_auditorium AUDITORIUM%ROWTYPE;
BEGIN
  -- ������ ��������� � ������������ ������ 20
  OPEN c_auditoriums(0, 20);
  DBMS_OUTPUT.PUT_LINE('������ ��������� � ������������ ������ 20:');
  LOOP
    FETCH c_auditoriums INTO v_auditorium;
    EXIT WHEN c_auditoriums%NOTFOUND;
    DBMS_OUTPUT.PUT_LINE(v_auditorium.AuditoriumID || ' ' || v_auditorium.AuditoriumName || ' ' || v_auditorium.Capacity);
  END LOOP;
  CLOSE c_auditoriums;

  -- ������ ��������� � ������������ �� 21 �� 30
  OPEN c_auditoriums(21, 30);
  DBMS_OUTPUT.PUT_LINE('������ ��������� � ������������ �� 21 �� 30:');
  LOOP
    FETCH c_auditoriums INTO v_auditorium;
    EXIT WHEN c_auditoriums%NOTFOUND;
    DBMS_OUTPUT.PUT_LINE(v_auditorium.AuditoriumID || ' ' || v_auditorium.AuditoriumName || ' ' || v_auditorium.Capacity);
  END LOOP;
  CLOSE c_auditoriums;

  -- ������ ��������� � ������������ �� 31 �� 60
  OPEN c_auditoriums(31, 60);
  DBMS_OUTPUT.PUT_LINE('������ ��������� � ������������ �� 31 �� 60:');
  LOOP
    FETCH c_auditoriums INTO v_auditorium;
    EXIT WHEN c_auditoriums%NOTFOUND;
    DBMS_OUTPUT.PUT_LINE(v_auditorium.AuditoriumID || ' ' || v_auditorium.AuditoriumName || ' ' || v_auditorium.Capacity);
  END LOOP;
  CLOSE c_auditoriums;

  -- ������ ��������� � ������������ �� 61 �� 80
  OPEN c_auditoriums(61, 80);
  DBMS_OUTPUT.PUT_LINE('������ ��������� � ������������ �� 61 �� 80:');
  LOOP
    FETCH c_auditoriums INTO v_auditorium;
    EXIT WHEN c_auditoriums%NOTFOUND;
    DBMS_OUTPUT.PUT_LINE(v_auditorium.AuditoriumID || ' ' || v_auditorium.AuditoriumName || ' ' || v_auditorium.Capacity);
  END LOOP;
  CLOSE c_auditoriums;

  -- ������ ��������� � ������������ 81 � ����
  OPEN c_auditoriums(81, 9999);
  DBMS_OUTPUT.PUT_LINE('������ ��������� � ������������ 81 � ����:');
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
  -- ��������� ��������� ���������� � ������� ������� � �����������
  OPEN v_cursor FOR
    SELECT *
    FROM AUDITORIUM
    WHERE Capacity >= min_capacity AND Capacity <= max_capacity;

  -- ��������� � �������� ������ �� ��������� ����������
  LOOP
    FETCH v_cursor INTO v_auditorium;
    EXIT WHEN v_cursor%NOTFOUND;
    DBMS_OUTPUT.PUT_LINE(v_auditorium.AuditoriumID || ' ' || v_auditorium.AuditoriumName || ' ' || v_auditorium.Capacity);
  END LOOP;

  -- ��������� ��������� ����������
  CLOSE v_cursor;
END;


BEGIN
  -- �������� ��������� � �������� ���������
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
  -- �������� ����������� ���� ��������� � ������� ������ �������
  FOR v_auditorium IN c_auditoriums LOOP
    UPDATE AUDITORIUM
    SET Capacity = Capacity * 0.9
    WHERE CURRENT OF c_auditoriums;
  END LOOP;

  -- ������ ���������
  COMMIT;
END;

BEGIN
  decrease_capacity;
END;


select * from AUDITORIUM;