use exam_schema

select CUST_NUM [���� ����������], Company[����������], AMOUNT [��������� ������], QTY[���������� �������], round((AMOUNT/QTY),2)[������� ����]
from CUSTOMERS inner join ORDERS
on CUST_NUM = CUST
where QTY>0
group by CUST_NUM,COMPANY, AMOUNT,QTY

select CUST_NUM [���� ����������], COMPANY[��������], QTY [���������� �������]
from CUSTOMERS inner join ORDERS
on CUST_NUM = CUST
where (QTY=0) or (QTY is null)
group by CUST_NUM,COMPANY, QTY