use UNIVER
go
DROP procedure addspec
go
create procedure addspec @pr nvarchar(20), @f nvarchar(10) , @p nvarchar(100), @q varchar(50)
as begin
begin try insert into PROFESSION(PROFESSION, FACULTY, PROFESSION_NAME, QUALIFICATION)
  values (@pr, @f, @p, @q)
  return 1
  end try
  begin catch 
  PRINT 'NUM:' + CAST(ERROR_NUMBER() as varchar(6));
  PRINT 'MESSAGE:' + ERROR_MESSAGE();
  PRINT 'SEVERETY:' + CAST(ERROR_SEVERITY() as varchar(6));
  PRINT 'STATE:' + CAST(ERROR_STATE() as varchar(8));
  PRINT 'ERROR LINE:' + CAST(ERROR_LINE() as varchar(8));
  IF ERROR_PROCEDURE() is null 
  print 'In what proc:' + ERROR_PROCEDURE();
  return -1
  end catch;
  end;
  go
   declare @sr nvarchar(160);
  EXEC @sr = addspec @pr='1-25 01 08', @f='ИЭФ', @p = 'Экономика и управление на предприятииrethgfs' , @q= 'экономист-менеджерghdhdfv' 
  print 'STATUS:' + CAST(@sr as varchar(3))
  go
  alter procedure addspec @pr nvarchar(20), @f nvarchar(10) , @p nvarchar(100), @q varchar(50)
  as begin
   if exists (SELECT PROFESSION, PROFESSION_NAME, FACULTY, QUALIFICATION from PROFESSION where PROFESSION=@pr)
  update PROFESSION set PROFESSION=@pr, FACULTY=@f ,  PROFESSION_NAME=@p , QUALIFICATION=@q where PROFESSION=@pr;
  end;
  select * from PROFESSION
 


	
