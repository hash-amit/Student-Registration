-- Create the database
CREATE DATABASE dbStudents;
GO

-- Use the database
USE dbStudents;
GO

-- Create tbCountries table
CREATE TABLE tbCountries
(
    [COUNTRY ID] INT PRIMARY KEY NOT NULL,
    [COUNTRY NAME] VARCHAR(60) NOT NULL
);

-- Insert data into tbCountries table
INSERT INTO tbCountries ([COUNTRY ID], [COUNTRY NAME])
VALUES (1, 'India'), (2, 'United States'), (3, 'Pakistan');

-- Create tbCourses table
CREATE TABLE tbCourses
(
    [CID] INT PRIMARY KEY NOT NULL,
    [COURSE NAME] VARCHAR(60) NOT NULL
);

-- Insert data into tbCourses table
INSERT INTO tbCourses ([CID], [COURSE NAME])
VALUES
    (1, 'Web Development'),
    (2, 'Database Management'),
    (3, 'Mobile App Development'),
    (4, 'Data Science'),
    (5, 'Machine Learning'),
    (6, 'Network Security'),
    (7, 'Artificial Intelligence'),
    (8, 'Cloud Computing'),
    (9, 'Game Development'),
    (10, 'UI/UX Design');

-- Create tbGender table
CREATE TABLE tbGender
(
    [GID] INT PRIMARY KEY NOT NULL,
    [GENDER NAME] VARCHAR(6) NOT NULL
);

-- Insert data into tbGender table
INSERT INTO tbGender ([GID], [GENDER NAME])
VALUES (1, 'Male'), (2, 'Female'), (3, 'Other');

-- Create tbStates table
CREATE TABLE tbStates
(
    [STATE ID] INT PRIMARY KEY NOT NULL,
    [COUNTRY ID] INT NOT NULL,
    [STATE NAME] VARCHAR(60) NOT NULL
);

-- Insert data into tbStates table
INSERT INTO tbStates ([STATE ID], [COUNTRY ID], [STATE NAME])
VALUES
    (1, 1, 'Delhi'),
    (2, 1, 'Mumbai'),
    (3, 1, 'Bangalore'),
    (4, 1, 'Kolkata'),
    (5, 1, 'Chennai'),
    (6, 2, 'New York'),
    (7, 2, 'Los Angeles'),
    (8, 2, 'Chicago'),
    (9, 2, 'Houston'),
    (10, 2, 'San Francisco'),
    (11, 3, 'Lahore'),
    (12, 3, 'Karachi'),
    (13, 3, 'Islamabad'),
    (14, 3, 'Faisalabad'),
    (15, 3, 'Rawalpindi');

-- Create tbStudents table
CREATE TABLE tbStudents
(
    [SID] INT PRIMARY KEY NOT NULL,
    [FULL NAME] VARCHAR(60) NOT NULL,
    [EMAIL] VARCHAR(60) NOT NULL,
    [GENDER] INT NOT NULL,
    [COURSE] INT NOT NULL,
    [COUNTRY] INT NOT NULL,
    [STATE] INT NOT NULL,
    [PHONE] VARCHAR(20) NOT NULL,
    [PASSWORD] VARCHAR(10) NOT NULL,
	[PHOTO] VARCHAR(100) NOT NULL
);

-- Removing all the records from the table "tbStudents"
TRUNCATE TABLE tbStudents;

-- Add one more column in tbStudents for photo
ALTER TABLE tbStudents ADD [PHOTO] VARCHAR(100) NOT NULL

-- Rename the column
sp_rename 'tbStudents.Photo', 'PHOTO';

-- To view the column, whether added or not
SELECT * FROM tbStudents

-- Stored Procedures
CREATE PROC spBindCountries  
AS  
BEGIN  
    SELECT * FROM tbCountries;  
END;

CREATE PROC spBindCourses  
AS  
BEGIN  
    SELECT * FROM tbCourses;  
END;

CREATE PROC spBindGender  
AS  
BEGIN  
    SELECT * FROM tbGender;  
END;

CREATE PROC spBindStates  
(  
    @country int  
)  
AS  
BEGIN  
    SELECT * FROM tbStates WHERE [COUNTRY ID] = @country;  
END;

CREATE PROC spChangePassword  
(  
    @new_pass VARCHAR(10),  
    @student_id INT,  
    @current_pass VARCHAR(10)  
)  
AS  
BEGIN  
    UPDATE tbStudents  
    SET [PASSWORD] = @new_pass  
    WHERE  
    [SID] = @student_id AND [PASSWORD] = @current_pass;  
END;

CREATE PROC spCheckEmail  
(  
    @email VARCHAR(60)  
)  
AS  
BEGIN  
    SELECT * FROM tbStudents WHERE [EMAIL] = @email;  
END;

CREATE PROC spCheckEmailPass  
(  
    @email VARCHAR(60),  
    @pass VARCHAR(10)  
)  
AS  
BEGIN  
    SELECT * FROM tbStudents    
    WHERE  
    [EMAIL] = @email AND [PASSWORD] = @pass;  
END;

CREATE PROC spDeleteRecord  
(  
    @id INT  
)  
AS  
BEGIN  
    DELETE FROM tbStudents WHERE [SID] = @id;  
END;

CREATE PROC spGetUserDetails  
(  
    @student_id int  
)  
AS  
BEGIN  
    SELECT * FROM tbStudents   
    JOIN tbGender ON [GENDER] = [GID]   
    JOIN tbCourses ON [COURSE] = [CID]   
    JOIN tbCountries ON [COUNTRY] = [COUNTRY ID]   
    JOIN tbStates ON [STATE] = [STATE ID]   
    WHERE  
    [SID] = @student_id;  
END;

CREATE PROC spInstertData  
(  
    @fname varchar(60),  
    @email varchar(60),  
    @gender int,  
    @course int,  
    @country int,  
    @state int,  
    @phone varchar(20),  
    @pass varchar(10)  
)  
AS  
BEGIN  
    INSERT INTO tbStudents ([FULL NAME], [EMAIL], [GENDER], [COURSE], [COUNTRY], [STATE], [PHONE], [PASSWORD])  
    VALUES (@fname, @email, @gender, @course, @country, @state, @phone, @pass);  
END;

-- Modifying stored procedure
ALTER PROC spInstertData  
(  
    @fname varchar(60),  
    @email varchar(60),  
    @gender int,  
    @course int,  
    @country int,  
    @state int,  
    @phone varchar(20),  
    @pass varchar(10),
	@photo varchar(100)
)  
AS  
BEGIN  
    INSERT INTO tbStudents ([FULL NAME], [EMAIL], [GENDER], [COURSES], [COUNTRY], [STATE], [PHONE], [PASSWORD], [PHOTO])  
    VALUES (@fname, @email, @gender, @course, @country, @state, @phone, @pass, @photo);  
END;
