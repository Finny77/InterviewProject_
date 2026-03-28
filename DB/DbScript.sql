
CREATE DATABASE EmployeeManagement


CREATE TABLE Employee(
EmployeeId INT IDENTITY(1,1) NOT NULL,
EmployeeName  NVARCHAR(200) NOT NULL,
Designation	 VARCHAR(200)  NULL,
EmailAddress  VARCHAR(300)  NULL,
MobilePhone  VARCHAR(50)  NULL,
DateOfBirth  DATE  NULL,
Nationality	 VARCHAR(50)  NULL,
IsActive BIT NULL,
IsDeleted BIT NULL,
CreatedDate DATETIME NULL
);