DECLARE
  v_variable VARCHAR2(10) := 'Hello';
BEGIN
  NULL;
END;


BEGIN
  DBMS_OUTPUT.PUT_LINE('Hello World!');
END;

SELECT keyword FROM v$reserved_words;



DECLARE
  -- Объявление и инициализация целых number-переменных
  v_integer1 NUMBER := 10;
  v_integer2 NUMBER := 5;
  v_integer_result NUMBER;
  
  -- Арифметические операции над целыми number-переменными
  v_addition_result NUMBER;
  v_subtraction_result NUMBER;
  v_multiplication_result NUMBER;
  v_division_result NUMBER;
  v_modulo_result NUMBER;
  
  -- Объявление и инициализация number-переменных с фиксированной точкой
  v_number1 NUMBER(10, 2) := 3.14;
  v_number2 NUMBER(8, -3) := 1234.56789;
  
  -- Объявление number-переменных с точкой и использованием символа E
  v_scientific_number NUMBER := 1.23E+4;
  
  -- Объявление и инициализация переменных типа даты
  v_date_var DATE := SYSDATE;
  
  -- Объявление и инициализация символьных переменных различной семантики
  v_varchar_var VARCHAR2(100) := 'Hello, PL/SQL!';
  v_char_var CHAR(5) := 'World';
  
  -- Объявление и инициализация BOOLEAN-переменных
  v_boolean_var BOOLEAN := TRUE;
BEGIN
  -- Арифметические операции над целыми number-переменными
  v_addition_result := v_integer1 + v_integer2;
  v_subtraction_result := v_integer1 - v_integer2;
  v_multiplication_result := v_integer1 * v_integer2;
  v_division_result := v_integer1 / v_integer2;
  v_modulo_result := v_integer1 MOD v_integer2;
  
  -- Вывод результатов в выходной серверный поток
  DBMS_OUTPUT.put_line('Addition result: ' || v_addition_result);
  DBMS_OUTPUT.put_line('Subtraction result: ' || v_subtraction_result);
  DBMS_OUTPUT.put_line('Multiplication result: ' || v_multiplication_result);
  DBMS_OUTPUT.put_line('Division result: ' || v_division_result);
  DBMS_OUTPUT.put_line('Modulo result: ' || v_modulo_result);
  
  DBMS_OUTPUT.put_line('Number 1: ' || v_number1);
  DBMS_OUTPUT.put_line('Number 2: ' || v_number2);
  
  DBMS_OUTPUT.put_line('Scientific number: ' || v_scientific_number);
  
  DBMS_OUTPUT.put_line('Date variable: ' || TO_CHAR(v_date_var, 'DD-MON-YYYY'));
  
  DBMS_OUTPUT.put_line('Varchar variable: ' || v_varchar_var);
  DBMS_OUTPUT.put_line('Char variable: ' || v_char_var);
  
  DBMS_OUTPUT.put_line('Boolean variable: ' ||CASE WHEN v_boolean_var THEN 'TRUE' ELSE 'FALSE' END);
END;






DECLARE
  -- Объявление и инициализация констант
  v_varchar2_const CONSTANT VARCHAR2(20) := 'Constant String';
  v_char_const CONSTANT CHAR(5) := 'Hello';
  v_number_const CONSTANT NUMBER := 1234;
  
  -- Объявление переменных для демонстрации операций с константами
  v_result_string VARCHAR2(50);
  v_result_number NUMBER;
BEGIN
  -- Примеры операций с константами
  
  -- Конкатенация VARCHAR2 константы с другой строкой
  v_result_string := v_varchar2_const || ' - appended string';
  DBMS_OUTPUT.put_line('Concatenated string: ' || v_result_string);
  
  -- Использование CHAR константы в условии IF
  IF v_char_const = 'Hello' THEN
    DBMS_OUTPUT.put_line('CHAR constant matches');
  ELSE
    DBMS_OUTPUT.put_line('CHAR constant does not match');
  END IF;
  
  -- Арифметические операции с NUMBER константой
  v_result_number := v_number_const * 2;
  DBMS_OUTPUT.put_line('Result of multiplication: ' || v_result_number);
  
  v_result_number := v_number_const + 100;
  DBMS_OUTPUT.put_line('Result of addition: ' || v_result_number);
  
  v_result_number := v_number_const / 3;
  DBMS_OUTPUT.put_line('Result of division: ' || v_result_number);
  
  v_result_number := v_number_const - 500;
  DBMS_OUTPUT.put_line('Result of subtraction: ' || v_result_number);
  
  -- Попытка изменить значение константы (это вызовет ошибку компиляции)
  v_varchar2_const := 'New Value';
END;





DECLARE
  -- Объявление переменной с опцией %TYPE
  v_employee_id FACULTY.FACULTY%TYPE;
  v_employee_name FACULTY.FACULTY_NAME%TYPE;
BEGIN
  -- Присвоение значений переменным с помощью SELECT INTO
  SELECT FACULTY, FACULTY_NAME
  INTO v_employee_id, v_employee_name
  FROM FACULTY
  WHERE FACULTY = 'ТОВ';

  -- Вывод значений переменных
  DBMS_OUTPUT.put_line('FACULTY ID: ' || v_employee_id);
  DBMS_OUTPUT.put_line('FACULTY Name: ' || v_employee_name);
END;





DECLARE
  -- Объявление переменной с опцией %ROWTYPE
  v_employee FACULTY%ROWTYPE;
BEGIN
  -- Присвоение значений переменной с помощью SELECT INTO
  SELECT *
  INTO v_employee
  FROM FACULTY
  WHERE FACULTY = 'ТОВ';

  -- Вывод значений переменных
  DBMS_OUTPUT.put_line('Employee ID: ' || v_employee.FACULTY);
  DBMS_OUTPUT.put_line('First Name: ' || v_employee.FACULTY_NAME);
END;



DECLARE
  v_number1 NUMBER := 10;
  v_number2 NUMBER := 5;
  v_boolean BOOLEAN := TRUE;
BEGIN
  -- Пример 1: Простой оператор IF
  IF v_number1 > v_number2 THEN
    DBMS_OUTPUT.put_line('v_number1 больше, чем v_number2');
  END IF;
  
  -- Пример 2: Оператор IF-ELSE
  IF v_number1 > v_number2 THEN
    DBMS_OUTPUT.put_line('v_number1 больше, чем v_number2');
  ELSE
    DBMS_OUTPUT.put_line('v_number1 не больше, чем v_number2');
  END IF;
  
  -- Пример 3: Оператор IF-ELSIF-ELSE
  IF v_number1 > v_number2 THEN
    DBMS_OUTPUT.put_line('v_number1 больше, чем v_number2');
  ELSIF v_number1 < v_number2 THEN
    DBMS_OUTPUT.put_line('v_number1 меньше, чем v_number2');
  ELSE
    DBMS_OUTPUT.put_line('v_number1 равно v_number2');
  END IF;
  
  -- Пример 4: Вложенные операторы IF
  IF v_number1 > v_number2 THEN
    DBMS_OUTPUT.put_line('v_number1 больше, чем v_number2');
    
    IF v_boolean THEN
      DBMS_OUTPUT.put_line('v_boolean равно TRUE');
    END IF;
  END IF;
  
  -- Пример 5: Оператор IF с логическими операторами
  IF v_number1 > v_number2 AND v_boolean = TRUE THEN
    DBMS_OUTPUT.put_line('Оба условия выполнены');
  ELSIF v_number1 > v_number2 OR v_boolean = TRUE THEN
    DBMS_OUTPUT.put_line('Хотя бы одно условие выполнено');
  ELSE
    DBMS_OUTPUT.put_line('Оба условия не выполнены');
  END IF;
END;


DECLARE
  grade VARCHAR2(1) := 'A';
BEGIN
  CASE grade
    WHEN 'A' THEN DBMS_OUTPUT.PUT_LINE('Отлично');
    WHEN 'B' THEN DBMS_OUTPUT.PUT_LINE('Хорошо');
    WHEN 'C' THEN DBMS_OUTPUT.PUT_LINE('Удовлетворительно');
    WHEN 'D' THEN DBMS_OUTPUT.PUT_LINE('Неудовлетворительно');
    ELSE DBMS_OUTPUT.PUT_LINE('Неизвестный балл');
  END CASE;
END;


DECLARE
  age NUMBER := 25;
BEGIN
  CASE
    WHEN age BETWEEN 18 AND 24 THEN DBMS_OUTPUT.PUT_LINE('Вы молоды!');
    WHEN age BETWEEN 25 AND 40 THEN DBMS_OUTPUT.PUT_LINE('Вы в самом расцвете сил!');
    WHEN age > 40 THEN DBMS_OUTPUT.PUT_LINE('Вы знаете жизнь во всех ее проявлениях!');
    ELSE DBMS_OUTPUT.PUT_LINE('Вы еще слишком молоды или ввели неверное значение');
  END CASE;
END;



DECLARE
  counter NUMBER := 1;
BEGIN
  LOOP
    DBMS_OUTPUT.PUT_LINE('Counter: ' || counter);
    counter := counter + 1;
    
    IF counter > 5 THEN
      EXIT; -- Выход из цикла, когда значение counter превышает 5
    END IF;
  END LOOP;
END;


DECLARE
  counter NUMBER := 1;
BEGIN
  WHILE counter <= 5 LOOP
    DBMS_OUTPUT.PUT_LINE('Counter: ' || counter);
    counter := counter + 1;
  END LOOP;
END;

DECLARE
  counter NUMBER;
BEGIN
  FOR counter IN 1..5 LOOP
    DBMS_OUTPUT.PUT_LINE('Counter: ' || counter);
  END LOOP;
END;