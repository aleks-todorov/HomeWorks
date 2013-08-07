CREATE FUNCTION StrConcat ()
RETURNS varchar
AS
BEGIN
DECLARE @result varchar(MAX)
SELECT @result= e.FirstName + ' ' + e.LastName
    FROM Employees e 
RETURN (@result)
END