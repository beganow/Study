
--task 1
ALTER TABLE Teacher
ADD (
  BIRTHDAY DATE,
  salary NUMBER(10,2)
);

select * from Teacher;
INSERT INTO teacher (teacher_id, first_name, birthday, salary, last_name) VALUES (3, 'John', TO_DATE('1990-06-14', 'YYYY-MM-DD'), 5000.00, 'Doe');
INSERT INTO teacher (teacher_id, first_name, birthday, salary, last_name) VALUES (4, 'Кристина', TO_DATE('1995-04-12', 'YYYY-MM-DD'), 3000.00, 'Арнольдовна');
INSERT INTO teacher (teacher_id, first_name, birthday, salary, last_name) VALUES (5, 'David', TO_DATE('1992-01-27', 'YYYY-MM-DD'), 4500.00, 'Johnson');
INSERT INTO teacher (teacher_id, first_name, birthday, salary, last_name) VALUES (6, 'Sarah', TO_DATE('1991-02-06', 'YYYY-MM-DD'), 5500.00, 'Williams');
INSERT INTO teacher (teacher_id, first_name, birthday, salary, last_name) VALUES (7, 'Александр', TO_DATE('1956-07-02', 'YYYY-MM-DD'), 100.00, 'Филиппов');
INSERT INTO teacher (teacher_id, first_name, birthday, salary, last_name,deparment,faculty) VALUES (11, 'Алина', TO_DATE('2000-01-01', 'YYYY-MM-DD'), 900.00, 'Бердникова', 'Издательское дело', 'ПИМ');
INSERT INTO teacher (teacher_id, first_name, birthday, salary, last_name,deparment,faculty) VALUES (20, 'Александра', TO_DATE('1976-08-13', 'YYYY-MM-DD'), 1745.00, 'Казаченко', 'Нефть и газ', 'ТОВ');

--task2
CREATE OR REPLACE FUNCTION get_people_born_on_monday
RETURN VARCHAR2
IS
  v_result VARCHAR2(200);
BEGIN
  SELECT LISTAGG(first_name || ' ' || last_name, ', ') WITHIN GROUP (ORDER BY first_name)
  INTO v_result
  FROM teacher
  WHERE TO_CHAR(birthday, 'D') = '1';

  RETURN v_result;
END;

SELECT get_people_born_on_monday() AS people_born_on_monday
FROM DUAL;


--task3
CREATE OR REPLACE VIEW teachers_next_month_birthdays AS
SELECT first_name, last_name, TO_CHAR(birthday, 'DD/MM/YYYY') AS formatted_birthday
FROM teacher
WHERE EXTRACT(MONTH FROM birthday) = EXTRACT(MONTH FROM SYSDATE)+1;


SELECT first_name, last_name, formatted_birthday
FROM teachers_next_month_birthdays;


--task4
CREATE OR REPLACE VIEW teachers_birthdays_by_month AS
SELECT TO_CHAR(birthday, 'Month') AS birth_month, COUNT(*) AS num_teachers
FROM teacher
GROUP BY TO_CHAR(birthday, 'Month')


SELECT birth_month, num_teachers
FROM teachers_birthdays_by_month;

--task5
DECLARE
  CURSOR c_anniversary IS
    SELECT first_name, last_name, birthday, EXTRACT(YEAR FROM ADD_MONTHS(SYSDATE, 12)) - EXTRACT(YEAR FROM birthday) AS age
    FROM teacher
    WHERE EXTRACT(MONTH FROM ADD_MONTHS(SYSDATE, 12)) = EXTRACT(MONTH FROM birthday);
    
  v_first_name teacher.first_name%TYPE;
  v_last_name teacher.last_name%TYPE;
  v_birthday teacher.birthday%TYPE;
  v_age NUMBER;
BEGIN
  OPEN c_anniversary;
  
  LOOP
    FETCH c_anniversary INTO v_first_name, v_last_name, v_birthday, v_age;
    EXIT WHEN c_anniversary%NOTFOUND;
    
    DBMS_OUTPUT.PUT_LINE(v_first_name || ' ' || v_last_name || ' будет иметь юбилей в следующем году. Возраст: ' || v_age || ' лет.');
  END LOOP;
  
  CLOSE c_anniversary;
END;



ALTER TABLE Teacher
ADD (

 faculty VARCHAR2(50)
);

UPDATE teacher
SET deparment = 'ПД'
WHERE teacher_id = 3;


--task6
DECLARE
  CURSOR c_avg_salary_by_department IS
    SELECT deparment, faculty, FLOOR(AVG(salary)) AS avg_salary
    FROM teacher
    GROUP BY deparment, faculty;
    
  v_department teacher.deparment%TYPE;
  v_faculty teacher.faculty%TYPE;
  v_avg_salary NUMBER;
  
  v_total_avg_salary NUMBER := 0;
  v_total_departments NUMBER := 0;
  v_total_faculties NUMBER := 0;
BEGIN
  OPEN c_avg_salary_by_department;
  
  LOOP
    FETCH c_avg_salary_by_department INTO v_department, v_faculty, v_avg_salary;
    EXIT WHEN c_avg_salary_by_department%NOTFOUND;
    
    v_total_avg_salary := v_total_avg_salary + v_avg_salary;
    v_total_departments := v_total_departments + 1;
    v_total_faculties := v_total_faculties + 1;
    
    DBMS_OUTPUT.PUT_LINE('Средняя зарплата для кафедры ' || v_department || ' на факультете ' || v_faculty || ': ' || v_avg_salary);
  END LOOP;
  
  IF v_total_departments > 0 THEN
    DBMS_OUTPUT.PUT_LINE('Средняя зарплата для всех факультетов: ' || FLOOR(v_total_avg_salary / v_total_departments));
  END IF;
  
  CLOSE c_avg_salary_by_department;
END;

--task7
DECLARE
  numerator NUMBER := 10;
  denominator NUMBER := 0;
  result NUMBER;
BEGIN
  BEGIN
    IF denominator = 0 THEN
      RAISE_APPLICATION_ERROR(-20001, 'Ошибка: Деление на ноль недопустимо.');
    END IF;

    result := numerator / denominator;
    DBMS_OUTPUT.PUT_LINE('Результат деления: ' || result);
  EXCEPTION
    WHEN ZERO_DIVIDE THEN
      DBMS_OUTPUT.PUT_LINE('Ошибка: Деление на ноль.');
    WHEN OTHERS THEN
      DBMS_OUTPUT.PUT_LINE('Ошибка: ' || SQLERRM);
  END;
END;


--task8
DECLARE
  v_teacher_name VARCHAR2(100);
  v_teacher_id NUMBER := 13242; -- Задайте здесь нужный код преподавателя

BEGIN
  BEGIN
    SELECT first_name || ' ' || last_name
    INTO v_teacher_name
    FROM teacher
    WHERE teacher_id = v_teacher_id;

    DBMS_OUTPUT.PUT_LINE('Наименование преподавателя: ' || v_teacher_name);
  EXCEPTION
    WHEN NO_DATA_FOUND THEN
      DBMS_OUTPUT.PUT_LINE('Преподаватель не найден!');
      -- WHEN NO_DATA_FOUND THEN
    --DBMS_OUTPUT.PUT_LINE('Это новое сообщение об ошибке для NO_DATA_FOUND!');
    WHEN OTHERS THEN
      DBMS_OUTPUT.PUT_LINE('Ошибка: ' || SQLERRM);
  END;
END;


--task 9
DECLARE
  -- Объявление исключений с разными именами
  custom_exception1 EXCEPTION;
  custom_exception2 EXCEPTION;

  -- Связывание исключений с кодами ошибок с помощью PRAGMA EXCEPTION_INIT
  PRAGMA EXCEPTION_INIT(custom_exception1, -20001);
  PRAGMA EXCEPTION_INIT(custom_exception2, -20002);

BEGIN
  -- Основной блок
  DBMS_OUTPUT.PUT_LINE('Start of main block');

  BEGIN
    -- Вложенный блок
    DBMS_OUTPUT.PUT_LINE('Start of nested block');

    -- Генерация исключения
    RAISE custom_exception1;

    DBMS_OUTPUT.PUT_LINE('End of nested block');
  EXCEPTION
    WHEN custom_exception1 THEN
      DBMS_OUTPUT.PUT_LINE('Exception 1 handled in nested block');
  END;

  DBMS_OUTPUT.PUT_LINE('End of main block');

EXCEPTION
  WHEN custom_exception1 THEN
    DBMS_OUTPUT.PUT_LINE('Exception 1 handled in main block');
  WHEN custom_exception2 THEN
    DBMS_OUTPUT.PUT_LINE('Exception 2 handled in main block');
  WHEN OTHERS THEN
    DBMS_OUTPUT.PUT_LINE('Other exception handled in main block');
END;

--task10
DECLARE
  max_salary NUMBER;
BEGIN
  SELECT MAX(salary)
  INTO max_salary
  FROM teacher
  where teacher_id=12;

  IF max_salary IS NULL THEN
    RAISE NO_DATA_FOUND;
  END IF;
  
  DBMS_OUTPUT.PUT_LINE('Max Salary: ' || max_salary);
EXCEPTION
  WHEN NO_DATA_FOUND THEN
    DBMS_OUTPUT.PUT_LINE('No data found');
END;
