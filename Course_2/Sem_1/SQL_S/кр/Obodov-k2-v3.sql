/*Ободов Павел, Исит-2, Вариант 3
*/



use exam_schema;
go
create procedure zadanie11 @a char(3), @b char(5), @disc nvarchar(20), @pr money, @qty int
as declare @rc int = 1;
begin try
insert into PRODUCTS
values (@a,@b,@disc,@pr,@qty)
return @rc;
end try
begin catch
print 'номер ошибки :' + cast(error_number() as varchar(6));
print 'msg:' + error_message();
print 'level: ' + cast(error_severity() as varchar(6));
print 'metka: ' + cast(error_state() as varchar(8));
print 'nomer stroki: ' + cast(error_line() as varchar(8));
if ERROR_PROCEDURE() is not null
print 'name procedure: ' + error_procedure();
return -1;
end catch;
go
create function zadanie12(@off int) returns int
as begin declare @rc int = 0;
if(@off is not null)
begin
set @rc = (select count(ORDER_NUM) from ORDERS
inner join SALESREPS
on ORDERS.REP = SALESREPS.EMPL_NUM
inner join OFFICES
on SALESREPS.REP_OFFICE = OFFICEs.OFFICE)
return @rc;
end
else 
set @rc = -1;
return @rc ;
end;
go
create procedure zadanie13 @n int
as declare @rc int = 1;
begin try
declare @tv char(20), @t char(300) = ' ';  
      declare ZkTov CURSOR  for 
      select ORDERs.ORDER_NUM , ORDERS.AMOUNT from ORDERS where ORDERS.QTY > @n order by AMOUNT desc
    
      open ZkTov;	  
  fetch  ZkTov into @tv;   
  print   'Выбранные заказы: ';   
  while @@fetch_status = 0                                     
   begin 

set @t = rtrim(@tv) + ', ' + @t;  
       set @rc = @rc + 1;       
       fetch  ZkTov into @tv; 
    end;   
print @t;        
close  ZkTov;
    return @rc;

end try  
   begin catch              
        print 'ошибка в параметрах' 
        if error_procedure() is not null   
  print 'имя процедуры : ' + error_procedure();
        return @rc;
   end catch; 
go
create function zadanie14(@name nvarchar(50)) returns int
as begin declare @rc int = 0;
if(@name is not null)
begin
declare @a int;
set @a = cast((select SALESREPS.EMPL_NUM from SALESREPS where SALESREPS.NAME = @name) as int);
set @rc = (select count(SALESREPS.NAME) from SALESREPS
where SALESREPS.MANAGER = @a)
return @rc;
end
else 
set @rc = -1;
return @rc ;
end;
go EXEC zadanie11 @a= 2, @b= 4, @disc= 'Хороший товар' , @pr= 200, @qty= 30
go EXEC zadanie13 @n=15



