USE UNIVER
GO
DECLARE @H INT = 0,
@SBJ VARCHAR(3000) = N'<?xml VERSION="1.0" ENCODING="WINDOWS-1251" ?>
                      <����������>
					     <���������� ���="����SAD" ��������="������������ ��������� � �������" �������="����" />
						 <���������� ���="���ASD" ��������="������ ������ ����������" �������="����" />
						 <���������� ���="��ASD�" ��������="�������������� ���������������� �" �������="����" />
					  </����������>';
EXEC SP_XML_PREPAREDOCUMENT @H OUTPUT, @SBJ;
INSERT SUBJECT SELECT[���], [��������], [�������] FROM OPENXML(@H, '/����������/����������',0)
    WITH([���] CHAR(10), [��������] VARCHAR(100), [�������] CHAR(20));

SELECT * FROM SUBJECT