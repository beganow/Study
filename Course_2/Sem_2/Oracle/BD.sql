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
             values  ('ИДиП',   'Издателькое дело и полиграфия');
insert into FACULTY1   (FACULTY1,   FACULTY_NAME1 )
            values  ('ХТиТ',   'Химическая технология и техника');
insert into FACULTY1   (FACULTY1,   FACULTY_NAME1 )
            values  ('ЛХФ',     'Лесохозяйственный факультет');
insert into FACULTY1   (FACULTY1,   FACULTY_NAME1 )
            values  ('ИЭФ',     'Инженерно-экономический факультет');
insert into FACULTY1   (FACULTY1,   FACULTY_NAME1 )
            values  ('ТТЛП',    'Технология и техника лесной промышленности');
insert into FACULTY1   (FACULTY1,   FACULTY_NAME1 )
            values  ('ТОВ',     'Технология органических веществ');

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
             values('ИСиТ','Иформационный систем и технологий','ИДиП');
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,FACULTY1)
             values  ('ПОиСОИ', 'Полиграфического оборудования и систем обработки', 'ИДиП');
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,FACULTY1)
              values  ('ЛВ',      'Лесоводства','ЛХФ') ;         
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                   FACULTY1)
             values  ('ОВ',      'Охотоведения',                                                 'ЛХФ') ;   
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                   FACULTY1)
             values  ('ЛУ',      'Лесоустройства',                                              'ЛХФ');           
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                   FACULTY1)
             values  ('ЛЗиДВ',   'Лесозащиты и древесиноведения',                               'ЛХФ');                
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                   FACULTY1)
             values  ('ЛПиСПС',  'Ландшафтного проектирования и садово-паркового','ЛХФ');                  
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                   FACULTY1)
             values  ('ТЛ',     'Транспорта леса',                                              'ТТЛП');                        
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                   FACULTY1)
             values  ('ЛМиЛЗ',  'Лесных машин и технологии лесозаготовок',                      'ТТЛП');                        
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                   FACULTY1)
             values  ('ОХ',     'Органической химии',                                           'ТОВ');            
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                              FACULTY1)
             values  ('ТНХСиППМ','Технологии нефтехимического синтеза и переработки','ТОВ');             
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                      FACULTY1)
             values  ('ТНВиОХТ','Технологии неорганических веществ и общей химической','ХТиТ');                    
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                                         FACULTY1)
             values  ('ХТЭПиМЭЕ','Химии, технологии электрохимических производс', 'ХТиТ');
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                      FACULTY1)
             values  ('ЭТиМ',    'экономической теории и маркетинга',                              'ИЭФ');   
insert into PULPIT1   (PULPIT1,    PULPIT_NAME1,                                                      FACULTY1)
             values  ('МиЭП',   'Менеджмента и экономики природопользования',                      'ИЭФ');    
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
                       values  ('СМЛВ',    'Смелов Владимир Владисла',  'ИСиТ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('АКНВЧ',    'Акунович Станислав Иван',  'ИСиТ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('КЛСНВ',    'Колесников Леонид Вале',  'ИСиТ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('ГРМН',    'Герман Олег Вито',  'ИСиТ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('ЛЩНК',    'Лащенко Анатолий Пвал',  'ИСиТ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('БРКВЧ',    'Бракович Андрей Игорьевич',  'ИСиТ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('ДДК',     'Дедко Александр Аркадьевич',  'ИСиТ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('КБЛ',     'Кабайло Александр Се',  'ИСиТ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('УРБ',     'Урбанович Павел Павлович',  'ИСиТ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('РМНК',     'Романенко Дмитрий Михайлч',  'ИСиТ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('ПСТВЛВ',  'Пустовалова Наталия Ник', 'ИСиТ' );
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('?',     'Неизвестный',  'ИСиТ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                      values  ('ГРН',     'Гурин Николай Иванович',  'ИСиТ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('ЖЛК',     'Жиляк Надежда Алекса',  'ИСиТ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('БРТШВЧ',   'Барташевич Святослав Але',  'ПОиСОИ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('ЮДНКВ',   'Юденков Виктор Степанович',  'ПОиСОИ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('БРНВСК',   'Барановский Станислав ',  'ЭТиМ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('НВРВ',   'Неверов Александр ',  'МиЭП');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('РВКЧ',   'Ровкач Андрей Иванович',  'ОВ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('ДМДК', 'Демидко Марина',  'ЛПиСПС');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('МШКВСК',   'Машковский Владимир',  'ЛУ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('ЛБХ',   'Лабоха Константин ',  'ЛВ');
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('ЗВГЦВ',   'Звягинцев Вячеслав',  'ЛЗиДВ'); 
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('БЗБРДВ',   'Безбородов Владимир Ст',  'ОХ'); 
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('ПРКПЧК',   'Прокопчук Николай Р',  'ТНХСиППМ'); 
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('НСКВЦ',   'Насковец Михаил Трофимович',  'ТЛ'); 
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('МХВ',   'Мохов Сергей Петрович',  'ЛМиЛЗ'); 
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('ЕЩНК',   'Ещенко Людмила Семеновна',  'ТНВиОХТ'); 
insert into  TEACHER1    (TEACHER1,  TEACHER_NAME1, PULPIT1 )
                       values  ('ЖРСК',   'Жарский Иван Михайлович',  'ХТЭПиМЭЕ'); 
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
                       values ('СУБД',   'Системы управления бд',                   'ИСиТ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1)
                       values ('БД',     'Базы данных',                                        'ИСиТ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('ИНФ',    'Информацтонные технологии',                          'ИСиТ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('ОАиП',  'Основы алгоритмизации ',            'ИСиТ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('ПЗ',     'Представление знаний ',       'ИСиТ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('ПСП',    'Пограммирование сетевых пр',                 'ИСиТ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('МСОИ',     'Моделирование систем о',        'ИСиТ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('ПИС',     'Проектирование информ',              'ИСиТ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('КГ',      'Компьютерная геометрия ',                           'ИСиТ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('ПМАПЛ',   'Полиграфические машины', 'ПОиСОИ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('КМС',     'Компьютерные мультимедий',               'ИСиТ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('ОПП',     'Организация полиграфич',         'ПОиСОИ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
               values ('ДМ',   'Дискретная матеатика',                     'ИСиТ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
               values ('МП',   'Математисеское программирование',          'ИСиТ');  
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
               values ('ЛЭВМ', 'Логические основы ЭВМ',                     'ИСиТ');                   
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
               values ('ООП',  'Объектно-ориентированное программирование', 'ИСиТ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('ЭП',     'Экономика природопользования',                       'МиЭП');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('ЭТ',     'Экономическая теория',                               'ЭТиМ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('БЛЗиПсOO','Биология лесных зверей и птиц с осн. охотов.',      'ОВ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('ОСПиЛПХ','Основы садовопаркового и лесопаркового хозяйства',  'ЛПиСПС');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('ИГ',     'Инженерная геодезия ',                              'ЛУ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('ЛВ',    'Лесоводство',                                        'ЛЗиДВ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('ОХ',    'Органическая химия',                                 'ОХ');   
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('ТРИ',    'Технология резиновых изделий',                      'ТНХСиППМ'); 
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('ВТЛ',    'Водный транспорт леса',                             'ТЛ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('ТиОЛ',   'Технология и оборудование лесозаготовок',           'ЛМиЛЗ'); 
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('ТОПИ',   'Технология обогащения полезных ископаемых ',        'ТНВиОХТ');
insert into SUBJECT1   (SUBJECT1,   SUBJECT_NAME1,        PULPIT1 )
                       values ('ПЭХ',    'Прикладная электрохимия',                           'ХТЭПиМЭЕ');          
---------------------------------------------------------------------------------------------------------------------
-- DROP TABLE AUDITORIUM_TYPE 
create table AUDITORIUM_TYPE 
(
  AUDITORIUM_TYPE   char(10) constraint AUDITORIUM_TYPE_PK  primary key,  
  AUDITORIUM_TYPENAME  varchar2(100) constraint AUDITORIUM_TYPENAME_NOT_NULL not null         
);

delete AUDITORIUM_TYPE;
insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE,   AUDITORIUM_TYPENAME )
                       values  ('ЛК',   'Лекционная');
insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE,   AUDITORIUM_TYPENAME )
                       values  ('ЛБ-К',   'Компьютерный класс');
insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE,   AUDITORIUM_TYPENAME )
                       values  ('ЛК-К', 'Лекционная с уст. компьютерами');
insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE,   AUDITORIUM_TYPENAME )
                       values  ('ЛБ-X', 'Химическая лаборатория');
insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE,   AUDITORIUM_TYPENAME )
                       values  ('ЛБ-СК', 'Спец. компьютерный класс');
---------------------------------------------------------------------------------------------------------------------
-- DROP TABLE AUDITORIUM 
create table AUDITORIUM1 
(
 AUDITORIUM1          char(10) primary key,  -- код аудитории
 AUDITORIUM_NAME1      varchar2(200),          -- аудитория 
 AUDITORIUM_CAPACITY1  number(4),              -- вместимость
 AUDITORIUM_TYPE1     char(10) not null      -- тип аудитории
                      references AUDITORIUM_TYPE(AUDITORIUM_TYPE)  
);

delete  AUDITORIUM;
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('206-1',   '206-1', 'ЛБ-К', 15);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('301-1',   '301-1', 'ЛБ-К', 15);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('236-1',   '236-1', 'ЛК',   60);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('313-1',   '313-1', 'ЛК',   60);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('324-1',   '324-1', 'ЛК',   50);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('413-1',   '413-1', 'ЛБ-К', 15);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('423-1',   '423-1', 'ЛБ-К', 90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('408-2',   '408-2', 'ЛК',  90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('103-4',   '103-4', 'ЛК',  90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('105-4',   '105-4', 'ЛК',  90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('107-4',   '107-4', 'ЛК',  90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('110-4',   '110-4', 'ЛК',  30);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('111-4',   '111-4', 'ЛК',  30);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                      values  ('114-4',   '114-4', 'ЛК-К',  90 );
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values ('132-4',   '132-4', 'ЛК',   90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values ('02Б-4',   '02Б-4', 'ЛК',   90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values ('229-4',   '229-4', 'ЛК',   90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('304-4',   '304-4','ЛБ-К', 90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('314-4',   '314-4', 'ЛК',  90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('320-4',   '320-4', 'ЛК',  90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                       values  ('429-4',   '429-4', 'ЛК',  90);
insert into  AUDITORIUM1   (AUDITORIUM1,   AUDITORIUM_NAME1, AUDITORIUM_TYPE1, AUDITORIUM_CAPACITY1 )
                        values  ('?',   '???', 'ЛК',  90);
-----------------------------------------------------------------------------------------------------------------------







 