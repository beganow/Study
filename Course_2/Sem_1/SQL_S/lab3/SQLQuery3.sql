use X_MyBASE
CREATE TABLE Заказы
 (   Номер_заказа nvarchar(20) primary key,
      Название_передачи nvarchar(20)  foreign key  references Передачи(Название),
																	                                                                                       
	     Вид_рекламы nvarchar(20),
	     Дата_заказа date,
	     Длительность_в_минутах int,
		 Заказчик nvarchar(20)  foreign key references Заказчики(Название_фирмы),
																

)
