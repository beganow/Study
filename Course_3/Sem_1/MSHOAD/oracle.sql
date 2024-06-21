--alter session set "_ORACLE_SCRIPT"=true

CREATE USER TransportUser IDENTIFIED BY 1234;
GRANT CONNECT, RESOURCE, CREATE SESSION, CREATE TABLE TO TransportUser;

-- Использование схемы пользователя
ALTER SESSION SET CURRENT_SCHEMA = SYS;
select * from Drivers;
-- Создание таблицы Customers для клиентов
CREATE TABLE Customers (
    Customer_id NUMBER(10) PRIMARY KEY,
    Name_cst NVARCHAR2(50),
    Surname_cst NVARCHAR2(50),
    Addres_cst NVARCHAR2(50),
    Phone_cst NVARCHAR2(50),
    Email_cst NVARCHAR2(50)
);

DROP TABLE Customers;
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
select * from Orders;

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
    
    
    
    CREATE INDEX IX_Customers_Email ON Customers(Email);
    
    
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




--                                 lab4


--z1
SELECT
    EXTRACT(MONTH FROM Order_DateTime) AS Month,
    TO_NUMBER(TO_CHAR(Order_DateTime, 'Q')) AS Quarter,
    EXTRACT(YEAR FROM Order_DateTime) AS Year,
    SUM(price) OVER (PARTITION BY EXTRACT(YEAR FROM Order_DateTime), EXTRACT(MONTH FROM Order_DateTime) ORDER BY EXTRACT(YEAR FROM Order_DateTime), EXTRACT(MONTH FROM Order_DateTime)) AS TotalMonthly,
    SUM(price) OVER (PARTITION BY EXTRACT(YEAR FROM Order_DateTime), TO_NUMBER(TO_CHAR(Order_DateTime, 'Q')) ORDER BY EXTRACT(YEAR FROM Order_DateTime), TO_NUMBER(TO_CHAR(Order_DateTime, 'Q'))) AS TotalQuarterly,
    SUM(price) OVER (PARTITION BY EXTRACT(YEAR FROM Order_DateTime) ORDER BY EXTRACT(YEAR FROM Order_DateTime)) AS TotalYearly
FROM
    Orders
ORDER BY
    Year, Quarter, Month;
    
    
    
--z2
WITH ServiceTotals AS (
    SELECT
        EXTRACT(YEAR FROM Order_DateTime) AS Year,
        EXTRACT(MONTH FROM Order_DateTime) AS Month,
        SUM(price) AS Total
    FROM
        Orders
    GROUP BY
        EXTRACT(YEAR FROM Order_DateTime),
        EXTRACT(MONTH FROM Order_DateTime)
)

SELECT
    ST.Year,
    ST.Month,
    ST.Total AS ServiceVolume,
    CASE WHEN SUM(ST.Total) OVER (PARTITION BY ST.Year) = 0 THEN 0
         ELSE ST.Total * 100.0 / SUM(ST.Total) OVER (PARTITION BY ST.Year) END AS PercentageOfTotal,
    CASE WHEN MAX(ST.Total) OVER () = 0 THEN 0
         ELSE ST.Total * 100.0 / MAX(ST.Total) OVER () END AS PercentageOfMaxTotal
FROM
    ServiceTotals ST
ORDER BY
    ST.Year, ST.Month;
    
--z3
SELECT *
FROM (
    SELECT
        Customer_id,
        Name_cst,
        Surname_cst,
        Addres_cst,
        Phone_cst,
        Email_cst,
        ROW_NUMBER() OVER (ORDER BY Customer_id) AS row_num
    FROM Customers
    -- Дополнительные условия или фильтры могут быть добавлены сюда
)
WHERE row_num BETWEEN 1 AND 20;

--z4

INSERT INTO Status(status_id, Status_name) VALUES (3, 'Available');
DELETE FROM Status where status_id=3;
WHERE status_id IN (
    SELECT status_id
    FROM (
        SELECT status_id,
            Status_name,
            ROW_NUMBER() OVER (PARTITION BY Status_name ORDER BY status_id) AS RowNum
        FROM Status
    )
    WHERE RowNum > 1
);
SELECT * FROM Status;


--z5
SELECT client_id, Order_id, driver_id, Order_DateTime, startpoint, endpoint, price
FROM (
    SELECT client_id, Order_id, driver_id, Order_DateTime, startpoint, endpoint, price,
           ROW_NUMBER() OVER (PARTITION BY client_id ORDER BY Order_DateTime DESC) AS rn
    FROM Orders
) sub
WHERE rn <= 6;
--z6
SELECT
    VehicleType,
    startpoint,
    endpoint
FROM (
    SELECT
        v.type AS VehicleType,
        o.startpoint,
        o.endpoint,
        ROW_NUMBER() OVER (PARTITION BY v.type ORDER BY COUNT(*) DESC) AS PopularityRank
    FROM
        Orders o
        INNER JOIN Vehicles v ON o.car_id = v.Vehicle_id
    GROUP BY
        v.type, o.startpoint, o.endpoint
) RankedRoutes
WHERE
    PopularityRank = 1
ORDER BY
    VehicleType;
--                                  lab7
SELECT *
FROM (
    SELECT 
        o.client_id,
        EXTRACT(MONTH FROM o.Order_DateTime) as month,
        SUM(o.price) as total_price
    FROM 
        Orders o
    WHERE 
        EXTRACT(YEAR FROM o.Order_DateTime) = EXTRACT(YEAR FROM CURRENT_DATE) - 1
    GROUP BY 
        o.client_id,
        EXTRACT(MONTH FROM o.Order_DateTime)
)
MODEL
    PARTITION BY (client_id)
    DIMENSION BY (month)
    MEASURES (total_price, 0 as next_year_price)
    RULES (
        next_year_price[ANY] = total_price[CV()] * 1.1
    );

    INSERT INTO Customers VALUES (1, 'John', 'Doe', '123 Main St', '555-1234', 'john@example.com');
INSERT INTO Customers VALUES (2, 'Jane', 'Smith', '456 Oak St', '555-5678', 'jane@example.com');

-- Insert sample data into Drivers table
INSERT INTO Drivers VALUES (1, 'Mike', 'Johnson', '789 Elm St', '555-9876', 'DL12345');
INSERT INTO Drivers VALUES (2, 'Emily', 'Williams', '101 Pine St', '555-4321', 'DL67890');

INSERT INTO Status VALUES (1, 'Available');
INSERT INTO Status VALUES (2, 'In Use');
-- Insert sample data into Vehicles table
INSERT INTO Vehicles VALUES (1, 'Sedan', 'ABC123', 'Toyota Camry', 1, 'Garage A', 'Gasoline', '2022', 'Blue');
INSERT INTO Vehicles VALUES (2, 'SUV', 'XYZ789', 'Ford Explorer', 2, 'Garage B', 'Diesel', '2021', 'Black');

-- Insert sample data into Orders table
INSERT INTO Orders VALUES (1, 1, 1, NULL, 1, TO_DATE('2022-01-10', 'YYYY-MM-DD'), 'A', 'B', 100, 1);
INSERT INTO Orders VALUES (2, 2, 2, NULL, 2, TO_DATE('2022-02-15', 'YYYY-MM-DD'), 'C', 'D', 150, 1);

-- Insert sample data into Reviews table
INSERT INTO Reviews VALUES (1, 4, 'Great service!', TO_DATE('2022-01-12', 'YYYY-MM-DD'));
INSERT INTO Reviews VALUES (2, 5, 'Excellent driver!', TO_DATE('2022-02-20', 'YYYY-MM-DD'));

INSERT INTO Methods VALUES (1, 'Credit Card');
INSERT INTO Methods VALUES (2, 'PayPal');
-- Insert sample data into Payments table
INSERT INTO Payments VALUES (1, 1, 100, TO_DATE('2022-01-11', 'YYYY-MM-DD'), 1);
INSERT INTO Payments VALUES (2, 2, 150, TO_DATE('2022-02-18', 'YYYY-MM-DD'), 1);
       
       INSERT INTO Customers VALUES (3, 'Alice', 'Johnson', '789 Maple St', '555-1111', 'alice@example.com');
INSERT INTO Customers VALUES (4, 'Bob', 'Smith', '555 Birch St', '555-2222', 'bob@example.com');
INSERT INTO Customers VALUES (5, 'Charlie', 'Williams', '888 Pine St', '555-3333', 'charlie@example.com');
INSERT INTO Customers VALUES (6, 'David', 'Jones', '999 Cedar St', '555-4444', 'david@example.com');
INSERT INTO Customers VALUES (7, 'Eva', 'Brown', '111 Walnut St', '555-5555', 'eva@example.com');

-- Insert additional data into Drivers table
INSERT INTO Drivers VALUES (3, 'Olivia', 'Davis', '222 Oak St', '555-6666', 'DL11111');
INSERT INTO Drivers VALUES (4, 'Frank', 'Martin', '333 Elm St', '555-7777', 'DL22222');
INSERT INTO Drivers VALUES (5, 'Grace', 'Taylor', '444 Pine St', '555-8888', 'DL33333');
INSERT INTO Drivers VALUES (6, 'Harry', 'Moore', '555 Maple St', '555-9999', 'DL44444');
INSERT INTO Drivers VALUES (7, 'Isaac', 'King', '666 Cedar St', '555-0000', 'DL55555');

-- Insert additional data into Vehicles table
INSERT INTO Vehicles VALUES (3, 'Sedan', 'DEF456', 'Honda Accord', 1, 'Garage C', 'Gasoline', '2023', 'Silver');
INSERT INTO Vehicles VALUES (4, 'SUV', 'GHI789', 'Chevrolet Traverse', 1, 'Garage D', 'Petrol', '2022', 'Red');
INSERT INTO Vehicles VALUES (5, 'Truck', 'JKL012', 'Ford F-150', 1, 'Garage E', 'Diesel', '2022', 'White');
INSERT INTO Vehicles VALUES (6, 'Motorcycle', 'MNO345', 'Harley-Davidson', 1, 'Garage F', 'Gasoline', '2021', 'Black');
INSERT INTO Vehicles VALUES (7, 'Van', 'PQR678', 'Toyota Sienna', 1, 'Garage G', 'Hybrid', '2023', 'Blue');

-- Insert additional data into Orders table
INSERT INTO Orders VALUES (3, 3, 3, NULL, 3, TO_DATE('2022-03-20', 'YYYY-MM-DD'), 'X', 'Y', 120, 1);
INSERT INTO Orders VALUES (4, 4, 4, NULL, 4, TO_DATE('2022-04-25', 'YYYY-MM-DD'), 'M', 'N', 180, 1);
INSERT INTO Orders VALUES (5, 5, 5, NULL, 5, TO_DATE('2022-05-15', 'YYYY-MM-DD'), 'P', 'Q', 200, 1);
INSERT INTO Orders VALUES (6, 6, 6, NULL, 6, TO_DATE('2022-06-10', 'YYYY-MM-DD'), 'U', 'V', 90, 1);
INSERT INTO Orders VALUES (7, 7, 7, NULL, 7, TO_DATE('2022-07-05', 'YYYY-MM-DD'), 'Z', 'A', 150, 1);

-- Insert additional data into Reviews table
INSERT INTO Reviews VALUES (3, 4, 'Good experience!', TO_DATE('2022-03-22', 'YYYY-MM-DD'));
INSERT INTO Reviews VALUES (4, 3, 'Nice driver!', TO_DATE('2022-04-28', 'YYYY-MM-DD'));
INSERT INTO Reviews VALUES (5, 5, 'Awesome service!', TO_DATE('2022-05-18', 'YYYY-MM-DD'));
INSERT INTO Reviews VALUES (6, 2, 'Polite driver!', TO_DATE('2022-06-12', 'YYYY-MM-DD'));
INSERT INTO Reviews VALUES (7, 1, 'Excellent ride!', TO_DATE('2022-07-07', 'YYYY-MM-DD'));

-- Insert additional data into Payments table
INSERT INTO Payments VALUES (3, 3, 120, TO_DATE('2022-03-21', 'YYYY-MM-DD'), 2);
INSERT INTO Payments VALUES (4, 4, 180, TO_DATE('2022-04-26', 'YYYY-MM-DD'), 2);
INSERT INTO Payments VALUES (5, 5, 200, TO_DATE('2022-05-16', 'YYYY-MM-DD'), 2);
INSERT INTO Payments VALUES (6, 6, 90, TO_DATE('2022-06-11', 'YYYY-MM-DD'), 2);
INSERT INTO Payments VALUES (7, 7, 150, TO_DATE('2022-07-06', 'YYYY-MM-DD'), 2);
       
       SELECT * FROM Payments;
SELECT * FROM Orders;
UPDATE SET   FROM Orders where order_id>7;




SELECT *
FROM Orders
MATCH_RECOGNIZE (
  ORDER BY Order_DateTime
  MEASURES
    FIRST(A.startpoint) AS startpoint,
    LAST(A.endpoint) AS endpoint,
    A.price AS oneprice,
    B.price AS secondprice,
    C.price AS threeprice
  ONE ROW PER MATCH
  AFTER MATCH SKIP TO NEXT ROW
  PATTERN (A B C)
  DEFINE
    A AS A.price > PREV(A.price),
    B AS B.price < PREV(B.price),
    C AS C.price > PREV(C.price)
) MR;



--                             lab8

CREATE OR REPLACE TYPE CustomerObj AS OBJECT (
    Customer_id NUMBER,
    Name_cst NVARCHAR2(50),
    Surname_cst NVARCHAR2(50),
    Addres_cst NVARCHAR2(50),
    Phone_cst NVARCHAR2(50),
    Email_cst NVARCHAR2(50),
    -- a. Дополнительный конструктор
    CONSTRUCTOR FUNCTION CustomerObj (p_Customer_id NUMBER, p_Name_cst NVARCHAR2, p_Surname_cst NVARCHAR2) RETURN SELF AS RESULT,
    -- c. Метод экземпляра функцию
    MEMBER FUNCTION get_full_name RETURN NVARCHAR2,
    -- d. Метод экземпляра процедуру
    MEMBER PROCEDURE set_full_name (p_Name_cst NVARCHAR2, p_Surname_cst NVARCHAR2)
);


CREATE OR REPLACE TYPE BODY CustomerObj AS
    -- a. Дополнительный конструктор
    CONSTRUCTOR FUNCTION CustomerObj (p_Customer_id NUMBER, p_Name_cst NVARCHAR2, p_Surname_cst NVARCHAR2) RETURN SELF AS RESULT IS
    BEGIN
        SELF.Customer_id := p_Customer_id;
        SELF.Name_cst := p_Name_cst;
        SELF.Surname_cst := p_Surname_cst;
        RETURN;
    END;
    -- c. Метод экземпляра функцию
    MEMBER FUNCTION get_full_name RETURN NVARCHAR2 IS
    BEGIN
        RETURN SELF.Name_cst || ' ' || SELF.Surname_cst;
    END;
    -- d. Метод экземпляра процедуру
    MEMBER PROCEDURE set_full_name (p_Name_cst NVARCHAR2, p_Surname_cst NVARCHAR2) IS
    BEGIN
        SELF.Name_cst := p_Name_cst;
        SELF.Surname_cst := p_Surname_cst;
    END;
END;

CREATE TABLE CustomersObj OF CustomerObj;

INSERT INTO CustomersObj SELECT * FROM Customers;

SELECT c.get_full_name() FROM CustomersObj c;

CREATE INDEX idx_customer_name ON CustomersObj (Name_cst);



CREATE OR REPLACE TYPE OrderObj AS OBJECT (
    Order_id NUMBER,
    driver_id NUMBER,
    client_id NUMBER,
    id_review NUMBER,
    car_id NUMBER,
    Order_DateTime DATE,
    startpoint NVARCHAR2(50),
    endpoint NVARCHAR2(50),
    price NUMBER,
    status_id NUMBER,
    -- a. Дополнительный конструктор
    CONSTRUCTOR FUNCTION OrderObj (p_Order_id NUMBER, p_driver_id NUMBER, p_client_id NUMBER) RETURN SELF AS RESULT,
    -- b. Метод сравнения типа MAP
    MAP MEMBER FUNCTION get_id RETURN NUMBER
);

CREATE OR REPLACE TYPE BODY OrderObj AS
    -- a. Дополнительный конструктор
    CONSTRUCTOR FUNCTION OrderObj (p_Order_id NUMBER, p_driver_id NUMBER, p_client_id NUMBER) RETURN SELF AS RESULT IS
    BEGIN
        SELF.Order_id := p_Order_id;
        SELF.driver_id := p_driver_id;
        SELF.client_id := p_client_id;
        RETURN;
    END;
    -- b. Метод сравнения типа MAP
    MAP MEMBER FUNCTION get_id RETURN NUMBER IS
    BEGIN
        RETURN SELF.Order_id;
    END;
END;

CREATE TABLE OrdersObj OF OrderObj;

INSERT INTO OrdersObj SELECT * FROM Orders;

SELECT o.get_id() FROM OrdersObj o;

CREATE INDEX idx_order_id ON OrdersObj (Order_id);


CREATE OR REPLACE VIEW OrdersView AS
SELECT o.Order_id, o.driver_id, o.client_id, o.get_id() AS map_id
FROM OrdersObj o;

SELECT * FROM OrdersView;

SELECT * FROM OrdersObj o WHERE o.driver_id = 3;
SELECT * FROM OrdersObj o WHERE o.get_id() = 2;

DROP TYPE BODY Customer_obj;