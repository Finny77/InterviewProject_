
IF NOT EXISTS(SELECT 1 FROM sys.databases WHERE NAME ='EmployeeManagement')
BEGIN
CREATE DATABASE EmployeeManagement
END 

USE EmployeeManagement

IF NOT EXISTS(SELECT * FROM sys.tables WHERE NAME ='Employee')
BEGIN 
PRINT 4
CREATE TABLE Employee(
EmployeeId INT IDENTITY(1,1) NOT NULL,
EmployeeName  NVARCHAR(200) NOT NULL,
Designation	 VARCHAR(200)  NULL,
EmailAddress  VARCHAR(300)  NULL,
MobilePhone  VARCHAR(50)  NULL,
DateOfBirth  DATE  NULL,
Nationality	 VARCHAR(50)  NULL,
IsActive BIT NULL, 
CreatedDate DATETIME NULL
);
END  

ALTER TABLE Employee
ADD CONSTRAINT Default_CreatedDate  DEFAULT(GETDATE()) FOR CreatedDate
 
  