CREATE TABLE OPA_t(x number(3),s varchar2(50),
                   PRIMARY KEY(x));

INSERT INTO OPA_t VALUES[];
INSERT INTO OPA_t VALUES(2,'Alex');
INSERT INTO OPA_t VALUES(3,'Gleb');

COMMIT;

SELECT * FROM OPA_t;


UPDATE OPA_t SET s = 'Ars' WHERE s = 'Alex';
COMMIT;
UPDATE OPA_t SET s = 'Kane' WHERE s = 'Gleb'


SELECT * FROM OPA_t WHERE x = 2;

SELECT sum(x) FROM OPA_t; 


DELETE FROM OPA_t WHERE s='Ars';
ROLLBACK;

CREATE TABLE OPA_t1(x number(3), s varchar(50),
                    FOREIGN KEY(x) 
                    REFERENCES OPA_t);

INSERT INTO OPA_t1 VALUES(1,'Genry');
INSERT INTO OPA_t1 VALUES(2,'Alex');
INSERT INTO OPA_t1 VALUES(3,'Petya');

SELECT * FROM OPA_t1;

SELECT * FROM OPA_t a LEFT OUTER JOIN OPA_t1 b
    ON a.x = b.x
    WHERE a.x = 1;
    
SELECT * FROM OPA_t a RIGHT OUTER JOIN OPA_t1 b
    ON a.x = b.x
    WHERE a.x = 3;    

SELECT * FROM OPA_t a INNER JOIN OPA_t1 b
    ON a.x = b.x
    WHERE a.s = 'Paul';

DROP TABLE OPA_t;
DROP TABLE OPA_t1;