use X_MyBASE
CREATE TABLE ������
 (   �����_������ nvarchar(20) primary key,
      ��������_�������� nvarchar(20)  foreign key  references ��������(��������),
																	                                                                                       
	     ���_������� nvarchar(20),
	     ����_������ date,
	     ������������_�_������� int,
		 �������� nvarchar(20)  foreign key references ���������(��������_�����),
																

)
