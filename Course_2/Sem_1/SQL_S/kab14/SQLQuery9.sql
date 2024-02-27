USE UNIVER;

go
create trigger DDL_UNIVER on database for DDL_DATABASE_LEVEL_EVENTS  
as  
declare @t varchar(50)= EVENTDATA().value ('(/EVENT_INSTANCE/EventType)[1]', 'varchar(50)');
declare @t1 varchar(50)=EVENTDATA().value ('(/EVENT_INSTANCE/ObjectName)[1]', 'varchar(50)');
declare @t2 varchar(50)=EVENTDATA().value('(/EVENT_INSTANCE/ObjectType)[1]', 'varchar(50)'); 
if @t2 = 'TABLE' 
begin
  print 'Тип события: '+@t;
  print 'Имя объекта: '+@t1;
  print 'Тип объекта: '+@t2;
  raiserror( N'операции с таблицами запрещены', 16, 1);  
  rollback;    
end;
create table a(c int);
go

DISABLE TRIGGER DDL_UNIVER ON DATABASE;
DROP TRIGGER DDL_UNIVER ON DATABASE;