use X_MyBASE
CREATE TABLE Передачи
 (   Название nvarchar(20) primary key,
	Рейтинг_передачи real,
	Стоимость_минуты real unique not null
)