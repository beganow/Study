USE UNIVER
GO
DECLARE @H INT = 0,
@SBJ VARCHAR(3000) = N'<?xml VERSION="1.0" ENCODING="WINDOWS-1251" ?>
                      <ДИСЦИПЛИНЫ>
					     <ДИСЦИПЛИНА КОД="КГИГSAD" НАЗВАНИЕ="КОМПЬЮТЕРНАЯ ГЕОМЕТРИЯ И ГРАФИКА" КАФЕДРА="ИСИТ" />
						 <ДИСЦИПЛИНА КОД="ОЗИASD" НАЗВАНИЕ="ОСНОВЫ ЗАЩИТЫ ИНФОРМАЦИИ" КАФЕДРА="ИСИТ" />
						 <ДИСЦИПЛИНА КОД="МПASDП" НАЗВАНИЕ="МАТЕМАТИЧЕСКОЕ ПРОГРАММИРОВАНИЕ П" КАФЕДРА="ИСИТ" />
					  </ДИСЦИПЛИНЫ>';
EXEC SP_XML_PREPAREDOCUMENT @H OUTPUT, @SBJ;
INSERT SUBJECT SELECT[КОД], [НАЗВАНИЕ], [КАФЕДРА] FROM OPENXML(@H, '/ДИСЦИПЛИНЫ/ДИСЦИПЛИНА',0)
    WITH([КОД] CHAR(10), [НАЗВАНИЕ] VARCHAR(100), [КАФЕДРА] CHAR(20));

SELECT * FROM SUBJECT