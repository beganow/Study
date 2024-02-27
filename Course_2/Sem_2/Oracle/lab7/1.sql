/*task 1*/
SELECT SUM(VALUE/1024/1024)AS "Size (MB)" FROM V$SGA;

/*task 2*/
SELECT NAME, BYTES/1024/1024 AS "Size (MB)"
FROM V$SGAINFO;

/*task 3*/
SELECT COMPONENT, GRANULE_SIZE/1024/1024 
FROM V$SGA_DYNAMIC_COMPONENTS;

/* task 4*/
SELECT SUM(BYTES/1024/1024) AS "Size (MB)" FROM V$SGASTAT
WHERE NAME = 'free memory';

/* task5 */
SELECT SUM(VALUE/1024/1024) AS "SGA_SIZE(MB)" 
FROM V$SGA;
SELECT VALUE/1024/1024, Name FROM V$PARAMETER WHERE NAME = 'sga_max_size';

/* task 6*/
SELECT *
FROM V$SGA_DYNAMIC_COMPONENTS
WHERE COMPONENT LIKE '%buffer%';


/* task 7*/
SELECT OWNER, SEGMENT_NAME, SEGMENT_TYPE, BLOCKS, BYTES, EXTENTS, BUFFER_POOL
FROM dba_segments
WHERE segment_name = 'MY_TABLE';


/* task 8*/
SELECT OWNER, SEGMENT_NAME, SEGMENT_TYPE, BLOCKS, BYTES, EXTENTS, BUFFER_POOL
FROM dba_segments
WHERE segment_name = 'MY_TABLE1';

/* task 9*/
SELECT value/1024/1024 as "Size(MB)" FROM v$parameter WHERE name = 'log_buffer';

/* task 10*/
SELECT *
FROM v$sgastat
WHERE pool = 'large pool' AND name = 'free memory';

/* task 11*/
SELECT sid, serial#, program, server
FROM v$session
WHERE type != 'BACKGROUND';

/* task 12*/
SELECT * FROM v$bgprocess;

/* task 13*/
SELECT * FROM v$process;

/* task 14*/
SELECT COUNT(*) FROM v$process WHERE pname LIKE 'DBW%';

/* task 15*/
SELECT DISTINCT name FROM v$active_services;

/* task 16*/
SELECT name FROM v$parameter;

/* task 17*/