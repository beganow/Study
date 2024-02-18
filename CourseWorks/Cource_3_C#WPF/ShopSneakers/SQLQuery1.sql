use  Sneackers;

DBCC CHECKIDENT ('Users', RESEED, 1);
CREATE TABLE Users (
	user_id INT Identity(1,1) PRIMARY KEY,
	login Varchar(50) NOT NULL,
	password Varchar(50) NOT NULL,
	email varchar(255),
	role INT NOT NULL default 2,
	FOREIGN KEY (role) REFERENCES Roles(role_id)
);
select * from Users;
DELETE FROM Sneackers where sneaker_id=2;
 


CREATE TABLE  Roles (
	role_id INT Identity(1,1)  PRIMARY KEY,
	role_name varchar(50) 
);

CREATE TABLE OrdersHistory(
	orderhistory_id INT Identity(1,1)  PRIMARY KEY,
	order_id INT NOT NULL,
	id_user INT NOT NULL,
	order_date DATETIME NOT NULL,
	status INT NOT NULL,
	full_price decimal(10,2) NOT NULL,
	FOREIGN KEY (status) REFERENCES Statuses(id_status),
	FOREIGN KEY (id_user) REFERENCES Users(user_id),
	FOREIGN KEY (order_id) REFERENCES Orders(order_id)
);

Create Table Statuses (
	id_status INT Identity(1,1) PRIMARY KEY,
	status_name varchar(50) NOT NULL 
);

CREATE TABLE Payments(
	payment_id INT Identity(1,1) PRIMARY KEY,
	payment_method varchar(50) NOT NULL 
)

CREATE TABLE Sneackers (
	sneaker_id INT IDENTITY(1,1) PRIMARY KEY,
	Name VArchar(50) NOT NULL ,
	FullName Varchar(50) NOT NULL,
	Image VARCHAR(20) NOT NULL,
	Category VARCHAR(20) NOT NULL,
	Rate FLOAT NOT NULL,
	size int NOT NULL,
	count int NOT NULL,
	price decimal(10,2) NOT NULL, 
);

CREATE TABLE Orders(
	order_id INT Identity(1,1) PRIMARY KEY,
	user_id INT,
	id_sneacker INT,
	payment_method_id INT,
	user_address varchar(255),
	date_delivery DATETIME,
	FOREIGN KEY (payment_method_id) REFERENCES Payments(payment_id),
	FOREIGN KEY (user_id) REFERENCES Users(user_id),
	FOREIGN KEY (id_sneacker) REFERENCES Sneackers(sneaker_id)
);



CREATE PROCEDURE InsertIntoRoles
    @role_name varchar(50)
AS
BEGIN
    INSERT INTO Roles(role_name)
    VALUES (@role_name)
END

EXEC InsertIntoRoles @role_name = 'User'

select * from Roles;


CREATE PROCEDURE InsertIntoUsers
    @login varchar(50),
    @password varchar(50),
    @email varchar(255)
AS
BEGIN
    INSERT INTO Users(login, password, email)
    VALUES (@login, @password, @email)
END

select * from Sneackers;
select * from Orders;



DBCC CHECKIDENT ('Sneackers', RESEED, 0);











CREATE PROCEDURE update_sneakers
  @Name Varchar(50),
  @FullName Varchar(50),
  @index INT,
  @Image VARCHAR(20),
  @Category VARCHAR(20),
  @Rate FLOAT,
  @Size INT,
  @Count INT,
  @Price DECIMAL(10,2)
AS
BEGIN
	
  UPDATE sneackers
  SET
    Name = @Name,
    FullName = @FullName,
    Image = @Image,
    Category = @Category,
    Rate = @Rate,
    Size =  @Size,
    Count = @Count,
    Price = @Price
    WHERE sneaker_id =  @index;
END;

DROP PROCEDURE update_sneakers;


select * from Users;
select * from Orders;


CREATE PROCEDURE DeleteUserByLogin
    @Login NVARCHAR(50),
	@UserId INT
AS
BEGIN
	DELETE FROM Orders
    WHERE user_id = @UserId;
    DELETE FROM Users
    WHERE login = @Login;
END;
DROP PROCEDURE DeleteUserByLogin;

SELECT user_id FROM users WHERE login = 'Nikit';

CREATE PROCEDURE AddSneaker
  @Name Varchar(50),
  @FullName Varchar(50),
  @ImageFileName VARCHAR(20),
  @Category VARCHAR(20),
  @Rate FLOAT,
  @Size INT,
  @Count INT,
  @Price DECIMAL(10,2)
AS
BEGIN 
  INSERT INTO Sneackers (Name, FullName, Image, Category, Rate, Size, Count, Price)
  VALUES (@Name, @FullName,  @ImageFileName, @Category, @Rate, @Size, @Count, @Price);
END;


CREATE PROCEDURE DeleteSneaker
  @index INT
AS
BEGIN
 -- Удаление связанных данных из таблицы OrdersHistory
  DELETE FROM OrdersHistory
  WHERE order_id IN (SELECT order_id FROM Orders WHERE id_sneacker = @index);

  -- Удаление связанных данных из таблицы Orders
  DELETE FROM Orders
  WHERE id_sneacker = @index;

  -- Удаление главной записи из таблицы sneackers
  DELETE FROM sneackers
  WHERE sneaker_id = @index;
END;
select * from Orders;
select * from Sneackers
DROP PROCEDURE DeleteSneaker; 


CREATE PROCEDURE AddOrder
	@user_id INT,
	@id_sneacker INT,
	@payment_method_id INT,
	@user_address varchar(255),
	@date_delivery datetime
AS
	BEGIN 
	INSERT INTO Orders(user_id, id_sneacker, payment_method_id, user_address, date_delivery)
	VALUES (@user_id, @id_sneacker, @payment_method_id, @user_address, @date_delivery)
end;

DROP PROCEDURE AddOrder;
select * from Orders;
DELETE FROM ORDERS where order_id=1;
EXEC AddOrder @user_id = 1, @id_sneacker = 1, @payment_method_id = 1, @user_address = 'Some address', @date_delivery = '2023-12-20';



CREATE PROCEDURE AddOwnOrder
	@order_id INT,
	@id_user INT,
	@order_date DATETIME,
	@status INT,
	@full_price decimal(10,2)
AS
	BEGIN 
	INSERT INTO OrdersHistory(order_id, id_user, order_date, status, full_price)
	VALUES (@order_id, @id_user, @order_date, @status, @full_price)
end;

CREATE VIEW OrderDetails AS
SELECT
    U.login AS Login,
    S.Name AS Name,
    S.FullName AS Full_Name,
    S.Category AS Category,
    S.size AS size,
    O.user_address AS user_address,
	OH.order_date AS order_date,
    O.date_delivery AS date_delivery,
    ST.Status_name AS Status_name,
	 P.payment_method AS payment_method,
	S.price AS price,
FROM
    OrdersHistory OH
    INNER JOIN Orders O ON OH.order_id = O.order_id
    INNER JOIN Users U ON OH.id_user = U.user_id
    INNER JOIN Sneackers S ON O.id_sneacker = S.sneaker_id
    INNER JOIN Payments P ON O.payment_method_id = P.payment_id
    INNER JOIN Statuses ST ON OH.status = ST.id_status;

	DROP VIEW IF EXISTS OrderDetails;
	SELECT * FROM OrderDetails;