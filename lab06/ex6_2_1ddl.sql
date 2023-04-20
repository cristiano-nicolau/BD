CREATE SCHEMA Empresa
go

/*ALTER TABLE Empresa.Employee DROP CONSTRAINT Employee_Sssn;
ALTER TABLE Empresa.Employee DROP CONSTRAINT Employee_Dno;
ALTER TABLE Empresa.Dept_Locations DROP CONSTRAINT Department_Num;
ALTER TABLE Empresa.Project DROP CONSTRAINT	Project_Department;
ALTER TABLE Empresa.Works_on DROP CONSTRAINT Works_Essn;
ALTER TABLE Empresa.Works_on DROP CONSTRAINT Works_Pno;
ALTER TABLE [Empresa.Dependent] DROP CONSTRAINT Depedent_Essn;



DROP TABLE Empresa.Employee;
DROP TABLE Empresa.Department;
DROP TABLE Empresa.Dept_locations;
DROP TABLE Empresa.Project;
DROP TABLE Empresa.Works_on;
DROP TABLE [Empresa.Dependent];
*/


CREATE TABLE Empresa.Employee (
		Fname	CHAR(10)	NOT NULL	,
		Minit	CHAR(1)		,
		Lname	VARCHAR(10) NOT NULL	,
		Ssn		char(9)		NOT NULL,
		Bdate	DATE,
		Adress VARCHAR(50),
		Sex		CHAR(1),
		Salary	INT	NOT NULL,
		Super_ssn	CHAR(9),
		Dno	INT NOT NULL,
		
		PRIMARY KEY (Ssn)

		);

CREATE TABLE Empresa.Department(
		Dname	VARCHAR(20)	NOT NULL,
		Dnumber	INT	NOT NULL,
		Msr_ssn	CHAR(9), 
		Mgr_start_date	DATE,

		PRIMARY KEY (Dnumber)

		);


CREATE TABLE Empresa.Dept_Locations (
		Dnumber INT NOT NULL,
		Dlocation VARCHAR(20) NOT NULL,

		PRIMARY KEY (Dnumber,Dlocation)

	);

CREATE TABLE Empresa.Project (
		Pname VARCHAR(20)	NOT NULL,
		Pnumber	CHAR(9)	NOT NULL,
		Plocation	VARCHAR(20)	NOT NULL,
		Dnum	INT	NOT NULL,

		PRIMARY KEY(Pnumber)

	);

CREATE TABLE Empresa.Works_on (
		Essn CHAR(9) NOT NULL,
		Pno	CHAR(9) NOT NULL,
		[Hours] INT	NOT NULL,
		
		PRIMARY KEY (Essn)

		);

CREATE TABLE [Empresa.Dependent] (
		Essn CHAR(9) NOT NULL,
		Dependent_name	VARCHAR(20) NOT NULL,
		Sex	CHAR(1),
		Bdate	DATE,
		Relationship	VARCHAR(10),

		PRIMARY KEY(Essn)

		);



ALTER TABLE Empresa.Employee ADD CONSTRAINT Employee_Sssn FOREIGN KEY (Super_ssn) REFERENCES Empresa.Employee(Ssn);
ALTER TABLE Empresa.Employee ADD CONSTRAINT	Employee_Dno FOREIGN KEY (Dno) REFERENCES Empresa.Department(Dnumber);
ALTER TABLE Empresa.Dept_Locations ADD CONSTRAINT Department_Num FOREIGN KEY (Dnumber) REFERENCES Empresa.Department(Dnumber);
ALTER TABLE Empresa.Project ADD CONSTRAINT Project_Department FOREIGN KEY (Dnum) REFERENCES Empresa.Department(Dnumber);
ALTER TABLE Empresa.Works_on ADD CONSTRAINT Work_Pno FOREIGN KEY (Pno) REFERENCES Empresa.Project(Pnumber);
ALTER TABLE Empresa.Works_on ADD CONSTRAINT Work_Essn FOREIGN KEY (Essn) REFERENCES Empresa.Employee(Ssn);
ALTER TABLE [Empresa.Dependent] ADD CONSTRAINT Dependent_Essn FOREIGN KEY (Essn) REFERENCES Empresa.Employee(Ssn);








		


