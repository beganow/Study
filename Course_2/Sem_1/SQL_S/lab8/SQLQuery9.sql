/*9.Разработать сценарий с ошибками, в котором используются для обработки ошибок блоки TRY и CATCH. 
Приме-нить функции ERROR_NUMBER (код последней ошибки), ERROR_ES-SAGE (сообщение об ошибке), ERROR_LINE (код последней ошибки), ER-ROR_PROCEDURE (имя процедуры или NULL), ERROR_SEVERITY (уро-вень серьезности ошибки), ERROR_ STATE (метка ошибки). Проанализи-ровать результат. */


USE UNIVER;
BEGIN TRY
UPDATE PROGRESS SET NOTE = 'Отличная отметка' WHERE NOTE = 9
END TRY
BEGIN CATCH
PRINT ERROR_NUMBER() -- код последней ошибки
PRINT ERROR_MESSAGE() -- сообщение об ошибке
PRINT ERROR_LINE() -- код последней ошибки
PRINT ERROR_PROCEDURE() -- имя процедуры или NULL
PRINT ERROR_SEVERITY() -- уро-вень серьезности ошибки
PRINT ERROR_STATE() -- метка ошибки
END CATCH