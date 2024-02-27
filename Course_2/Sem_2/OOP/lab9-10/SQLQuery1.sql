use  Library; 

Create table Authors(
  ID int IDENTITY(1,1) PRIMARY KEY,
  Name Varchar(30),
  Adress Varchar(30)
  );
  select * from Authors;
 INSERT INTO Authors (Name, Adress)
VALUES ('John Doe', '123 Main Street'),
       ('Jane Smith', '456 Elm Avenue'),
       ('David Johnson', '789 Oak Drive');

  Create table Books(
  ID int IDENTITY(1,1) PRIMARY KEY,
  Title Varchar(30),
  Genre Varchar(30),
  Author_ID INT,
   FOREIGN KEY (Author_ID) REFERENCES Authors(ID)
  );



