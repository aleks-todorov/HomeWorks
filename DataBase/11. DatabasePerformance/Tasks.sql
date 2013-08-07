/* 1. Create a table in SQL Server with 10 000 000 log entries (date + text). 
Search in the table by date range. Check the speed (without caching).*/

Insert INTO TestData(LogDate,LogText)
Values('1987-01-01', 'Some Text')

DECLARE @Counter int = 0
WHILE (SELECT COUNT(*) FROM TestData) < 10000000
BEGIN
  INSERT INTO TestData(LogDate, LogText)
  SELECT DATEADD(MONTH, @Counter + 2, LogDate), LogText + CONVERT(varchar, @Counter) FROM TestData
  SET @Counter = @Counter + 1
END

SELECT LogText FROM TestData WHERE LogDate
BETWEEN CONVERT(datetime, '1987-01-01') AND CONVERT(datetime, '1997-01-01');

/* 2. Add an index to speed-up the search by date. Test the search speed (after cleaning the cache).*/

CREATE INDEX IDX_OnLogsDateColumn ON TestData(LogDate);
 
 --Clear Cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;

SELECT LogText FROM TestData WHERE LogDate
BETWEEN CONVERT(datetime, '1987-01-01') AND CONVERT(datetime, '1997-01-01');

/* 3. Add a full text index for the text column. Try to search with and without the full-text index and compare the speed.*/

Select t.LogText FROM TestData t
Where LogText = 'Some Text013579162023'

CREATE FULLTEXT CATALOG PerformanceFullTextCatalogue
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON TestData(LogTest)
KEY INDEX PK_ID
ON PerformanceFullTextCatalogue
WITH CHANGE_TRACKING AUTO

Select t.LogText FROM TestData t
Where LogText = 'Some Text013579162023'

/* 4. Create the same table in MySQL and partition it by date (1990, 2000, 2010). Fill 1 000 000 log entries. 
Compare the searching speed in all partitions (random dates) to certain partition (e.g. year 1995).*/

DELIMITER $$
CREATE PROCEDURE PopulateDB()
BEGIN
DECLARE counter INT DEFAULT 0;
DECLARE minDate datetime;
DECLARE maxDate datetime;
SET minDate = '1980-01-01 00:00:00';
SET maxDate = '2014-01-01 00:00:00';
START TRANSACTION;
WHILE counter < 1000000 DO
INSERT INTO TestData(LogDate, LogText)
VALUES(TIMESTAMPADD(SECOND, FLOOR(RAND() * TIMESTAMPDIFF(SECOND, minDate, maxDate)), minDate),
CONCAT('Some Text', CAST(counter as CHAR)));
SET counter = counter + 1;
END WHILE;
COMMIT;
END $$
  
CALL PopulateDB()
 
CREATE DATABASE Particioned;

USE Particioned;

CREATE TABLE Logs(
LogId int NOT NULL AUTO_INCREMENT,
LogDate datetime,
LogText nvarchar(100),
CONSTRAINT PK_Logs_ID PRIMARY KEY(ID, LogDate)
) PARTITION BY RANGE(YEAR(LogDate))(
PARTITION p0 VALUES LESS THAN (1990),
    PARTITION p2 VALUES LESS THAN (2000),
PARTITION p3 VALUES LESS THAN (2010),
PARTITION p4 VALUES LESS THAN MAXVALUE
);

CALL PopulateDB()

SELECT * FROM Logs PARTITION (p0)

USE DatabasePerformance;
SELECT * FROM Logs
WHERE LogDate > '1990-01-01'

USE Particioned
SELECT * FROM Logs PARTITION(p0)
WHERE LogDate >'1990-01-01'



