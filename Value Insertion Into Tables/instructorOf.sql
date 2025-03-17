CREATE OR REPLACE FUNCTION instructorsof(deptname VARCHAR2)
RETURN instructor_table_type
AS
instructor_table instructor_table_type := instructor_table_type();
BEGIN
SELECT instructor_type(ID, name, deptname, salary)
BULK COLLECT INTO instructor_table
FROM instructor
WHERE instructor.dept_name = deptname;
RETURN instructor_table;
END;
