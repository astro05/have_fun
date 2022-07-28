

create table Gender(
id int not null primary key
)

insert into employee(id,name,email,genderid) values (2,'joy','joy@mail.com',2)

alter table Gender
add genderadd nvarchar(50)

alter table employee
add mobile numeric(12)

drop table Gender

create table Gender(
id int not null primary key
)

alter table Gender
add gname nvarchar(50)


alter table employee add constraint cons_employee_fk
foreign key (genderid) references Gender(id)

alter table employee
drop constraint cons_employee_fk

alter table employee
add constraint employee_name
default 'unnamed' for name 

insert into employee(id,email,genderid) values (6,'m@mai.com',1)

alter table employee
add constraint employee_mobile
check (mobile>0 and mobile<12)

insert into employee(id,email,genderid,mobile) values (6,'m@mai.com',1,5)


create table employee_type(
id int not null primary key,
employee_type nvarchar(50) not null 
)

alter table employee_type
add constraint employeetype
default 'general' for employee_type

insert into employee_type (id) values (50)

insert into employee_type(id,employee_type) values (2,'worker')
update employee_type set employee_type = 'manager'
update employee_type set employee_type='boss' where id=1
delete from employee_type where id=50

begin
insert into employee_type(id,employee_type) values (3,'worker');
insert into employee_type(id,employee_type) values (4,'super')
insert into employee_type(id,employee_type) values (5,'writer')
end;

update employee_type set employee_type='post' where id in(1,2)
delete employee_type where id in(1,2)

select * from employee_type
select * from employee_type where employee_type='worker' 

alter table employee_type
add age int null
select * from employee_type
update employee_type set age =25 where id=3
update employee_type set age =21 where id =4

alter table employee_type
add constraint age 
check (age>2 and age<100)

insert employee_type(id,age) values(8,110)

alter table employee_type
drop constraint age

select * from employee_type

alter table employee_type
add constraint uni unique(age) 

select * from employee
insert into employee(id,name) values (8, 'abir')
select SCOPE_IDENTITY()
select @@IDENTITY
select IDENT_CURRENT('id')



select * from employee_type where age=15 and age< 25 or employee_type= 'general'
select * from employee_type where employee_type like 'w%'
select * from employee_type where id not in (1,2)
select * from employee where email like '%@%.com'
select* from employee where name like '[am]%'
 


select SUM(salary) from employee
select AVG(salary) from employee
select COUNT(salary) from employee where genderid=2
select MIN(salary) from employee
select MAX(salary) from employee


select UPPER(name) as uppercase from employee
select lower(name) as uppercase from employee
select SUBSTRING(name,2,2) as sortcity from employee
select LEN(name) from employee
select ROUND(slary,2) from employee
select GETDATE()
select CONVERT(varchar(10),GETDATE(),10) as usaStandaed 


select Gender,city,SUM(salary) as totalSalary, COUNT(id) as Totalemployee
from employee
group by Gender,city
having SUM(salary) > 5000


select ASCII('a')
select LTRIM(name) from employee
select RTRIM(name) from employee
select REVERSE(name) from employee
select LEFT(name,2) from employee
select RIGHT(name,2) from employee
select CHARINDEX('@',email,1) from employee




--self joint lab
select E1.empId, E2.Name as ManagerName
from EMPLOYEE E1 inner join EMPLOYEE E2
on (E1 managerID = E2 empId)




--online 4;
create database online4

CREATE TABLE EMPLOYEE
(
EmployeeId int IDENTITY(1,1) PRIMARY KEY,
Name varchar(50) NOT NULL,
Age int NOT NULL CHECK (Age >= 18),
Address varchar(200) NULL DEFAULT 'Dhaka',
Salary decimal(18,2) NULL,
HireYear int NOT NULL
)

INSERT INTO EMPLOYEE (Name, Age, Address, Salary,HireYear)
VALUES ('Rahim', 32, 'Gulshan',2000.00,2000),
('Karim', 25, 'Dhanmondi',1500.00,2000),
('Hashim', 23, 'Motijheel',2000.00,2000),
('Khan', 25, 'Tejgaon',6500.00,2000),
('Rahman', 27, 'Wari',8500.00,2005),
('Ali', 42, 'Kakrail',1000.00,2005),
('Mehedi', 22, 'Mohammadpur',4500.00,2005),
('Kashim', 24, 'Kakrail',10000.00,2008),
('Kazi', 22, 'Kakrail',1000.00,2008),
('Kazi', 22, 'Banani',1000.00,2010)

select * from EMPLOYEE where Name like 'k%'

select Salary,Address, AVG(Salary) as avgSalary
from Employee
Group by Address,Salary
Having AVG(Salary)<5000

select  SUBSTRING(Name,1,1) as charFrist,COUNT(EmployeeId) 
from EMPLOYEE
Group by SUBSTRING(Name,1,1)

-- ............................ --

--inner join
select name,email,employee_type,age
from employee
inner join employee_type on employee.id = employee_type.id

--left outer join
select name,email,employee_type,age
from employee_type
left join employee on employee.id = employee_type.id

--right join
select name,email,employee_type,age
from employee_type
right join employee on employee.id = employee_type.id

--full join
select name,email,employee_type,age
from employee_type
full join employee on employee.id = employee_type.id

--cross join
select name,email,employee_type,age
from employee_type
cross join employee

--advance or intillegent inner join
select name,email,employee_type
from employee
inner join employee_type
on employee.id=employee_type.id
where employee.id is null
or employee_type.id is null

--self join(inner,left,right,cross)
select E.name as Employee, M.name as Manager
from employee E
left join employee M
on E.Managerid = M.Employeeid 

--lab 6
Alter login sa with password='123456'
Alter login sa enable


Create Database ProjectDB;
Use ProjectDB;
CREATE TABLE Customer(
CustomerID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
FirstName varchar (50) NOT NULL,
LastName varchar (50) NOT NULL,
CustomerAddress varchar (50) NOT NULL,
City varchar (50) NOT NULL,
Country varchar (50) NOT NULL
);
INSERT INTO CUSTOMER
VALUES ('Amy', 'Johnson', '11000 Beecher', 'Joliet', 'USA'),
('Bill', 'Brown', '7312 Bettis Ave.', 'Pittsburg','USA'),
('Janna', 'Smith', '200 E. Elm Apt. #32', 'Sparks','USA'),
('Evette', 'LeBlanc', '207 Queens Quay West', 'Toronto','CA'),
('Drew', 'Brisco', '1690 Hollis Street', 'Ottawa','CA')

-- join many table 
select EMPLOYEE,DeptName,CityName
from EMPLOYEE E
inner join Dept D
on E.deptId = D.deptId
inner join City c
on D.CityId = C.CityId

--sub query
select * from EMPLOYEE
where Salary > 
(select salary from EMPLOYEE
where Name = 'khan')



Alter login sa with password = '1234'
Alter login sa enable


Create Database ProjectDB;
Use ProjectDB;
CREATE TABLE Customer(
CustomerID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
FirstName varchar (50) NOT NULL,
LastName varchar (50) NOT NULL,
CustomerAddress varchar (50) NOT NULL,
City varchar (50) NOT NULL,
Country varchar (50) NOT NULL
);
INSERT INTO CUSTOMER
VALUES ('Amy', 'Johnson', '11000 Beecher', 'Joliet', 'USA'),
('Bill', 'Brown', '7312 Bettis Ave.', 'Pittsburg','USA'),
('Janna', 'Smith', '200 E. Elm Apt. #32', 'Sparks','USA'),
('Evette', 'LeBlanc', '207 Queens Quay West', 'Toronto','CA'),
('Drew', 'Brisco', '1690 Hollis Street', 'Ottawa','CA')


