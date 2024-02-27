-- DROP TABLE QQFACULTY
CREATE TABLE FACULTY1
  (
   FACULTY1      CHAR(200)      NOT NULL,
   FACULTY_NAME1 VARCHAR2(100), 
   CONSTRAINT PK_FACULTY1 PRIMARY KEY(FACULTY1) 
  );
delete QQFACULTY;
select * from FACULTY1;
insert into FACULTY1   (FACULTY1,   FACULTY_NAME1 )
             values  ('����',   '����������� ���� � ����������');
insert into FACULTY1   (FACULTY1,   FACULTY_NAME1 )
            values  ('����',   '���������� ���������� � �������');
insert into FACULTY1   (FACULTY1,   FACULTY_NAME1 )
            values  ('���',     '����������������� ���������');
insert into FACULTY1   (FACULTY1,   FACULTY_NAME1 )
            values  ('���',     '���������-������������� ���������');
insert into FACULTY1   (FACULTY1,   FACULTY_NAME1 )
            values  ('����',    '���������� � ������� ������ ��������������');
insert into FACULTY1   (FACULTY1,   FACULTY_NAME1 )
            values  ('���',     '���������� ������������ �������');

--------------------------------------------------------------------------------------------
-- DROP TABLE PULPIT1
CREATE TABLE PULPIT1 
(
 PULPIT1       CHAR(200)      NOT NULL,
 PULPIT_NAME1  VARCHAR2(100), 
 FACULTY1      CHAR(200)      NOT NULL, 
 CONSTRAINT FK_PULPIT_FACULTY1 FOREIGN KEY(FACULTY1) REFERENCES FACULTY1(FACULTY1), 
 CONSTRAINT PK_PULPIT1 PRIMARY KEY(PULPIT1) 
 ); 
 
delete PULPIT;  
insert into PULPIT1(PULPIT1,PULPIT_NAME1,FACULTY1)
             values('����','������������� ������ � ����������','����');
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,FACULTY1)
             values  ('������', '���������������� ������������ � ������ ���������', '����');
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,FACULTY1)
              values  ('��',      '�����������','���') ;         
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                   FACULTY1)
             values  ('��',      '������������',                                                 '���') ;   
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                   FACULTY1)
             values  ('��',      '��������������',                                              '���');           
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                   FACULTY1)
             values  ('�����',   '���������� � ����������������',                               '���');                
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                   FACULTY1)
             values  ('������',  '������������ �������������� � ������-���������','���');                  
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                   FACULTY1)
             values  ('��',     '���������� ����',                                              '����');                        
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                   FACULTY1)
             values  ('�����',  '������ ����� � ���������� �������������',                      '����');                        
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                   FACULTY1)
             values  ('��',     '������������ �����',                                           '���');            
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                              FACULTY1)
             values  ('��������','���������� ���������������� ������� � �����������','���');             
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                      FACULTY1)
             values  ('�������','���������� �������������� ������� � ����� ����������','����');                    
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                                         FACULTY1)
             values  ('��������','�����, ���������� ����������������� ���������', '����');
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                      FACULTY1)
             values  ('����',    '������������� ������ � ����������',                              '���');   
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                      FACULTY1)
             values  ('����',   '����������� � ��������� ������������������',                      '���');    
------------------------------------------------------------------------------------------------------------------------        - DROP  TABLE TEACHER
CREATE TABLE TEACHER1
 ( 
  TEACHER1       CHAR(100) NOT  NULL,
  TEACHER_NAME1 VARCHAR2(50), 
  PULPIT1        CHAR(200) NOT NULL, 
  CONSTRAINT PK_TEACHER1  PRIMARY KEY(TEACHER1), 
  CONSTRAINT FK_TEACHER_PULPIT1 FOREIGN   KEY(PULPIT1)   REFERENCES PULPIT1(PULPIT1)
 );
 
 
delete  TEACHER;
insert into  TEACHER1    (TEACHER1,   TEACHER_NAME1, PULPIT1 )
                       values  ('����',    '������ �������� ��������',  '����');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('�����',    '�������� ��������� ����',  '����');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('�����',    '���������� ������ ����',  '����');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('����',    '������ ���� ����',  '����');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('����',    '������� �������� ����',  '����');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('�����',    '�������� ������ ���������',  '����');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('���',     '����� ��������� ����������',  '����');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('���',     '������� ��������� ��',  '����');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('���',     '��������� ����� ��������',  '����');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('����',     '��������� ������� �������',  '����');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('������',  '����������� ������� ���', '����' );
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('?',     '�����������',  '����');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                      values  ('���',     '����� ������� ��������',  '����');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('���',     '����� ������� ������',  '����');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('������',   '���������� ��������� ���',  '������');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('�����',   '������� ������ ����������',  '������');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('������',   '����������� ��������� ',  '����');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('����',   '������� ��������� ',  '����');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('����',   '������ ������ ��������',  '��');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('����', '������� ������',  '������');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('������',   '���������� ��������',  '��');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('���',   '������ ���������� ',  '��');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('�����',   '��������� ��������',  '�����'); 
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('������',   '���������� �������� ��',  '��'); 
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('������',   '��������� ������� �',  '��������'); 
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('�����',   '�������� ������ ����������',  '��'); 
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('���',   '����� ������ ��������',  '�����'); 
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('����',   '������ ������� ���������',  '�������'); 
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('����',   '������� ���� ����������',  '��������'); 
---------------------------------------------------------------------------------------------------------------------
-- DROP TABLE SUBJECT1 
CREATE TABLE SUBJECT1
    (
     SUBJECT1      CHAR(10)     NOT NULL, 
     SUBJECT_NAME1 VARCHAR2(50)  NOT NULL,
     PULPIT1       CHAR(200)     NOT NULL,  
     CONSTRAINT PK_SUBJECT1 PRIMARY KEY(SUBJECT1),
     CONSTRAINT FK_SUBJECT_PULPIT1 FOREIGN  KEY(PULPIT1)  REFERENCES PULPIT1(PULPIT1)
    );

delete SUBJECT;
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('����',   '������� ���������� ��',                   '����');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1)
                       values ('��',     '���� ������',                                        '����');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('���',    '�������������� ����������',                          '����');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('����',  '������ �������������� ',            '����');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('��',     '������������� ������ ',       '����');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('���',    '��������������� ������� ��',                 '����');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('����',     '������������� ������ �',        '����');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('���',     '�������������� ������',              '����');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('��',      '������������ ��������� ',                           '����');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('�����',   '��������������� ������', '������');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('���',     '������������ �����������',               '����');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('���',     '����������� ����������',         '������');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
               values ('��',   '���������� ���������',                     '����');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
               values ('��',   '�������������� ����������������',          '����');  
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
               values ('����', '���������� ������ ���',                     '����');                   
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
               values ('���',  '��������-��������������� ����������������', '����');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('��',     '��������� ������������������',                       '����');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('��',     '������������� ������',                               '����');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('������OO','�������� ������ ������ � ���� � ���. ������.',      '��');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('�������','������ ��������������� � ������������� ���������',  '������');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('��',     '���������� �������� ',                              '��');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('��',    '�����������',                                        '�����');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('��',    '������������ �����',                                 '��');   
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('���',    '���������� ��������� �������',                      '��������'); 
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('���',    '������ ��������� ����',                             '��');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('����',   '���������� � ������������ �������������',           '�����'); 
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('����',   '���������� ���������� �������� ���������� ',        '�������');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('���',    '���������� ������������',                           '��������');          
---------------------------------------------------------------------------------------------------------------------
-- DROP TABLE AUDITORIUM_TYPE 
create table AUDITORIUM_TYPE 
(
  AUDITORIUM_TYPE   char(10) constraint AUDITORIUM_TYPE_PK  primary key,  
  AUDITORIUM_TYPENAME  varchar2(100) constraint AUDITORIUM_TYPENAME_NOT_NULL not null         
);

delete AUDITORIUM_TYPE;
insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE,   AUDITORIUM_TYPENAME )
                       values  ('��',   '����������');
insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE,   AUDITORIUM_TYPENAME )
                       values  ('��-�',   '������������ �����');
insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE,   AUDITORIUM_TYPENAME )
                       values  ('��-�', '���������� � ���. ������������');
insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE,   AUDITORIUM_TYPENAME )
                       values  ('��-X', '���������� �����������');
insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE,   AUDITORIUM_TYPENAME )
                       values  ('��-��', '����. ������������ �����');
---------------------------------------------------------------------------------------------------------------------
-- DROP TABLE AUDITORIUM 
create table AUDITORIUM1 
(
 AUDITORIUM1          char(10) primary key,  -- ��� ���������
 AUDITORIUM_NAME1      varchar2(200),          -- ��������� 
 AUDITORIUM_CAPACITY1  number(4),              -- �����������
 AUDITORIUM_TYPE1     char(10) not null      -- ��� ���������
                      references AUDITORIUM_TYPE(AUDITORIUM_TYPE)  
);

delete  AUDITORIUM;
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('206-1',   '206-1', '��-�', 15);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('301-1',   '301-1', '��-�', 15);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('236-1',   '236-1', '��',   60);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('313-1',   '313-1', '��',   60);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('324-1',   '324-1', '��',   50);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('413-1',   '413-1', '��-�', 15);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('423-1',   '423-1', '��-�', 90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('408-2',   '408-2', '��',  90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('103-4',   '103-4', '��',  90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('105-4',   '105-4', '��',  90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('107-4',   '107-4', '��',  90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('110-4',   '110-4', '��',  30);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('111-4',   '111-4', '��',  30);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                      values  ('114-4',   '114-4', '��-�',  90 );
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values ('132-4',   '132-4', '��',   90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values ('02�-4',   '02�-4', '��',   90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values ('229-4',   '229-4', '��',   90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('304-4',   '304-4','��-�', 90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('314-4',   '314-4', '��',  90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('320-4',   '320-4', '��',  90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('429-4',   '429-4', '��',  90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                        values  ('?',   '???', '��',  90);
-----------------------------------------------------------------------------------------------------------------------







 