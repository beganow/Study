use exam_schema

select CUST_NUM [Айди сотрудника], Company[Покупатели], AMOUNT [Стоимость заказа], QTY[Количество заказов], round((AMOUNT/QTY),2)[Средняя цена]
from CUSTOMERS inner join ORDERS
on CUST_NUM = CUST
where QTY>0
group by CUST_NUM,COMPANY, AMOUNT,QTY

select CUST_NUM [Айди сотрудника], COMPANY[Заказчик], QTY [Количество заказов]
from CUSTOMERS inner join ORDERS
on CUST_NUM = CUST
where (QTY=0) or (QTY is null)
group by CUST_NUM,COMPANY, QTY