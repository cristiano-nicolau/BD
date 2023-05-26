# BD: Guião 9


## ​9.1
 
### *a)*

```
... Write here your answer ...
CREATE PROCEDURE Empresa.deleteEmployee @Emp_Code char(9)
AS
	BEGIN
		DELETE FROM Empresa.Works_on WHERE Essn = @Emp_Code
		DELETE FROM [Empresa.Dependent] WHERE  Essn = @Emp_Code

		UPDATE Empresa.Department 
			SET Empresa.Department.Msr_ssn  = null
			WHERE Msr_ssn = @Emp_Code

		UPDATE Empresa.Employee 
			SET Empresa.Employee.Super_ssn  = null
			WHERE Super_ssn = @Emp_Code
	
		DELETE FROM Empresa.Employee WHERE Ssn = @Emp_Code

	END


EXEC Empresa.deleteEmployee '183623612
```

### *b)* 

```
... Write here your answer ...
CREATE PROCEDURE Empresa.getManagers  (@Oldest_ssn char(9) OUTPUT, @Oldest_years int OUTPUT)
AS
	BEGIN
		SELECT * 
		FROM (Empresa.Employee LEFT OUTER JOIN Empresa.Department ON Ssn = Msr_ssn)
		WHERE Msr_ssn IS NOT NULL
		ORDER BY Mgr_start_date;
		
		SELECT @Oldest_years=min(DATEDIFF(year,Empresa.Department.Mgr_start_date,getDate())), @Oldest_ssn = Empresa.Department.Msr_ssn
		FROM Empresa.Department
		WHERE Msr_ssn IS NOT NULL
		GROUP BY Empresa.Department.Mgr_start_date, Empresa.Department.Msr_ssn

	END

EXEC Empresa.getManagers @Oldest_ssn = @Oldest_ssn OUTPUT,
						@Oldest_years = @Oldest_years OUTPUT;
PRINT @Oldest_ssn
PRINT @Oldest_years
```

### *c)* 

```
... Write here your answer ...
CREATE TRIGGER Empresa.preventManagerOverlap ON Empresa.Department
AFTER INSERT, UPDATE
	AS

		IF EXISTS(SELECT Msr_ssn
				  FROM Empresa.Department
				  WHERE Msr_ssn IS NOT NULL)
			BEGIN 
				RAISERROR ('Employee is already the manager of a department',16,1); 
				ROLLBACK TRAN;                                               
			END 
	GO
```

### *d)* 

```
... Write here your answer ...
```

### *e)* 

```
... Write here your answer ...
CREATE FUNCTION getEmployeeP (@Emp_ssn char(9)) RETURNS TABLE
AS
	RETURN (SELECT Pname, Plocation
			FROM Empresa.Project LEFT OUTER JOIN 
					Empresa.Employee LEFT OUTER JOIN Empresa.Works_on ON Ssn = Essn
				 ON Pnumber = Pno
			WHERE @Emp_ssn = Ssn)
GO

SELECT *
FROM getEmployeeP('1234566');
go
```

### *f)* 

```
... Write here your answer ...
create function Empresa.EmpBestSalaries (@dno int) returns Table
as
	return (select Ssn, Fname, Minit, Salary, Dno
			from Empresa.Employee
			where Dno=@dno and salary > (select avg(Salary)
							from Empresa.Employee
							where Dno=@dno
							)
			)
go

select * from Empresa.EmpBestSalaries (2)
go
```

### *g)* 

```
... Write here your answer ...
create function Empresa.employeeDeptHighAverage (@dnumber int) returns @ProjBudget Table
	(pName varchar(30), pnumber int not null, plocation varchar(15), dnum int, budget decimal, totalbudget decimal)
as
	begin
		declare @pName as varchar(30), @pnumber as int, @prevPnumber as int, @plocation as varchar(15),
				@dnum as int, @budget as decimal, @totalbudget as decimal, @hours as decimal, @salary as decimal;
		
		declare c cursor fast_forward
		for select Pname, Pnumber, Plocation, Dnum, [Hours], Salary
		from (Empresa.Project join Works_on on Pnumber=Pno) join Empresa.Employee on Essn=Ssn
		where Dnum=@dnumber;

		open c;

		fetch c into @pName, @pnumber, @plocation, @dnum, @hours, @salary;

		select @prevPnumber = @pnumber, @budget = 0, @totalbudget = 0;

		while @@fetch_status = 0
			begin
				if @prevPnumber <> @pnumber
					begin
						insert @ProjBudget values (@pName,@prevPnumber,@plocation,@dnum,@budget,@totalbudget);
						select @prevPnumber = @pnumber, @budget = 0;
					end

					set @budget += @salary*@hours/40;
					set @totalbudget += @salary*@hours/40;

					fetch c into @pName, @pnumber, @plocation, @dnum, @hours, @salary;
			end

		close c;
		deallocate c;

		return;
	end
go

select * from Empresa.employeeDeptHighAverage (3);
go
```

### *h)* 

```
... Write here your answer ...
create trigger Empresa.delete_Department_Instead on Empresa.[Department]
instead of delete
as
begin
	-- begin transaction
	begin transaction
		
		-- get department number
		declare @dNumber int
		select @dNumber=Dnumber from deleted;

		--check if exists a table for the deleted departments
        --if not, create it
		if (not exists( select * from information_schema.tables where table_schema='Empresa' and table_name='Department_deleted'))
		begin
			create table Empresa.Department_deleted 
            (
                Dname			varchar(30) not null,
                Dnumber			int			not null,
                Mgr_ssn			char(9)			null,
                Mgr_start_date	date			null,
                
				primary key(Dnumber)
            )
			alter table Empresa.Department_deleted add constraint deptDeletedEmp foreign key (Mgr_ssn) references Empresa.Employee (Ssn);
		end

		begin try
			-- insert into the deleted department table
			insert into Empresa.Department_deleted 
			select * from deleted

			-- delete the department
			delete from Empresa.Department where Dnumber=@dNumber;
		end try

        begin catch
            raiserror ('Error deleting department', 16, 1)   
        end catch

	commit transaction
end
go
```

### *i)* 

```
... Write here your answer ...
Stored procedures:

São rotinas de programação armazenadas em base de dados, que podem ser chamadas por outros programas ou scripts.
Podem ser usadas para executar operações complexas ou consultas que envolvem várias tabelas ou relacionamentos.
Oferecem melhor desempenho e segurança do que a execução de consultas SQL diretas na base de dados.
Permitem a reutilização de código em vários aplicativos ou partes de um aplicativo.
São frequentemente usadas em aplicativos que exigem processamento em grande quantidade, como relatórios ou rotinas de backup.


UDFs:

São funções definidas pelo utilizador, que podem ser usadas em consultas SQL.
Permitem a criação de expressões mais complexas em consultas SQL, sem a necessidade de escrever código personalizado.
São úteis para cálculos repetitivos ou para a combinação de dados de várias tabelas.
Podem retornar valores escalares ou tabelas temporárias.
Permitem a criação de cálculos personalizados ou funções de agregação.



Em geral, as stored procedures são mais adequadas para operações complexas que exigem processamento em lote ou acesso granular aos dados, enquanto as UDFs são mais adequadas para consultas SQL que exigem cálculos personalizados ou expressões mais complexas.
```
