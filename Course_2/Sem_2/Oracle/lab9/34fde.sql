CREATE DATABASE LINK carsh_link
CONNECT TO USER_1
IDENTIFIED BY u123
USING 'carsh';

select * from tab@carsh_link;


--create SYSTEM table


select * from USER_1.T1@carsh_link;
--drop table USER_1.T1@carsh_link
alter session set "_ORACLE_SCRIPT"=true
insert into USER_1.T1@carsh_link values(2, 'hdfs');

update USER_1.T1@carsh_link set column2 = 'defw' where column1 = 1;

delete from USER_1.T1@carsh_link where column2  = 'defw';

CREATE PROCEDURE get_rows_by_str(p_str IN nvarchar2) IS
numb int;
stri nvarchar2(50);
BEGIN
SELECT column1, column2
INTO numb, stri
FROM USER_1.T1@carsh_link
WHERE column2 = p_str;
END;

begin
get_rows_by_str('hdfs');
end;

drop procedure get_rows_by_str