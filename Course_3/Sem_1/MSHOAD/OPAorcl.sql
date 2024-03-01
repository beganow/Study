--alter session set "_ORACLE_SCRIPT"=true

CREATE USER TransportServiceUser IDENTIFIED BY 1234;
GRANT CONNECT, RESOURCE, CREATE SESSION, CREATE TABLE TO TransportServiceUser;

-- Использование схемы пользователя
ALTER SESSION SET CURRENT_SCHEMA = TransportServiceUser;

select * from Vehicles;


INSERT ALL
    INTO Vehicles (Vehicle_id, type, License_Plate, model, status_id, location, fuel, issue_year, color)
    VALUES (2, 'Cupe', 'ABC123', 'BMW M3', 1, 'Parking Lot A', 'Gasoline', '2020', 'Blue')
    INTO Vehicles (Vehicle_id, type, License_Plate, model, status_id, location, fuel, issue_year, color)
    VALUES (3, 'Sedan', 'DEF456', 'Mercedes E-Class', 1, 'Parking Lot B', 'Gasoline', '2019', 'Black')
    INTO Vehicles (Vehicle_id, type, License_Plate, model, status_id, location, fuel, issue_year, color)
    VALUES (4, 'SUV', 'GHI789', 'Toyota Highlander', 1, 'Parking Lot C', 'Hybrid', '2021', 'Silver')
    -- Добавьте сюда остальные 17 записей с аналогичной структурой
    SELECT * FROM dual;
-- Создание таблицы Customers для клиентов
CREATE TABLE Customers (
    Customer_id NUMBER(10) PRIMARY KEY,
    Name_cst NVARCHAR2(50),
    Surname_cst NVARCHAR2(50),
    Addres_cst NVARCHAR2(50),
    Phone_cst NVARCHAR2(50),
    Email_cst NVARCHAR2(50)
);

-- Создание таблицы Drivers для водителей
CREATE TABLE Drivers (
    drv_id NUMBER(10) PRIMARY KEY,
    Name_drv NVARCHAR2(50),
    Surname_drv NVARCHAR2(50),
    Addres_drv NVARCHAR2(50),
    Phone_drv NVARCHAR2(50),
    driver_licence NVARCHAR2(50)
);

-- Создание таблицы Reviews для отзывов
CREATE TABLE Reviews (
    Review_ID NUMBER(10) PRIMARY KEY,
    grade NUMBER(5),
    Comments NVARCHAR2(50),
    datetime_review DATE
);

-- Создание таблицы Status для статусов
CREATE TABLE Status (
    status_id NUMBER(10) PRIMARY KEY,
    Status_name NVARCHAR2(50)
);

-- Создание таблицы Vehicles для транспортных средств
CREATE TABLE Vehicles (
    Vehicle_id NUMBER(10) PRIMARY KEY,
    type NVARCHAR2(50),
    License_Plate NVARCHAR2(10),
    model NVARCHAR2(50),
    status_id NUMBER(10),
    location NVARCHAR2(50),
    fuel NVARCHAR2(50),
    issue_year NVARCHAR2(4),
    color NVARCHAR2(50),
    FOREIGN KEY (status_id) REFERENCES Status(status_id)
);

-- Создание таблицы Methods для методов оплаты
CREATE TABLE Methods (
    id NUMBER(10) PRIMARY KEY,
    method_name NVARCHAR2(50)
);

-- Создание таблицы Orders для заказов
CREATE TABLE Orders (
    Order_id NUMBER(10) PRIMARY KEY,
    driver_id NUMBER(10),
    client_id NUMBER(10),
    id_review NUMBER(10),
    car_id NUMBER(10),
    Order_DateTime DATE, -- Здесь используем DATE вместо TIMESTAMP
    startpoint NVARCHAR2(50),
    endpoint NVARCHAR2(50),
    price NUMBER(10),
    status_id NUMBER(10),
    FOREIGN KEY (client_id) REFERENCES Customers(Customer_id),
    FOREIGN KEY (driver_id) REFERENCES Drivers(drv_id),
    FOREIGN KEY (car_id) REFERENCES Vehicles(Vehicle_id),
    FOREIGN KEY (id_review) REFERENCES Reviews(Review_ID),
    FOREIGN KEY (status_id) REFERENCES Status(status_id)
);

-- Создание таблицы Payments для платежей
CREATE TABLE Payments (
    payment_id NUMBER(10) PRIMARY KEY,
    id_order NUMBER(10),
    Amount NUMBER(10),
    datetimepay DATE, -- Здесь используем DATE вместо TIMESTAMP
    method_id NUMBER(10),
    FOREIGN KEY (id_order) REFERENCES Orders(Order_id),
    FOREIGN KEY (method_id) REFERENCES Methods(id)
);

select * from Payments;

INSERT INTO Customers ( Customer_id,
    Name_cst,
    Surname_cst,
    Addres_cst,
    Phone_cst,
    Email_cst)
VALUES (1,'Pavel', 'Obodov', 'city Minsk, ul.Sverdlova', '+375445436789', 'email455@gmail.com');

INSERT INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES (1, 'Jane', 'Smith', '456 Elm St', '987-654-3210', 'DL123456');

INSERT INTO Reviews (Review_ID, grade, Comments, datetime_review)
VALUES (1, 5, 'Excellent service!', TO_DATE('2023-10-20', 'YYYY-MM-DD'));

INSERT INTO Status (status_id, Status_name)
VALUES (1, 'Active');

INSERT INTO Vehicles (Vehicle_id, type, License_Plate, model, status_id, location, fuel, issue_year, color)
VALUES (1, 'Sedan', 'ABC123', 'Toyota Camry', 1, 'Parking Lot A', 'Gasoline', '2020', 'Silver');

INSERT INTO Methods (id, method_name)
VALUES (1, 'Credit Card');

INSERT INTO Orders (Order_id, driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
VALUES (1, 1, 1, 1, 1, TO_DATE('2023-10-20 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), '123 Start St', '456 End St', 50, 1);

INSERT INTO Payments (payment_id, id_order, Amount, datetimepay, method_id)
VALUES (1, 1, 50, TO_DATE('2023-10-20 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), 1);

CREATE OR REPLACE VIEW CustomerOrderStatus AS
SELECT
    o.Order_id,
    c.Name_cst || ' ' || c.Surname_cst AS Customer_Name,
    v.License_Plate AS Vehicle_License_Plate,
    o.Order_DateTime AS Order_Date,
    s.Status_name AS Order_Status
FROM
    Orders o
    JOIN Customers c ON o.client_id = c.Customer_id
    JOIN Vehicles v ON o.car_id = v.Vehicle_id
    JOIN Status s ON o.status_id = s.status_id;
    
    
    SELECT * FROM CustomerOrderStatus;
    
    
    
    CREATE OR REPLACE VIEW VehicleOrderDriver AS
SELECT
    o.Order_id,
    d.Name_drv || ' ' || d.Surname_drv AS Driver_Name,
    v.License_Plate AS Vehicle_License_Plate,
    o.Order_DateTime AS Order_Date
FROM
    Orders o
    JOIN Drivers d ON o.driver_id = d.drv_id
    JOIN Vehicles v ON o.car_id = v.Vehicle_id;
    
    SELECT * FROM VehicleOrderDriver;
    
    

    
    DROP INDEX IX_Customers_Email;
    CREATE INDEX IX_Drivers_Driver_licence ON Drivers(driver_licence);
    
    CREATE INDEX IX_Vehicles_Model ON Vehicles(model);
    
    
    
CREATE OR REPLACE TRIGGER PreventDuplicateVehicleAssignment
BEFORE INSERT ON Orders
FOR EACH ROW
DECLARE
    v_vehicle_status NUMBER;
BEGIN
    -- Получаем статус выбранного автомобиля
    SELECT status_id INTO v_vehicle_status
    FROM Vehicles
    WHERE Vehicle_id = :NEW.car_id;
    
    -- Проверяем, что статус автомобиля не равен "Занят"
    IF v_vehicle_status = 1 THEN -- Предположим, что статус "Занят" имеет ID 1
        RAISE_APPLICATION_ERROR(-20001, 'Этот автомобиль уже занят другим заказом');
    END IF;
END;


SELECT Email_cst FROM Customers where Email_cst='email455@gmail.com';

INSERT INTO Customers (Customer_id, Name_cst, Surname_cst, Addres_cst, Phone_cst, Email_cst)
VALUES (1, 'John', 'Doe', '123 Main St', '123-456-7890', 'john.doe@example.com');

CREATE OR REPLACE PROCEDURE AddPaymentMethod(methodid IN NUMBER, methodName IN NVARCHAR2)
IS
BEGIN
    INSERT INTO Methods (id, method_name)
    VALUES (methodid, methodName);
END AddPaymentMethod;

DECLARE
    Methodid NUMBER(10) := 2;
    MethodName NVARCHAR2(50) := 'PayPal'; -- Замените на желаемое имя метода оплаты
BEGIN
    AddPaymentMethod(Methodid, MethodName);
END;

CREATE OR REPLACE FUNCTION CalculateTotalPayment(orderId IN NUMBER)
RETURN NUMBER
IS
    TotalPayment NUMBER;
BEGIN
    SELECT SUM(Amount) INTO TotalPayment
    FROM Payments
    WHERE id_order = orderId;

    RETURN TotalPayment;
END CalculateTotalPayment;


DECLARE
    OrderId NUMBER := 1; -- Замените на фактический OrderId
    TotalAmount NUMBER;
BEGIN
    TotalAmount := CalculateTotalPayment(OrderId);
    DBMS_OUTPUT.PUT_LINE('TotalPayment: ' || TotalAmount);
END;


CREATE OR REPLACE PROCEDURE InsertCustomer (
    Customer_id_cst IN NUMBER,
    p_name_cst IN NVARCHAR2,
    p_surname_cst IN NVARCHAR2,
    p_address_cst IN NVARCHAR2,
    p_phone_cst IN NVARCHAR2,
    p_email_cst IN NVARCHAR2
) AS
BEGIN
    INSERT INTO Customers (Customer_id, Name_cst, Surname_cst, Addres_cst, Phone_cst, Email_cst)
    VALUES (Customer_id_cst, p_name_cst, p_surname_cst, p_address_cst, p_phone_cst, p_email_cst);
    COMMIT;
END InsertCustomer;

BEGIN
    InsertCustomer(10, 'Иван', 'Иванов', 'ул. Примерная, д. 123', '+1234567890', 'ivan@example.com');
END;

select * from Customers;



CREATE OR REPLACE PROCEDURE InsertDriver (
    p_drv_id IN NUMBER,
    p_name_drv IN NVARCHAR2,
    p_surname_drv IN NVARCHAR2,
    p_addres_drv IN NVARCHAR2,
    p_phone_drv IN NVARCHAR2,
    p_driver_licence IN NVARCHAR2
) AS
BEGIN
    INSERT INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
    VALUES (p_drv_id , p_name_drv, p_surname_drv, p_addres_drv, p_phone_drv, p_driver_licence);
    COMMIT;
END InsertDriver;

BEGIN
    InsertDriver(2,'Иван', 'Петров', 'ул. Примерная, д. 456', '+9876543210', 'AB123456');
END;

select * from Drivers;


CREATE OR REPLACE PROCEDURE InsertVehicle (
    p_vech_id IN NUMBER,
    p_type IN NVARCHAR2,
    p_license_plate IN NVARCHAR2,
    p_model IN NVARCHAR2,
    p_status_id IN NUMBER,
    p_location IN NVARCHAR2,
    p_fuel IN NVARCHAR2,
    p_issue_year IN NVARCHAR2,
    p_color IN NVARCHAR2
) AS
BEGIN
    INSERT INTO Vehicles (Vehicle_id, type, License_Plate, model, status_id, location, fuel, issue_year, color)
    VALUES (p_vech_id, p_type, p_license_plate, p_model, p_status_id, p_location, p_fuel, p_issue_year, p_color);
    COMMIT;
END InsertVehicle;

BEGIN
    InsertVehicle(2,'Седан', 'AB123CD', 'Toyota Camry', 1, 'Гараж 123', 'Бензин', '2020', 'Серебристый');
END;

select * from Vehicles;

CREATE OR REPLACE PROCEDURE ShowOrders AS
BEGIN
    FOR order_rec IN (SELECT * FROM Orders) LOOP
        DBMS_OUTPUT.PUT_LINE('Order ID: ' || order_rec.Order_id);
        DBMS_OUTPUT.PUT_LINE('Driver ID: ' || order_rec.driver_id);
        DBMS_OUTPUT.PUT_LINE('Client ID: ' || order_rec.client_id);
        DBMS_OUTPUT.PUT_LINE('Review ID: ' || order_rec.id_review);
        DBMS_OUTPUT.PUT_LINE('Car ID: ' || order_rec.car_id);
        DBMS_OUTPUT.PUT_LINE('Order Date and Time: ' || TO_CHAR(order_rec.Order_DateTime, 'YYYY-MM-DD HH24:MI:SS'));
        DBMS_OUTPUT.PUT_LINE('Start Point: ' || order_rec.startpoint);
        DBMS_OUTPUT.PUT_LINE('End Point: ' || order_rec.endpoint);
        DBMS_OUTPUT.PUT_LINE('Price: ' || order_rec.price);
        DBMS_OUTPUT.PUT_LINE('Status ID: ' || order_rec.status_id);
        DBMS_OUTPUT.PUT_LINE('------------------');
    END LOOP;
END ShowOrders;

BEGIN
    ShowOrders;
END;


BEGIN
    FOR i IN 1..10000 LOOP
        INSERT INTO Customers (
            Customer_id,
            Name_cst,
            Surname_cst,
            Addres_cst,
            Phone_cst,
            Email_cst
        ) VALUES (
            i,
            'Customer' || i,
            'Surname' || i,
            'Address' || i,
            'Phone' || i,
            'customer' || i || '@example.com'
        );
    END LOOP;
    COMMIT;
END;

select * from Customers;

    
    CREATE INDEX IX_Customers_Email ON Customers(Email_cst);
    DROP INDEX IX_Customers_Email;
SELECT * FROM Customers WHERE Email_cst LIKE '%1673%';

/* lab 3 */



select * from Customers order by customer_id;

ALTER TABLE Customers
ADD (Parent_id NUMBER);
 
 UPDATE Customers 
 SET Parent_id = 1
 where Customer_id>1 and Customer_id<20;





CREATE OR REPLACE PROCEDURE DisplaySubordinates(
    NodeId NUMBER
)
IS
BEGIN
    FOR rec IN (
        SELECT
            Customer_id,
            Name_cst,
            Surname_cst,
            Addres_cst,
            Phone_cst,
            Email_cst
        FROM Customers
        START WITH Customer_id = NodeId
        CONNECT BY PRIOR Customer_id = Parent_id
    )
    LOOP
        DBMS_OUTPUT.PUT_LINE('Customer ID: ' || rec.Customer_id ||
                             ', Name: ' || rec.Name_cst ||
                             ', Surname: ' || rec.Surname_cst ||
                             ', Address: ' || rec.Addres_cst ||
                             ', Phone: ' || rec.Phone_cst ||
                             ', Email: ' || rec.Email_cst);
    END LOOP;
END DisplaySubordinates;
/


EXEC DisplaySubordinates(1);


CREATE OR REPLACE PROCEDURE AddSubordinate(
    ParentNodeId IN NUMBER,
    NewNodeName IN NVARCHAR2,
    NewNodeSurname IN NVARCHAR2,
    NewNodeAddress IN NVARCHAR2,
    NewNodePhone IN NVARCHAR2,
    NewNodeEmail IN NVARCHAR2
)
AS
    NewNodeId NUMBER;
BEGIN
    SELECT MAX(Customer_id) + 1 INTO NewNodeId FROM Customers;


    INSERT INTO Customers (Customer_id, Name_cst, Surname_cst, Addres_cst, Phone_cst, Email_cst, Parent_id)
    VALUES (NewNodeId, NewNodeName, NewNodeSurname, NewNodeAddress, NewNodePhone, NewNodeEmail, ParentNodeId);
END AddSubordinate;
/

EXEC AddSubordinate(2, 'Coolboy', 'New Surname', 'New Address', 'New Phone', 'new@email.com');

select * from Customers where Parent_id=4;


CREATE OR REPLACE PROCEDURE MoveSubtree(
    SourceNodeId IN NUMBER,
    DestinationNodeId IN NUMBER
)
IS
BEGIN

    UPDATE Customers
    SET Parent_id = DestinationNodeId
    WHERE Customer_id = SourceNodeId
    OR Customer_id IN (
        SELECT Customer_id
        FROM Customers
        WHERE CONNECT_BY_ISLEAF = 1
        START WITH Customer_id = SourceNodeId
        CONNECT BY PRIOR Customer_id = Parent_id
    );
END MoveSubtree;
/


EXEC MoveSubtree(3, 4);


EXEC DisplaySubordinates(1);



--lab4

-- По месяцам
SELECT
    EXTRACT(YEAR FROM Order_DateTime) AS Year,
    EXTRACT(MONTH FROM Order_DateTime) AS Month,
    COUNT(Order_id) AS TotalServices
FROM Orders
GROUP BY EXTRACT(YEAR FROM Order_DateTime), EXTRACT(MONTH FROM Order_DateTime);

-- По кварталам
SELECT
    EXTRACT(YEAR FROM Order_DateTime) AS Year,
    TO_CHAR(Order_DateTime, 'Q') AS Quarter,
    COUNT(Order_id) AS TotalServices
FROM Orders
GROUP BY EXTRACT(YEAR FROM Order_DateTime), TO_CHAR(Order_DateTime, 'Q');

-- По полугодиям
SELECT
    EXTRACT(YEAR FROM Order_DateTime) AS Year,
    CASE WHEN EXTRACT(MONTH FROM Order_DateTime) <= 6 THEN '1st Half' ELSE '2nd Half' END AS SemiAnnual,
    COUNT(Order_id) AS TotalServices
FROM Orders
GROUP BY EXTRACT(YEAR FROM Order_DateTime), CASE WHEN EXTRACT(MONTH FROM Order_DateTime) <= 6 THEN '1st Half' ELSE '2nd Half' END;

-- По годам
SELECT
    EXTRACT(YEAR FROM Order_DateTime) AS Year,
    COUNT(Order_id) AS TotalServices
FROM Orders
GROUP BY EXTRACT(YEAR FROM Order_DateTime);




-- Объем услуг
DECLARE
    start_date TIMESTAMP := TO_TIMESTAMP('2023-01-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS');
    end_date TIMESTAMP := TO_TIMESTAMP('2023-03-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS');
    total_services INT;

BEGIN
    SELECT COUNT(Order_id) INTO total_services
    FROM Orders
    WHERE Order_DateTime BETWEEN start_date AND end_date;

    DBMS_OUTPUT.PUT_LINE('Total Services: ' || total_services);
END;
/

-- Сравнение с общим объемом услуг (в %)
DECLARE
    start_date TIMESTAMP := TO_TIMESTAMP('2023-01-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS');
    end_date TIMESTAMP := TO_TIMESTAMP('2023-03-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS');
    total_services INT;

BEGIN
    SELECT COUNT(Order_id) INTO total_services
    FROM Orders
    WHERE Order_DateTime BETWEEN start_date AND end_date;

    DBMS_OUTPUT.PUT_LINE('Total Services: ' || total_services);

    FOR c IN (
        SELECT
            COUNT(Order_id) AS TotalServices,
            (COUNT(Order_id) * 100.0 / total_services) AS PercentageOfTotal
        FROM Orders
        WHERE Order_DateTime BETWEEN start_date AND end_date
    ) LOOP
        DBMS_OUTPUT.PUT_LINE('Total Services: ' || c.TotalServices || ', Percentage of Total: ' || c.PercentageOfTotal);
    END LOOP;
END;
/

-- Сравнение с максимальным объемом услуг (в %)
DECLARE
    start_date TIMESTAMP := TO_TIMESTAMP('2023-01-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS');
    end_date TIMESTAMP := TO_TIMESTAMP('2023-03-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS');
    total_services INT;
    max_services INT;

BEGIN
    SELECT COUNT(Order_id) INTO total_services
    FROM Orders
    WHERE Order_DateTime BETWEEN start_date AND end_date;

    SELECT MAX(ServiceCount) INTO max_services
    FROM (
        SELECT COUNT(Order_id) AS ServiceCount
        FROM Orders
        GROUP BY TO_CHAR(Order_DateTime, 'YYYY-MM')
    );

    DBMS_OUTPUT.PUT_LINE('Total Services: ' || total_services || ', Max Services: ' || max_services);

    FOR c IN (
        SELECT
            COUNT(Order_id) AS TotalServices,
            (COUNT(Order_id) * 100.0 / total_services) AS PercentageOfTotal,
            (COUNT(Order_id) * 100.0 / max_services) AS PercentageOfMax
        FROM Orders
        WHERE Order_DateTime BETWEEN start_date AND end_date
    ) LOOP
        DBMS_OUTPUT.PUT_LINE('Total Services: ' || c.TotalServices || ', Percentage of Total: ' || c.PercentageOfTotal || ', Percentage of Max: ' || c.PercentageOfMax);
    END LOOP;
END;




SELECT *
FROM (
  SELECT
    o.Order_id,
    o.Order_DateTime,
    c.Name_cst,
    c.Surname_cst,
    ROW_NUMBER() OVER (ORDER BY o.Order_DateTime) AS row_num
  FROM Orders o
  INNER JOIN Customers c ON o.client_id = c.Customer_id
) sub
WHERE sub.row_num BETWEEN 1 AND 20;


DELETE FROM Orders o1
WHERE EXISTS (
    SELECT 1
    FROM Orders o2
    WHERE o1.driver_id = o2.driver_id
        AND o1.client_id = o2.client_id
        AND o1.Order_DateTime = o2.Order_DateTime
        AND o1.Order_id > o2.Order_id
);

-- Выборка оставшихся данных (недубликатов)
SELECT *
FROM Orders;




SELECT Order_id, driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id
FROM (
    SELECT Order_id, driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id,
    RANK() OVER (PARTITION BY client_id ORDER BY Order_DateTime DESC) rank
    FROM Orders
)
WHERE rank <= 6;




WITH RankedRoutes AS (
    SELECT
        v.type AS VehicleType,
        o.startpoint,
        o.endpoint,
        COUNT(o.Order_id) AS RoutePopularity,
        RANK() OVER (PARTITION BY v.type ORDER BY COUNT(o.Order_id) DESC) AS RouteRank
    FROM
        Orders o
        JOIN Vehicles v ON o.car_id = v.Vehicle_id
    GROUP BY
        v.type, o.startpoint, o.endpoint
)

SELECT
    VehicleType,
    startpoint,
    endpoint,
    RoutePopularity
FROM RankedRoutes
WHERE RouteRank = 1;


INSERT ALL 

INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES 
    (7, 'William', 'Miller', '202 Elm St', '555-2222', 'DL23456')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (8, 'Emma', 'Taylor', '303 Cedar St', '555-3333', 'DL34567')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (9, 'Daniel', 'Moore', '404 Birch St', '555-4444', 'DL89012')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (10, 'Sophia', 'Jones', '505 Pine St', '555-5555', 'DL56789')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (11, 'Jackson', 'Martin', '606 Oak St', '555-6666', 'DL45678')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (12, 'Ava', 'White', '707 Elm St', '555-7777', 'DL12345')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (13, 'Liam', 'Evans', '808 Cedar St', '555-8888', 'DL67890')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (14, 'Oliver', 'Clark', '909 Birch St', '555-9999', 'DL23456')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (15, 'Isabella', 'Perez', '101 Maple Ave', '555-1111', 'DL78901')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (16, 'Lucas', 'Baker', '121 Pine St', '555-2222', 'DL34567')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (17, 'Mia', 'Anderson', '232 Oak St', '555-3333', 'DL89012')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (18, 'Logan', 'Cooper', '343 Cedar St', '555-4444', 'DL56789')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (19, 'Amelia', 'Hill', '454 Elm St', '555-5555', 'DL45678')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (20, 'Ethan', 'Ward', '565 Birch St', '555-6666', 'DL12345')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (21, 'Aria', 'Fisher', '676 Pine St', '555-7777', 'DL67890')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (22, 'Carter', 'Woods', '787 Oak St', '555-8888', 'DL23456')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (23, 'Abigail', 'Bishop', '898 Cedar St', '555-9999', 'DL78901')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (24, 'Noah', 'Larson', '909 Birch St', '555-1111', 'DL34567')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (25, 'Sophie', 'Dixon', '110 Main St', '555-2222', 'DL89012')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (26, 'Henry', 'Mills', '121 Pine St', '555-3333', 'DL56789')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (27, 'Lily', 'Warner', '232 Oak St', '555-4444', 'DL45678')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (28, 'Elijah', 'Fields', '343 Cedar St', '555-5555', 'DL12345')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (29, 'Avery', 'Murray', '454 Elm St', '555-6666', 'DL67890')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (30, 'Grace', 'Gardner', '565 Birch St', '555-7777', 'DL23456')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (31, 'Owen', 'Vaughn', '676 Pine St', '555-8888', 'DL78901')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (32, 'Scarlett', 'Hudson', '787 Oak St', '555-9999', 'DL34567')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (33, 'Leo', 'Cole', '898 Cedar St', '555-1111', 'DL89012')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (34, 'Hannah', 'Hartman', '909 Birch St', '555-2222', 'DL56789')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (35, 'Isaac', 'Ross', '110 Main St', '555-3333', 'DL45678')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (36, 'Ella', 'Barker', '121 Pine St', '555-4444', 'DL12345')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (37, 'Caleb', 'Fleming', '232 Oak St', '555-5555', 'DL67890')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (38, 'Nova', 'Fisher', '343 Cedar St', '555-6666', 'DL23456')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (39, 'Gabriel', 'Wallace', '454 Elm St', '555-7777', 'DL78901')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (40, 'Aurora', 'Perry', '565 Birch St', '555-8888', 'DL34567')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (41, 'Ezra', 'Dunn', '676 Pine St', '555-9999', 'DL89012')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (42, 'Stella', 'Spencer', '787 Oak St', '555-1111', 'DL56789')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (43, 'Max', 'Hudson', '898 Cedar St', '555-2222', 'DL45678')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (44, 'Aria', 'Cole', '909 Birch St', '555-3333', 'DL12345')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (45, 'Silas', 'Hartman', '110 Main St', '555-4444', 'DL67890')
INTO Drivers (drv_id, Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    (46, 'Luna', 'Ross', '121 Pine St', '555-5555', 'DL23456')
SELECT * FROM dual;

  Order_id NUMBER(10) PRIMARY KEY,
    driver_id NUMBER(10),
    client_id NUMBER(10),
    id_review NUMBER(10),
    car_id NUMBER(10),
    Order_DateTime DATE, -- Здесь используем DATE вместо TIMESTAMP
    startpoint NVARCHAR2(50),
    endpoint NVARCHAR2(50),
    price NUMBER(10),
    status_id NUMBER(10),

select * from Vehicles;
INSERT INTO Orders (Order_id, driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (2, 2, 4, 1, 2, TO_TIMESTAMP('2023-03-15T14:30:00', 'YYYY-MM-DD"T"HH24:MI:SS'), '789 Pine St', '123 Main St', 35, 1)
       SELECT * FROM dual;
 INSERT   INTO Orders (Order_id, driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (3, 4, 10, 1, 4, TO_TIMESTAMP('2023-04-20T08:00:00','YYYY-MM-DD"T"HH24:MI:SS'), '101 Maple Ave', '202 Elm St', 25, 1)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (4, 7, 7, 1, 2, '2023-07-05T08:45:00', '789 Pine St', '123 Main St', 40, 2)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (5, 8, 8, 1, 8, '2023-08-10T14:30:00', '123 Main St', '456 Oak St', 35, 1)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (6, 9, 9, 1, 9, '2023-09-15T18:45:00', '456 Oak St', '789 Pine St', 25, 2)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (7, 10, 10, 1, 2, '2023-10-20T08:00:00', '789 Pine St', '123 Main St', 45, 2)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (8, 11, 11, 1, 8, '2023-11-25T16:30:00', '101 Maple Ave', '202 Elm St', 30, 1)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (9, 12, 12, 1, 2, '2023-12-30T12:00:00', '202 Elm St', '567 Pine St', 40, 2)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (10, 13, 13, 1, 9, '2024-01-05T08:45:00', '567 Pine St', '789 Pine St', 35, 1)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (11, 14, 14, 1, 9, '2024-02-10T14:30:00', '789 Pine St', '123 Main St', 25, 2)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (12, 15, 15, 1, 8, '2024-03-15T18:45:00', '123 Main St', '456 Oak St', 45, 2)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (13, 16, 16, 1, 8, '2024-04-20T08:00:00', '456 Oak St', '789 Pine St', 30, 1)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (14, 17, 17, 1, 8, '2024-05-25T16:30:00', '789 Pine St', '123 Main St', 40, 2)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (15, 18, 18, 1, 8, '2024-06-30T12:00:00', '101 Maple Ave', '202 Elm St', 35, 1)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (16, 19, 19, 1, 8, '2024-07-05T08:45:00', '202 Elm St', '567 Pine St', 25, 2)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (17, 20, 20, 1, 2, '2024-08-10T14:30:00', '567 Pine St', '789 Pine St', 45, 2)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (18, 21, 21, 1, 2, '2024-09-15T18:45:00', '789 Pine St', '123 Main St', 30, 1)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (19, 22, 22, 1, 2, '2024-10-20T08:00:00', '123 Main St', '456 Oak St', 40, 2)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (20, 23, 23, 1, 2, '2024-11-25T16:30:00', '456 Oak St', '789 Pine St', 35, 1)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (21, 24, 24, 1, 2, '2024-12-30T12:00:00', '789 Pine St', '123 Main St', 25, 2)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (22, 25, 25, 1, 2, '2025-01-05T08:45:00', '101 Maple Ave', '202 Elm St', 45, 2)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (23, 26, 26, 1, 2, '2025-02-10T14:30:00', '202 Elm St', '567 Pine St', 30, 1)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (24, 27, 27, 1, 2, '2025-03-15T18:45:00', '567 Pine St', '789 Pine St', 40, 2)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (25, 28, 28, 1, 2, '2025-04-20T08:00:00', '789 Pine St', '123 Main St', 35, 1)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (26, 29, 29, 1, 2, '2025-05-25T16:30:00', '123 Main St', '456 Oak St', 25, 2)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (27, 30, 30, 1, 9, '2025-06-30T12:00:00', '456 Oak St', '789 Pine St', 45, 2)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (28, 31, 31, 1, 9, '2025-07-05T08:45:00', '789 Pine St', '123 Main St', 30, 1)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (29, 32, 32, 1, 9, '2025-08-10T14:30:00', '101 Maple Ave', '202 Elm St', 40, 2)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (30, 33, 33, 1, 9, '2025-09-15T18:45:00', '202 Elm St', '567 Pine St', 35, 1)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (31, 34, 34, 1, 9, '2025-10-20T08:00:00', '567 Pine St', '789 Pine St', 25, 2)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (32, 35, 35, 1, 9, '2025-11-25T16:30:00', '789 Pine St', '123 Main St', 45, 2)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (33, 36, 36, 1, 9, '2025-12-30T12:00:00', '123 Main St', '456 Oak St', 30, 1)
    INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
    VALUES (34, 37, 37, 1, 9, '2026-01-05T08:45:00', '456 Oak St', '789 Pine St', 40, 2)
    SELECT * FROM dual;