CREATE DATABASE TransportServiceDB;
GO


USE TransportServiceDB;
GO
select * from Orders;
select * from Drivers;
select * from Status;
delete from Vehicles where Vehicle_id=3;
delete from Orders where driver_id=3;
CREATE TABLE Customers (
    Customer_id INT PRIMARY KEY IDENTITY(1,1),
    Name_cst NVARCHAR(50),
    Surname_cst NVARCHAR(50),
    Addres_cst NVARCHAR(50),
    Phone_cst NVARCHAR(50),
    Email_cst NVARCHAR(50)
);
GO


CREATE TABLE Drivers (
    drv_id INT PRIMARY KEY IDENTITY(1,1),
    Name_drv NVARCHAR(50),
    Surname_drv NVARCHAR(50),
    Addres_drv NVARCHAR(50),
    Phone_drv NVARCHAR(50),
    driver_licence NVARCHAR(50)
);
GO

CREATE TABLE Reviews (
    Review_ID INT PRIMARY KEY IDENTITY(1,1),
    grade INT,
    Comment NVARCHAR(50),
    datetime_review DATETIME,
);
GO

CREATE TABLE Status (
    status_id INT PRIMARY KEY IDENTITY(1,1),
    Status_name NVARCHAR(50)
);
GO

CREATE TABLE Vehicles (
    Vehicle_id INT PRIMARY KEY IDENTITY(1,1),
    type NVARCHAR(50),
    License_Plate NVARCHAR(10),
	model NVARCHAR(50),
	status_id INT,
	location NVARCHAR(50),
	fuel NVARCHAR(50),
	issue_year NVARCHAR(4),
	color NVARCHAR(50),
	FOREIGN KEY (status_id) REFERENCES Status(status_id)
);
GO
DELETE Orders;

CREATE TABLE Methods (
    id INT PRIMARY KEY IDENTITY(1,1),
    method_name NVARCHAR(50)
);
GO

CREATE TABLE Orders (
    Order_id INT PRIMARY KEY IDENTITY(1,1),
    driver_id INT,
    client_id INT,
    id_review INT,
	car_id INT,
    Order_DateTime DATETIME,
    startpoint NVARCHAR(50),
    endpoint NVARCHAR(50),
    price INT,
    status_id INT,
    FOREIGN KEY (client_id) REFERENCES Customers(Customer_id),
    FOREIGN KEY (driver_id) REFERENCES Drivers(drv_id),
    FOREIGN KEY (car_id) REFERENCES Vehicles(Vehicle_id),
	FOREIGN KEY (id_review) REFERENCES Reviews(Review_ID),
	FOREIGN KEY (status_id) REFERENCES Status(status_id)
);
GO

CREATE TABLE Payments (
    payment_id INT PRIMARY KEY IDENTITY(1,1),
    id_order INT,
    Amount INT,
    datetimepay DATETIME,
    method_id INT,
    FOREIGN KEY (id_order) REFERENCES Orders(Order_id),
	FOREIGN KEY (method_id) REFERENCES Methods(id)
);
GO

USE TransportServiceDB;
GO

CREATE OR ALTER VIEW CustomerOrderStatus AS
SELECT
    o.Order_id,
    c.Name_cst + ' ' + c.Surname_cst AS Customer_Name,
    v.License_Plate AS Vehicle_License_Plate,
    o.Order_DateTime AS Order_Date,
    s.Status_name AS Order_Status
FROM
    Orders o
    JOIN Customers c ON o.client_id = c.Customer_id
    JOIN Vehicles v ON o.car_id = v.Vehicle_id
    JOIN Status s ON o.status_id = s.status_id;


SELECT * FROM CustomerOrderStatus;



USE TransportServiceDB;
GO
CREATE OR ALTER VIEW VehicleOrderDriver AS
SELECT
    o.Order_id,
    d.Name_drv + ' ' + d.Surname_drv AS Driver_Name,
    v.License_Plate AS Vehicle_License_Plate,
    o.Order_DateTime AS Order_Date
FROM
    Orders o
    JOIN Drivers d ON o.driver_id = d.drv_id
    JOIN Vehicles v ON o.car_id = v.Vehicle_id;

SELECT * FROM VehicleOrderDriver;

USE TransportServiceDB;
GO
DROP INDEX IX_Customers_Email ON Customers;
USE TransportServiceDB;
-- Create Index on Customers Email
CREATE INDEX IX_Customers_Email ON Customers(Email_cst);
USE TransportServiceDB;
GO
-- Create Index on Drivers Driver_license
CREATE INDEX IX_Drivers_Driver_license ON Drivers(driver_licence);
GO
-- Create Index on Vehicles Model
CREATE INDEX IX_Vehicles_Model ON Vehicles(model);

go
CREATE TRIGGER PreventDuplicateVehicleAssignment
ON Orders
AFTER INSERT
AS
BEGIN
    DECLARE @DriverID INT;
    DECLARE @VehicleID INT;
    
    -- Получаем информацию о вновь созданном заказе
    SELECT @DriverID = driver_id, @VehicleID = car_id
    FROM inserted;

    -- Проверяем, был ли автомобиль уже назначен другому заказу
    IF EXISTS (
        SELECT 1
        FROM Orders
        WHERE car_id = @VehicleID
            AND Order_id != (SELECT MAX(Order_id) FROM Orders WHERE car_id = @VehicleID)
    )
    BEGIN
        THROW 50000, 'Этот автомобиль уже назначен другому заказу. Выберите другой автомобиль.', 1;
        ROLLBACK TRANSACTION;
    END
END;


INSERT INTO Customers (
    Name_cst,
    Surname_cst,
    Addres_cst,
    Phone_cst,
    Email_cst)
VALUES ('Pavel', 'Obodov', 'city Minsk, ul.Sverdlova', '+375445436789', 'email455@gmail.com');

select * from Customers;
USE TransportServiceDB;
go
select * from Status;
go
INSERT INTO Vehicles (type, License_Plate, model, status_id, location, fuel, issue_year, color)
VALUES
    ('Sedan', 'ABC123', 'Toyota Camry', 1, 'Parking Lot A', 'Gasoline', '2022', 'Blue'),
    ('SUV', 'XYZ789', 'Ford Explorer', 2, 'Garage B', 'Diesel', '2021', 'Black'),
    ('Compact', 'LMN456', 'Honda Civic', 1, 'Parking Lot C', 'Hybrid', '2023', 'Silver');

-- Добавление данных в таблицу Customers
INSERT INTO Customers (Name_cst, Surname_cst, Addres_cst, Phone_cst, Email_cst)
VALUES ('John', 'Doe', '123 Main Street', '555-123-4567', 'john@example.com');
go
-- Добавление данных в таблицу Drivers
INSERT INTO Drivers (Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES ('Jane', 'Smith', '456 Elm Street', '555-987-6543', 'DL123456');
go
-- Добавление данных в таблицу Vehicles
INSERT INTO Vehicles (type, License_Plate, model, status_id, location, fuel, issue_year, color)
VALUES ('Sedan', 'ABC123', 'Toyota Camry', 1, 'Parking Lot A', 'Gasoline', '2020', 'Blue');
go
-- Добавление данных в таблицу Reviews
INSERT INTO Reviews (grade, Comment, datetime_review)
VALUES (5, 'Great service!', GETDATE());
go
-- Добавление данных в таблицу Status
INSERT INTO Status (Status_name)
VALUES ('Unavailable');

-- Добавление данных в таблицу Methods
INSERT INTO Methods (method_name)
VALUES ('Credit Card');
select * from Orders;
go

INSERT INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
VALUES
    (4, 4, 3, 7, '2023-01-05T00:00:00', '123 Main St', '456 Oak St', 30, 1),
    (2, 5, 1, 2, '2023-02-10T00:00:00', '456 Oak St', '789 Pine St', 40, 2),
    (3, 3, 4, 3, '2023-03-15T00:00:00', '789 Pine St', '123 Main St', 35, 1);
-- Добавление данных в таблицу Orders
INSERT INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
VALUES (1, 1, 1, 2, GETDATE(), '123 Main St', '456 Elm St', 50, 1);

INSERT INTO Payments (id_order, Amount, datetimepay, method_id)
VALUES (4, 50, GETDATE(), 1);

SELECT Email_cst FROM Customers where Email_cst='email455@gmail.com';

USE TransportServiceDB;
GO
CREATE PROCEDURE AddPaymentMethod(@methodName NVARCHAR(50))
AS
BEGIN
    INSERT INTO Methods (method_name)
    VALUES (@methodName);
END;

DECLARE @MethodName NVARCHAR(50) = 'PayPal'; -- Замените на желаемое имя метода оплаты

EXEC AddPaymentMethod @MethodName;

CREATE FUNCTION CalculateTotalPayment(@orderId INT)
RETURNS INT
AS
BEGIN
    DECLARE @TotalPayment INT;

    SELECT @TotalPayment = SUM(Amount)
    FROM Payments
    WHERE id_order = @orderId;

    RETURN @TotalPayment;
END;

DECLARE @OrderId INT = 4; -- Замените на фактический OrderId
DECLARE @TotalAmount INT;

SET @TotalAmount = dbo.CalculateTotalPayment(@OrderId);
SELECT @TotalAmount AS TotalPayment;

USE TransportServiceDB;
GO
CREATE OR ALTER PROCEDURE InsertCustomer
    @p_name_cst NVARCHAR(50),
    @p_surname_cst NVARCHAR(50),
    @p_address_cst NVARCHAR(50),
    @p_phone_cst NVARCHAR(50),
    @p_email_cst NVARCHAR(50)
AS
BEGIN
    INSERT INTO Customers (Name_cst, Surname_cst, Addres_cst, Phone_cst, Email_cst)
    VALUES (@p_name_cst, @p_surname_cst, @p_address_cst, @p_phone_cst, @p_email_cst);
END;
USE TransportServiceDB;
GO
EXEC InsertCustomer
    @p_name_cst = N'Имя', 
    @p_surname_cst = N'Фамилия', 
    @p_address_cst = N'Адрес',  
    @p_phone_cst = N'Телефон',
    @p_email_cst = N'Email'; 
GO
	CREATE OR ALTER PROCEDURE InsertDriver
    @p_name_drv NVARCHAR(50),
    @p_surname_drv NVARCHAR(50),
    @p_addres_drv NVARCHAR(50),
    @p_phone_drv NVARCHAR(50),
    @p_driver_licence NVARCHAR(50)
AS
BEGIN
    INSERT INTO Drivers (Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
    VALUES (@p_name_drv, @p_surname_drv, @p_addres_drv, @p_phone_drv, @p_driver_licence);
    COMMIT;
END;
GO
EXEC InsertDriver
    @p_name_drv = N'Иван',
    @p_surname_drv = N'Петров',
    @p_addres_drv = N'ул. Примерная, д. 456',
    @p_phone_drv = N'+9876543210',
    @p_driver_licence = N'AB123456';

	select * from Drivers;

	USE TransportServiceDB;
GO
CREATE OR ALTER PROCEDURE InsertVehicle
    @p_type NVARCHAR(255),
    @p_license_plate NVARCHAR(20),
    @p_model NVARCHAR(255),
    @p_status_id INT,
    @p_location NVARCHAR(255),
    @p_fuel NVARCHAR(50),
    @p_issue_year NVARCHAR(4),
    @p_color NVARCHAR(50)
AS
BEGIN
    INSERT INTO Vehicles ( type, License_Plate, model, status_id, location, fuel, issue_year, color)
    VALUES ( @p_type, @p_license_plate, @p_model, @p_status_id, @p_location, @p_fuel, @p_issue_year, @p_color);
    COMMIT;
END;
go
EXEC InsertVehicle
    @p_type = N'Седан',
    @p_license_plate = N'ABC123',
    @p_model = N'Модель',
    @p_status_id = 1,
    @p_location = N'Гараж',
    @p_fuel = N'Бензин',
    @p_issue_year = N'2022',
    @p_color = N'Синий';
	select * from Vehicles;





GO

	CREATE OR ALTER PROCEDURE ShowOrders
AS
BEGIN
    DECLARE @Order_id INT,
            @driver_id INT,
            @client_id INT,
            @id_review INT,
            @car_id INT,
            @Order_DateTime DATETIME,
            @startpoint NVARCHAR(MAX),
            @endpoint NVARCHAR(MAX),
            @price DECIMAL(10, 2),
            @status_id INT;

    DECLARE order_cursor CURSOR FOR
    SELECT
        Order_id,
        driver_id,
        client_id,
        id_review,
        car_id,
        Order_DateTime,
        startpoint,
        endpoint,
        price,
        status_id
    FROM
        Orders;

    OPEN order_cursor;

    FETCH NEXT FROM order_cursor INTO
        @Order_id, @driver_id, @client_id, @id_review, @car_id, @Order_DateTime, @startpoint, @endpoint, @price, @status_id;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        PRINT 'Order ID: ' + CAST(@Order_id AS NVARCHAR(MAX));
        PRINT 'Driver ID: ' + CAST(@driver_id AS NVARCHAR(MAX));
        PRINT 'Client ID: ' + CAST(@client_id AS NVARCHAR(MAX));
        PRINT 'Review ID: ' + CAST(@id_review AS NVARCHAR(MAX));
        PRINT 'Car ID: ' + CAST(@car_id AS NVARCHAR(MAX));
        PRINT 'Order Date and Time: ' + CONVERT(NVARCHAR(MAX), @Order_DateTime, 120);
        PRINT 'Start Point: ' + @startpoint;
        PRINT 'End Point: ' + @endpoint;
        PRINT 'Price: ' + CAST(@price AS NVARCHAR(MAX));
        PRINT 'Status ID: ' + CAST(@status_id AS NVARCHAR(MAX));
        PRINT '------------------';

        FETCH NEXT FROM order_cursor INTO
            @Order_id, @driver_id, @client_id, @id_review, @car_id, @Order_DateTime, @startpoint, @endpoint, @price, @status_id;
    END;

    CLOSE order_cursor;
    DEALLOCATE order_cursor;
END;

-- Вызываем процедуру
EXEC ShowOrders;





BEGIN
    DECLARE @i INT = 1;

    WHILE @i <= 10000
    BEGIN
        INSERT INTO Customers (
            Name_cst,
            Surname_cst,
            Addres_cst,
            Phone_cst,
            Email_cst
        ) VALUES (
            'Customer' + CAST(@i AS NVARCHAR(10)),
            'Surname' + CAST(@i AS NVARCHAR(10)),
            'Address' + CAST(@i AS NVARCHAR(10)),
            'Phone' + CAST(@i AS NVARCHAR(10)),
            'customer' + CAST(@i AS NVARCHAR(10)) + '@example.com'
        );

        SET @i = @i + 1;
    END;

    COMMIT;
END;
GO


-- Удалите индекс
DROP INDEX Customers.IX_Customers_Email;
GO
CREATE NONCLUSTERED INDEX IX_Customers_Email ON Customers(Email_cst);
GO
SELECT * FROM Customers WHERE Email_cst LIKE '%1673%';



-- Удалите индекс

----- Лаба 3
USE TransportServiceDB;
GO
ALTER TABLE Customers
ADD HierarchyNode HIERARCHYID;

select * from Customers;
GO
UPDATE Customers
SET HierarchyNode = HIERARCHYID::Parse('/1/3/') where Customer_id=4;

CREATE PROCEDURE DisplaySubordinates
    @NodeHierarchy HIERARCHYID
AS
BEGIN
    SELECT 
        Customer_id,
        Name_cst,
        Surname_cst,
        Addres_cst,
        Phone_cst,
        Email_cst,
        HierarchyNode.ToString() AS HierarchyPath
    FROM Customers
    WHERE HierarchyNode.IsDescendantOf(@NodeHierarchy) = 1 -- проверка является ли потомком
    ORDER BY HierarchyNode;
END;
GO
DECLARE @NodeHierarchy HIERARCHYID = '/1/2/';

EXEC DisplaySubordinates @NodeHierarchy;

USE TransportServiceDB;
GO
CREATE PROCEDURE AddSubordinate
    @ParentNodeHierarchy HIERARCHYID,
    @NewNodeName NVARCHAR(50),
    @NewNodeSurname NVARCHAR(50),
    @NewNodeAddress NVARCHAR(50),
    @NewNodePhone NVARCHAR(50),
    @NewNodeEmail NVARCHAR(50)
AS
BEGIN
    DECLARE @NewNode HIERARCHYID;

    SELECT @NewNode = HierarchyNode.GetDescendant(NULL, NULL) -- генерация потомка
    FROM Customers
    WHERE HierarchyNode = @ParentNodeHierarchy;

    INSERT INTO Customers (Name_cst, Surname_cst, Addres_cst, Phone_cst, Email_cst, HierarchyNode)
    VALUES (@NewNodeName, @NewNodeSurname, @NewNodeAddress, @NewNodePhone, @NewNodeEmail, @NewNode);
END;
GO
DECLARE @ParentNodeHierarchy HIERARCHYID = '/1/2/';
DECLARE @NewNodeName NVARCHAR(50) = 'Ivan';
DECLARE @NewNodeSurname NVARCHAR(50) = 'New Surname';
DECLARE @NewNodeAddress NVARCHAR(50) = 'New Address';
DECLARE @NewNodePhone NVARCHAR(50) = 'New Phone';
DECLARE @NewNodeEmail NVARCHAR(50) = 'new@email.com';

EXEC AddSubordinate @ParentNodeHierarchy, @NewNodeName, @NewNodeSurname, @NewNodeAddress, @NewNodePhone, @NewNodeEmail;
USE TransportServiceDB;
GO
CREATE PROCEDURE MoveSubtree
    @SourceNodeHierarchy HIERARCHYID,
    @DestinationNodeHierarchy HIERARCHYID
AS
BEGIN
    UPDATE Customers
    SET HierarchyNode = HierarchyNode.GetReparentedValue(@SourceNodeHierarchy, @DestinationNodeHierarchy) 
    WHERE HierarchyNode.IsDescendantOf(@SourceNodeHierarchy) = 1;
END;

GO
DECLARE @SourceNodeHierarchy HIERARCHYID = '/1/3/';
DECLARE @DestinationNodeHierarchy HIERARCHYID = '/1/2/';

EXEC MoveSubtree @SourceNodeHierarchy, @DestinationNodeHierarchy;

-- HierarchyNode.GetReparentedValue(@SourceNodeHierarchy, @DestinationNodeHierarchy): Этот метод генерирует новое значение HIERARCHYID, перенося узлы из старого уровня иерархии (@SourceNodeHierarchy) на новый уровень (@DestinationNodeHierarchy).
--HierarchyNode.IsDescendantOf(@SourceNodeHierarchy) = 1: Это условие проверяет, является ли текущее значение HierarchyNode потомком узла @SourceNodeHierarchy. Только те строки, для которых это условие истинно, будут обновлены.


--lab 4
USE TransportServiceDB;
GO
--z1
SELECT DISTINCT
    MONTH(Order_DateTime) AS Month,
	DATEPART(QUARTER, Order_DateTime) AS Quarter,
	    DATEPART(YEAR, Order_DateTime) AS Year,
    SUM(price) OVER (PARTITION BY DATEPART(YEAR, Order_DateTime), MONTH(Order_DateTime) ORDER BY DATEPART(YEAR, Order_DateTime), MONTH(Order_DateTime)) AS TotalMonthly,
    SUM(price) OVER (PARTITION BY DATEPART(YEAR, Order_DateTime), DATEPART(QUARTER, Order_DateTime) ORDER BY DATEPART(YEAR, Order_DateTime), DATEPART(QUARTER, Order_DateTime)) AS TotalQuarterly,
    SUM(price) OVER (PARTITION BY DATEPART(YEAR, Order_DateTime) ORDER BY DATEPART(YEAR, Order_DateTime)) AS TotalYearly
FROM
    Orders
ORDER BY
    Year, Quarter, Month;
	SELECT * from Orders;
go

--z2
WITH ServiceTotals AS (
    SELECT
        DATEPART(YEAR, Order_DateTime) AS Year,
        DATEPART(MONTH, Order_DateTime) AS Month,
        SUM(price) AS Total
    FROM
        Orders
    GROUP BY
        DATEPART(YEAR, Order_DateTime),
        DATEPART(MONTH, Order_DateTime)
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

--z4
WITH OrderedOrders AS (
    SELECT
        Order_id,
        Order_DateTime,
        startpoint,
        endpoint,
        price,
        ROW_NUMBER() OVER (ORDER BY Order_DateTime) AS RowNum
    FROM
        Orders
)

SELECT
    Order_id,
    Order_DateTime,
    startpoint,
    endpoint,
    price
FROM
    OrderedOrders
WHERE
    RowNum BETWEEN 1 AND 20 -- Выбор строк для первой страницы
ORDER BY
    Order_DateTime;

-- Вторая страница начинается с 21
WITH OrderedOrders AS (
    SELECT
        Order_id,
        Order_DateTime,
        startpoint,
        endpoint,
        price,
        ROW_NUMBER() OVER (ORDER BY Order_DateTime) AS RowNum
    FROM
        Orders
)

SELECT
    Order_id,
    Order_DateTime,
    startpoint,
    endpoint,
    price
FROM
    OrderedOrders
WHERE
    RowNum BETWEEN 21 AND 40 -- Выбор строк для второй страницы
ORDER BY
    Order_DateTime;

--z5
select * from Status;
INSERT INTO Status(Status_name) VALUES ('Available');
WITH RankedStatus AS (
    SELECT
        status_id,
        Status_name,
        ROW_NUMBER() OVER (PARTITION BY Status_name ORDER BY (SELECT NULL)) AS RowNum
    FROM
        Status
)

DELETE FROM RankedStatus
WHERE
    RowNum > 1;

--z6

WITH RankedOrders AS (
    SELECT
        Order_id,
        client_id,
        Order_DateTime,
        startpoint,
        endpoint,
        price,
        ROW_NUMBER() OVER (PARTITION BY client_id ORDER BY Order_DateTime DESC) AS RowNum,
        COUNT(*) OVER (PARTITION BY client_id) AS OrderCount
    FROM
        Orders
)

SELECT
    Order_id,
    client_id,
    Order_DateTime,
    startpoint,
    endpoint,
    price,
    RowNum
FROM
    RankedOrders
WHERE
    RowNum <= 6 AND OrderCount >= 6
ORDER BY
    client_id, RowNum;

--z7
WITH RankedRoutes AS (
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
)

SELECT
    VehicleType,
    startpoint,
    endpoint
FROM
    RankedRoutes
WHERE
    PopularityRank = 1
ORDER BY
    VehicleType;

go
INSERT INTO Drivers (Name_drv, Surname_drv, Addres_drv, Phone_drv, driver_licence)
VALUES
    ('Michael', 'Johnson', '123 Main St', '555-1234', 'DL12345'),
    ('Emily', 'Smith', '456 Oak St', '555-5678', 'DL67890'),
    ('Christopher', 'Brown', '789 Pine St', '555-9876', 'DL45678'),
    ('Olivia', 'Davis', '101 Maple Ave', '555-1111', 'DL78901'),
    ('William', 'Miller', '202 Elm St', '555-2222', 'DL23456'),
    ('Emma', 'Taylor', '303 Cedar St', '555-3333', 'DL34567'),
    ('Daniel', 'Moore', '404 Birch St', '555-4444', 'DL89012'),
    ('Sophia', 'Jones', '505 Pine St', '555-5555', 'DL56789'),
    ('Jackson', 'Martin', '606 Oak St', '555-6666', 'DL45678'),
    ('Ava', 'White', '707 Elm St', '555-7777', 'DL12345'),
    ('Liam', 'Evans', '808 Cedar St', '555-8888', 'DL67890'),
    ('Oliver', 'Clark', '909 Birch St', '555-9999', 'DL23456'),
    ('Isabella', 'Perez', '101 Maple Ave', '555-1111', 'DL78901'),
    ('Lucas', 'Baker', '121 Pine St', '555-2222', 'DL34567'),
    ('Mia', 'Anderson', '232 Oak St', '555-3333', 'DL89012'),
    ('Logan', 'Cooper', '343 Cedar St', '555-4444', 'DL56789'),
    ('Amelia', 'Hill', '454 Elm St', '555-5555', 'DL45678'),
    ('Ethan', 'Ward', '565 Birch St', '555-6666', 'DL12345'),
    ('Aria', 'Fisher', '676 Pine St', '555-7777', 'DL67890'),
    ('Carter', 'Woods', '787 Oak St', '555-8888', 'DL23456'),
    ('Abigail', 'Bishop', '898 Cedar St', '555-9999', 'DL78901'),
    ('Noah', 'Larson', '909 Birch St', '555-1111', 'DL34567'),
    ('Sophie', 'Dixon', '110 Main St', '555-2222', 'DL89012'),
    ('Henry', 'Mills', '121 Pine St', '555-3333', 'DL56789'),
    ('Lily', 'Warner', '232 Oak St', '555-4444', 'DL45678'),
    ('Elijah', 'Fields', '343 Cedar St', '555-5555', 'DL12345'),
    ('Avery', 'Murray', '454 Elm St', '555-6666', 'DL67890'),
    ('Grace', 'Gardner', '565 Birch St', '555-7777', 'DL23456'),
    ('Owen', 'Vaughn', '676 Pine St', '555-8888', 'DL78901'),
    ('Scarlett', 'Hudson', '787 Oak St', '555-9999', 'DL34567'),
    ('Leo', 'Cole', '898 Cedar St', '555-1111', 'DL89012'),
    ('Hannah', 'Hartman', '909 Birch St', '555-2222', 'DL56789'),
    ('Isaac', 'Ross', '110 Main St', '555-3333', 'DL45678'),
    ('Ella', 'Barker', '121 Pine St', '555-4444', 'DL12345'),
    ('Caleb', 'Fleming', '232 Oak St', '555-5555', 'DL67890'),
    ('Nova', 'Fisher', '343 Cedar St', '555-6666', 'DL23456'),
    ('Gabriel', 'Wallace', '454 Elm St', '555-7777', 'DL78901'),
    ('Aurora', 'Perry', '565 Birch St', '555-8888', 'DL34567'),
    ('Ezra', 'Dunn', '676 Pine St', '555-9999', 'DL89012'),
    ('Stella', 'Spencer', '787 Oak St', '555-1111', 'DL56789'),
    ('Max', 'Hudson', '898 Cedar St', '555-2222', 'DL45678'),
    ('Aria', 'Cole', '909 Birch St', '555-3333', 'DL12345'),
    ('Silas', 'Hartman', '110 Main St', '555-4444', 'DL67890'),
    ('Luna', 'Ross', '121 Pine St', '555-5555', 'DL23456');

INSERT INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
VALUES
(14, 3, 4, 2, '2023-04-10T14:30:00', '123 Main St', '789 Pine St', 40, 2);
	go
	INSERT INTO Orders (driver_id, client_id, id_review, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
VALUES
    (3, 3, 4, 2, '2023-02-10T14:30:00', '456 Oak St', '789 Pine St', 40, 2),
    (5, 4, 5, 9, '2023-03-15T18:45:00', '789 Pine St', '123 Main St', 35, 1),
    (6, 4, 4, 9, '2023-04-20T08:00:00', '101 Maple Ave', '202 Elm St', 25, 2),
    (7, 7, 4, 2, '2023-07-05T08:45:00', '789 Pine St', '123 Main St', 40, 2),
    (8, 8, 4, 8, '2023-08-10T14:30:00', '123 Main St', '456 Oak St', 35, 1),
    (9, 9, 4, 9, '2023-09-15T18:45:00', '456 Oak St', '789 Pine St', 25, 2),
    (10, 10, 4, 2, '2023-10-20T08:00:00', '789 Pine St', '123 Main St', 45, 2),
    (11, 11, 4, 8, '2023-11-25T16:30:00', '101 Maple Ave', '202 Elm St', 30, 1),
    (12, 12, 4, 2, '2023-12-30T12:00:00', '202 Elm St', '567 Pine St', 40, 2),
    (13, 13, 4, 9, '2024-01-05T08:45:00', '567 Pine St', '789 Pine St', 35, 1),
    (14, 14, 1, 9, '2024-02-10T14:30:00', '789 Pine St', '123 Main St', 25, 2),
    (15, 15, 1, 8, '2024-03-15T18:45:00', '123 Main St', '456 Oak St', 45, 2),
    (16, 16, 1, 8, '2024-04-20T08:00:00', '456 Oak St', '789 Pine St', 30, 1),
    (17, 17, 4, 8, '2024-05-25T16:30:00', '789 Pine St', '123 Main St', 40, 2),
    (18, 18, 4, 8, '2024-06-30T12:00:00', '101 Maple Ave', '202 Elm St', 35, 1),
    (19, 19, 4, 8, '2024-07-05T08:45:00', '202 Elm St', '567 Pine St', 25, 2),
    (20, 20, 4, 2, '2024-08-10T14:30:00', '567 Pine St', '789 Pine St', 45, 2),
    (21, 21, 4, 2, '2024-09-15T18:45:00', '789 Pine St', '123 Main St', 30, 1),
    (22, 22, 4, 2, '2024-10-20T08:00:00', '123 Main St', '456 Oak St', 40, 2),
    (23, 23, 4, 2, '2024-11-25T16:30:00', '456 Oak St', '789 Pine St', 35, 1),
    (24, 24, 4, 2, '2024-12-30T12:00:00', '789 Pine St', '123 Main St', 25, 2),
    (25, 25, 4, 2, '2025-01-05T08:45:00', '101 Maple Ave', '202 Elm St', 45, 2),
    (26, 26, 4, 2, '2025-02-10T14:30:00', '202 Elm St', '567 Pine St', 30, 1),
    (27, 27, 4, 2, '2025-03-15T18:45:00', '567 Pine St', '789 Pine St', 40, 2),
    (28, 28, 4, 2, '2025-04-20T08:00:00', '789 Pine St', '123 Main St', 35, 1),
    (29, 29, 4, 2, '2025-05-25T16:30:00', '123 Main St', '456 Oak St', 25, 2),
    (30, 30, 5, 9, '2025-06-30T12:00:00', '456 Oak St', '789 Pine St', 45, 2),
    (31, 31, 5, 9, '2025-07-05T08:45:00', '789 Pine St', '123 Main St', 30, 1),
    (32, 32, 5, 9, '2025-08-10T14:30:00', '101 Maple Ave', '202 Elm St', 40, 2),
    (33, 33, 5, 9, '2025-09-15T18:45:00', '202 Elm St', '567 Pine St', 35, 1),
    (34, 34, 5, 9, '2025-10-20T08:00:00', '567 Pine St', '789 Pine St', 25, 2),
    (35, 35, 5, 9, '2025-11-25T16:30:00', '789 Pine St', '123 Main St', 45, 2),
    (36, 36, 5, 9, '2025-12-30T12:00:00', '123 Main St', '456 Oak St', 30, 1),
    (37, 37, 5, 9, '2026-01-05T08:45:00', '456 Oak St', '789 Pine St', 40, 2),
    (38, 38, 5, 9, '2026-02-10T14:30:00', '789 Pine St', '123 Main St', 35, 1),
    (39, 39, 5, 9, '2026-03-15T18:45:00', '101 Maple Ave', '202 Elm St', 25, 2),
    (40, 40, 1, 2, '2026-04-20T08:00:00', '202 Elm St', '567 Pine St', 45, 2),
    (41, 41, 1, 2, '2026-05-25T16:30:00', '567 Pine St', '789 Pine St', 30, 1),
    (42, 42, 1, 2, '2026-06-30T12:00:00', '789 Pine St', '123 Main St', 40, 2),
    (43, 43, 1, 2, '2026-07-05T08:45:00', '123 Main St', '456 Oak St', 35, 1),
    (44, 44, 1, 2, '2026-08-10T14:30:00', '456 Oak St', '789 Pine St', 25, 2),
    (45, 45, 1, 2, '2026-09-15T18:45:00', '789 Pine St', '123 Main St', 45, 2),
    (46, 46, 1, 2, '2026-10-20T08:00:00', '101 Maple Ave', '202 Elm St', 30, 1),
    (47, 47, 1, 2, '2026-11-25T16:30:00', '202 Elm St', '567 Pine St', 40, 2),
    (48, 48, 1, 2, '2026-12-30T12:00:00', '567 Pine St', '789 Pine St', 35, 1),
    (49, 49, 1, 8, '2027-01-05T08:45:00', '789 Pine St', '123 Main St', 25, 2);

	--lab5 


	USE TransportServiceDB;
SELECT SCHEMA_NAME
FROM INFORMATION_SCHEMA.SCHEMATA
	-- 6.	Определите тип пространственных данных во всех таблицах
-- Эти данные описывают местоположение объектов в пространстве и могут быть использованы для моделирования и анализа географических и пространственных явлений.
SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA = 'dbo'
-- 7.	Определите SRID - идентификатор системы координат
-- Примеры SRID включают SRID 4326, который обозначает систему координат WGS 84 (широта/долгота), который используется для веб-карт в проекции Web Mercator.
-- geometry_columns - ПКМ edit top 200 - SRID - 4326
SELECT *
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'ne_110m_geography_regions_polys' AND DATA_TYPE = 'geometry'


select distinct geom.STSrid as SRID from dbo.ne_110m_geography_regions_polys

SELECT
	srid
FROM
    dbo.geometry_columns
	-- 8.	Определите атрибутивные столбцы
-- содержат информацию об атрибутах (характеристиках) географических объектов
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA = 'dbo' AND DATA_TYPE <> 'geometry'


-- 9.	Верните описания пространственных объектов в формате WKT
--  текстовый формат для представления геометрических объектов в пространстве
SELECT geom.STAsText() AS WKT_Description
FROM ne_110m_geography_regions_polys

-- 10
select * from ne_110m_geography_regions_polys

-- 10.1.	Нахождение пересечения пространственных объектов;
-- Определение области, общей для двух или более пространственных объектов.

SELECT obj1.geom.STIntersection(obj2.geom) AS Intersection
FROM ne_110m_geography_regions_polys obj1, ne_110m_geography_regions_polys obj2
WHERE obj1.qgs_fid = 2 AND obj2.qgs_fid = 3

-- 10.2.	Нахождение объединения пространственных объектов;

SELECT obj1.geom.STUnion(obj2.geom) AS [Union]
FROM ne_110m_geography_regions_polys obj1, ne_110m_geography_regions_polys obj2
WHERE obj1.qgs_fid = 2 AND obj2.qgs_fid = 3

-- 10.3.	Нахождение вложенности пространственных объектов;

SELECT obj1.geom.STWithin(obj2.geom) AS [IsWithin]
FROM ne_110m_geography_regions_polys obj1, ne_110m_geography_regions_polys obj2
WHERE obj1.qgs_fid = 2 AND obj2.qgs_fid = 3

-- 10.4.	Упрощение пространственного объекта;
-- Уменьшение сложности геометрии объекта с сохранением его основных характеристик.

SELECT geom.Reduce(0.1) AS Simplified --насколько сильно должен быть упрощен геометрический объект
FROM ne_110m_geography_regions_polys
WHERE qgs_fid = 6

-- 10.5.	Нахождение координат вершин пространственного объектов

SELECT geom.STPointN(1).ToString() AS VertexCoordinates
FROM ne_110m_geography_regions_polys
WHERE qgs_fid = 6

-- 10.6.	Нахождение размерности пространственных объектов
-- Выявление размерности геометрического объекта. Например, точка имеет размерность 0, линия - 1, а полигон - 2.
SELECT geom.STDimension() AS ObjectDimension
FROM ne_110m_geography_regions_polys
WHERE qgs_fid = 4

-- 10.7.	Нахождение длины и площади пространственных объектов;
-- Длина (Length): Измерение длины линейных объектов, таких как линии или полилинии.
-- Площадь (Area): Измерение площади замкнутых объектов, таких как полигоны.
SELECT geom.STLength() AS ObjectLength, geom.STArea() AS ObjectArea
FROM ne_110m_geography_regions_polys
WHERE qgs_fid = 5


-- 10.8.	Нахождение расстояния между пространственными объектами;

SELECT obj1.geom.STDistance(obj2.geom) AS Distance
FROM ne_110m_geography_regions_polys obj1, ne_110m_geography_regions_polys obj2
WHERE obj1.qgs_fid = 6 AND obj2.qgs_fid = 4


-- 11.	Создайте пространственный объект в виде точки (1) /линии (2) /полигона (3).
-- точка
DECLARE @pointGeometry GEOMETRY;
SET @pointGeometry = GEOMETRY::STGeomFromText('POINT(50 50)', 0);

SELECT @pointGeometry AS PointGeometry;

-- линия
DECLARE @lineGeometry GEOMETRY;
SET @lineGeometry = GEOMETRY::STGeomFromText('LINESTRING(25 10, 10 25, 50 50)', 0);

SELECT @lineGeometry AS LineGeometry;


-- полигон
DECLARE @polygonGeometry GEOMETRY;
SET @polygonGeometry = GEOMETRY::STGeomFromText('POLYGON((15 10, 55 55, 9 8, 12 2, 15 10))', 0);

SELECT @polygonGeometry AS PolygonGeometry;


-- 12.	Найдите, в какие пространственные объекты попадают созданные вами объекты

-- точка и полигон
DECLARE @point GEOMETRY = GEOMETRY::STGeomFromText('POINT(50 50)', 0);
DECLARE @polygon GEOMETRY = GEOMETRY::STGeomFromText('POLYGON((40 40, 40 60, 60 60, 60 40, 40 40))', 0);
SELECT @polygon AS PolygonGeometry;
SELECT @point.STWithin(@polygon) AS PointWithinPolygon;

-- прямая и полигон
DECLARE @line GEOMETRY = GEOMETRY::STGeomFromText('LINESTRING(25 10, 10 25, 50 50)', 0);
DECLARE @polygonn GEOMETRY = GEOMETRY::STGeomFromText('POLYGON((40 40, 40 60, 60 60, 60 40, 40 40))', 0);

SELECT @line.STIntersects(@polygonn) AS LineIntersectsPolygon;



--lab10 

mlkwcnikhiuuijrz

use TransportServiceDB;
go

exec sp_configure 'show advanced options', 1;
go 
reconfigure
go 
exec sp_configure 'clr enabled',1;
exec sp_configure 'clr strict security', 0

CREATE ASSEMBLY lab10CLR
FROM 'D:\БД-3\lab10CLR\lab10CLR\bin\Debug\lab10CLR.dll'
WITH PERMISSION_SET = SAFE;

CREATE TYPE lab10CLR.Route
EXTERNAL NAME lab10CLR.Route;

CREATE PROCEDURE DeleteCustomerData
    @CustomerName NVARCHAR(255),
    @Route Route
AS
EXTERNAL NAME lab10CLR.StoredProcedures.SendEmailOnDelete;

DECLARE @route lab10CLR.Route;
SET @route = lab10CLR.Route.Parse('YourRouteInfo');

EXEC DeleteCustomerData
    @CustomerName = 'PAVEL',
    @Route = null;
