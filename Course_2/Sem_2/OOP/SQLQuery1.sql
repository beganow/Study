use Sneackers;


CREATE TABLE users (
  user_id INT IDENTITY(1,1) PRIMARY KEY,
	login Varchar(50) NOT NULL,
	password Varchar(50) NOT NULL,
);


CREATE TABLE sneakers (
  sneaker_id INT IDENTITY(1,1) PRIMARY KEY,
	Name VArchar(50) NOT NULL,
	FullName Varchar(50) NOT NULL,
	Image VARCHAR(20) NOT NULL,
	Category VARCHAR(20) NOT NULL,
	Rate FLOAT NOT NULL,
	size int NOT NULL,
	count int NOT NULL,
	price decimal(10,2) NOT NULL,
	user_id int NOT NULL, 
	 FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE PROCEDURE update_sneakers
  @Name Varchar(50),
  @FullName Varchar(50),
  @Image VARCHAR(20),
  @Category VARCHAR(20),
  @Rate FLOAT,
  @Size INT,
  @Count INT,
  @Price DECIMAL(10,2),
  @UserID INT
AS
BEGIN
	
  UPDATE sneakers
  SET
    Name = @Name,
    FullName = @FullName,
    Image = @Image,
    Category = @Category,
    Rate = @Rate,
    Size =  @Size,
    Count = @Count,
    Price = @Price
    WHERE USER_ID =  @UserID;
END;

DROP PROCEDURE update_sneakers;

CREATE PROCEDURE InsertUser
  @username VARCHAR(50),
  @password VARCHAR(100)
AS
BEGIN
  INSERT INTO users (login, password)
  VALUES (@username, @password);
END;

DROP PROCEDURE InsertUser;

select * from users;
select * from sneakers;



CREATE PROCEDURE DeleteUserByName
    @Username NVARCHAR(50)
AS
BEGIN
    DECLARE @UserId INT

    -- Получаем идентификатор пользователя по имени
    SELECT @UserId = USER_ID
    FROM users
    WHERE login = @Username

    -- Удаляем строку с найденным идентификатором
    DELETE FROM users
    WHERE USER_ID = @UserId;
END


CREATE PROCEDURE AddSneaker
  @Name Varchar(50),
  @FullName Varchar(50),
  @ImageFileName VARCHAR(20),
  @Category VARCHAR(20),
  @Rate FLOAT,
  @Size INT,
  @Count INT,
  @Price DECIMAL(10,2),
  @UserID INT
AS
BEGIN 
  INSERT INTO sneakers (Name, FullName, Image, Category, Rate, Size, Count, Price, user_id)
  VALUES (@Name, @FullName,  @ImageFileName, @Category, @Rate, @Size, @Count, @Price, @UserID);
END;



