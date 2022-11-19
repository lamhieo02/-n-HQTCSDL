----------------------------------TẠO DATABASE----------------------------------

create database LanguageCenter
go
use LanguageCenter
go

-- Courses
create table Courses(
	ID int IDENTITY(1,1) primary key,
	Name nvarchar(40) not null,
	Target float not null,
	No_Lessons int not null check (No_Lessons >= 0),
	Price int not null check(Price >= 0),
);
go


create table Roles(
	ID int IDENTITY(1,1) primary key,
	Name nvarchar(50) not null,
);
go


-- Accounts
create table Accounts (
	Username varchar(100) primary key,
	Password varchar(100)  not null,
	RoleID int not null,
	foreign key (RoleID) references Roles(ID) , 
);
go


-- Student 
create table Students(
	Username varchar(100) primary key,
	Date_Birth date not null,
	Address nvarchar(100) not null,
	Name nvarchar(50) not null,
	Email varchar(50) unique not null,
	Phone varchar(11) unique not null,
	check(10 = len(Phone) or len(Phone) = 11),
	foreign key(Username) references Accounts(Username)  on update cascade ,
);
go 

-- Teacher
create table Teachers(
	Username varchar(100) primary key,
	Date_Birth date not null,
	Address nvarchar(100) not null,
	Name nvarchar(50) not null,
	Email varchar(50) unique not null,
	Phone varchar(11) unique not null,
	check(10 = len(Phone) or len(Phone) = 11),
	foreign key(Username) references Accounts(Username) on update cascade,
);
go

-- Staff 
create table Staff(
	Username varchar(100) primary key,
	Date_Birth date not null,
	Address nvarchar(100) not null,
	Name nvarchar(50) not null,
	Email varchar(50) unique not null,
	Phone varchar(11) unique not null,
	Position nvarchar(40) not null,
	check(10 = len(Phone) or len(Phone) = 11),
	foreign key(Username) references Accounts(Username) on update cascade ,
);
go

-- Classes
create table Classes(
	ID int IDENTITY(1,1) primary key,
	Name nvarchar(100) not null,
	Start_Date date not null,
	End_Date date not null,
	Username varchar(100) not null,
	Course_ID int not null,
	WeekDays varchar(10) not null,
	Start_Time time not null,
	End_Time time not null,
	ClassRoom varchar(20) not null,
	No_Students int not null,
	foreign key(Username) references Teachers(Username)  on update cascade on delete cascade,
	foreign key(Course_ID) references Courses(ID) ,
);
go

-- Class_student
create table Class_Students(
	Class_ID int,
	Username varchar(100),
	primary key (Class_ID, Username),
	foreign key(Class_ID) references Classes(ID) on delete cascade,
	foreign key(Username) references Students(Username)  on update cascade ,
);
go

-- Payment_method
create table Payment_Methods(
	ID int IDENTITY(1,1) primary key,
	Name nvarchar(100) not null
);
go

-- Payment
create table Payments(
	ID int IDENTITY(1,1) primary key,
	Payment_Date date not null,
	Amount int not null check(Amount >= 0),
	Payment_Method_ID int not null,
	Status bit not null,
	Username varchar(100) not null,
	foreign key(Payment_Method_ID) references Payment_Methods(ID),
	foreign key(Username) references Students(Username) on update cascade ,
);
go

----------------------------------CONSTRAINTS----------------------------------

-- ràng buộc vị trí cố định: Admin, HR, Marketing, Trainer, Sales, Receptionist

alter table Staff add constraint CheckPosition check (Position like 'Admin' or Position like 'HR' or Position like 'Marketing' or
Position like 'Trainer' or Position like 'Sales' or Position like 'Receptionist');

-- ràng buộc check password phải có chữ hoa, chữ thường, số, một vài loại kí tự đặc biệt và hơn 7 ký tự
alter table Accounts add constraint CheckPassword_Accounts check (Password like '%[0-9]%' 
and Password like '%[A-Z]%' collate Latin1_General_BIN2
and Password like '%[!@#$%^&*()-_+=.,;:~]%' and len(Password)>6);

-- ràng buộc check email đúng format và không chứa một vài ký tự đặc biệt
alter table Students add constraint checkEmailStudent check (Email like '%_@__%.__%'and Email not like '% %'
and PATINDEX('%[^a-z,0-9,@,.,]%', Email) = 0);

alter table Staff add constraint checkEmailStaff check (Email like '%_@__%.__%'and Email not like '% %'
and PATINDEX('%[^a-z,0-9,@,.,]%', Email) = 0);

alter table Teachers add constraint checkEmailTeacher check (Email like '%_@__%.__%'and Email not like '% %'
and PATINDEX('%[^a-z,0-9,@,.,]%', Email) = 0);

--ràng buộc check sđt chỉ chứa số
alter table Students add constraint checkPhoneStudent check (PATINDEX('%[^0-9]%', Phone) = 0);

alter table Staff add constraint checkPhoneStaff check (PATINDEX('%[^0-9]%', Phone) = 0);

alter table Teachers add constraint checkPhoneTeacher check (PATINDEX('%[^0-9]%', Phone) = 0);

-- check lịch học
alter table Classes add constraint checkDay check (PATINDEX('%[^2-7, -]%', Weekdays) = 0);

-- check thời gian của lớp học
alter table Classes add constraint checkDayStartEnd check (Start_Date < End_Date);

alter table Classes add constraint checkTimeStartEnd check (Start_Time < End_Time);
go

----------------------------------TRIGGERS----------------------------------
--trigger kiểm tra thang điểm theo khóa học

create trigger checkTargetCourse on Courses
after insert as
declare @name nvarchar(40), @target float
select @name = ne.Name, @target = ne.Target
from inserted ne
begin
if @target < 0
rollback
else
begin
if @name like '%IELTS%'
if @target > 9
rollback
if @name like '%TOEIC%'
begin
if @name like '%LR%'
if @target > 990
rollback
if @name like '%SW%'
if @target >400
rollback
end
end
end
go

----------------------------------NHẬP DỮ LIỆU----------------------------------
insert into Courses values ('TOEIC SW',400,29,5000000);
insert into Courses values ('TOEIC LR',900,66,7000000);
insert into Courses values ('IELTS',7.0,50,10000000);

insert into Roles values ('Staff');
insert into Roles values ('Teacher');
insert into Roles values ('Student');

insert into Accounts values ('admin01', 'Mtl@091202', 1);
insert into Accounts values ('admin02', 'Mtl@091202', 1);
insert into Accounts values ('staff01', 'Mtl@091202', 1);
insert into Accounts values ('staff02', 'Mtl@091202', 1);
insert into Accounts values ('teacher01', 'Mtl@091202', 2);
insert into Accounts values ('teacher02', 'Mtl@091202', 2);
insert into Accounts values ('teacher03', 'Mtl@091202', 2);
insert into Accounts values ('student01', 'Mtl@091202', 3);
insert into Accounts values ('student02', 'Mtl@091202', 3);
insert into Accounts values ('student03', 'Mtl@091202', 3);
insert into Accounts values ('student04', 'Mtl@091202', 3);
insert into Accounts values ('student05', 'Mtl@091202', 3);
insert into Accounts values ('student06', 'Mtl@091202', 3);

insert into Students values ('student01', '12-09-2002', 'Hoang Dieu 2', 'Le Minh Tuong', 'mtl1@gmail.com', '1234567890');
insert into Students values ('student02', '07-07-2002', 'So 1 Vo Van Ngan', 'Minh Tuong Le', 'mtl2@gmail.com', '1234567891');
insert into Students values ('student03', '12-09-2002', 'Hoang Dieu 2', 'Le Minh Tuong', 'mtl3@gmail.com', '1234567892');
insert into Students values ('student04', '07-07-2002', 'So 1 Vo Van Ngan', 'Minh Tuong Le', 'mtl4@gmail.com', '1234567893');
insert into Students values ('student05', '12-09-2002', 'Hoang Dieu 2', 'Le Minh Tuong', 'mtl5@gmail.com', '1234567894');
insert into Students values ('student06', '07-07-2002', 'So 1 Vo Van Ngan', 'Minh Tuong Le', 'mtl6@gmail.com', '1234567895');

insert into Teachers values ('teacher01', '12-09-1990', 'Hoang Dieu 2', 'John Dept', 'johndt@gmail.com', '0342925953');
insert into Teachers values ('teacher02', '07-07-1997', 'So 1 Vo Van Ngan', 'Marco Simp', 'marcosp@gmail.com', '0827107089');
insert into Teachers values ('teacher03', '08-05-1994', 'Hoang Dieu 2', 'Victor Hugo', 'victorhg@gmail.com', '0941194574');

insert into Staff values ('admin01', '12-01-1995', 'Hoang Dieu 2', 'Cexo', 'vimgnome@gmail.com', '0123456789', 'Admin');
insert into Staff values ('admin02', '07-01-2004', 'So 1 Vo Van Ngan', 'Rambo', 'hhccabc@gmail.com', '0987654321', 'Admin');
insert into Staff values ('staff01', '12-09-1975', 'Hoang Dieu 2', 'Yone', 'yone@gmail.com', '0909090090', 'HR');
insert into Staff values ('staff02', '07-07-2004', 'So 1 Vo Van Ngan', 'Yasuo', 'yasuo@gmail.com', '0909123456', 'Receptionist');

insert into Classes values ('Lop 01', '02-05-2022', '11-11-2022', 'teacher01', 1, '2-4-6', '17:0:0', '20:0:0', 'P01',0);
insert into Classes values ('Lop 02', '02-05-2022', '01-11-2023', 'teacher01', 2, '2-4-6', '13:0:0', '16:0:0', 'P02',0);
insert into Classes values ('Lop 03', '07-05-2022', '12-11-2022', 'teacher02', 3, '3-5-7', '17:0:0', '20:0:0', 'P03',0);

insert into Class_Students values (1, 'student01');
insert into Class_Students values (1, 'student02');
insert into Class_Students values (1, 'student03');
insert into Class_Students values (2, 'student01');
insert into Class_Students values (2, 'student04');
insert into Class_Students values (3, 'student05');

insert into Payment_Methods values ('Mobile Banking');
insert into Payment_Methods values ('Cast');
insert into Payment_Methods values ('Visa');

insert into Payments values ('02-03-2022',5000000,2,1,'student01');
insert into Payments values ('02-05-2022',5000000,1,1,'student02');
insert into Payments values ('02-01-2022',7000000,1,1,'student01');
insert into Payments values ('07-03-2022',10000000,3,1,'student05');

----------------------------------SELECT DỮ LIỆU----------------------------------
select * from Courses;
select * from Roles;
select * from Accounts;
select Username, Name, convert (varchar(100),Date_Birth, 103) as DateOfBirth, Address,  Email, Phone from Students;
select Username, Name, convert (varchar(100),Date_Birth, 103) as DateOfBirth, Address,  Email, Phone from Teachers;
select Username, Name, convert (varchar(100),Date_Birth, 103) as DateOfBirth, Address,  Email, Phone from Staff;
select ID, Name, convert (varchar(100),Start_Date, 103) as Start_Date, convert (varchar(100),End_Date, 103) as End_Date, Username,
Course_ID, WeekDays, convert (varchar(100),Start_Time, 108) as Start_Time, convert (varchar(100),End_Time, 108) as End_Time, ClassRoom, No_Students from Classes;
select * from Class_Students;
select * from Payment_Methods;
select ID, Username, convert (varchar(100),Payment_Date, 103) as Payment_Date, Amount, Payment_Method_ID, Status from Payments;
go

-------------------------IDEAS--------------------------
--KHÔNG CÙNG CASCADE ACCOUNTS & STUDENT VÌ DÙNG SẼ BỊ XUNG ĐỘT CIRCLE VỚI CASCADE TEACHER Ở BẢNG CLASS_STUDENT

----------------------------------PROC & FUNCTION CHƯA DÙNG----------------------------------
--proc + transaction thực hiện xóa tuần tự 1 CLASS 
create procedure deleteCLASS_sequently @id int
as
begin try
begin transaction
delete from Class_Students where Class_ID=@id
delete from Classes where ID=@id
commit transaction
end try
begin catch
DECLARE @CustomMessage VARCHAR(1000),
    @CustomError INT,
    @CustomState INT;
SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
SET @CustomError = 54321;
SET @CustomState = 1;
THROW @CustomError, @CustomMessage, @CustomState;
end catch
go

--proc + transaction thực hiện xóa tuần tự 1 COURSE 
create procedure deleteCOURSE_sequently @id int
as
begin try
begin transaction
execute deleteCLASS_sequently @id;
delete from Courses where ID = @id;
commit transaction
end try
begin catch
DECLARE @CustomMessage VARCHAR(1000),
    @CustomError INT,
    @CustomState INT;
SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
SET @CustomError = 54321;
SET @CustomState = 1;
THROW @CustomError, @CustomMessage, @CustomState;
end catch
go

----------------------------------STUDENT MANAGE FORM----------------------------------
--proc + transaction thực hiện xóa tuần tự 1 STUDENT
create procedure deleteSTUDENT_sequently @username nvarchar(50)
as
begin try
begin transaction
delete from Class_Students where Username = @username;
delete from Payments where Username = @username;
delete from Students where Username = @username;
commit transaction
end try
begin catch
DECLARE @CustomMessage VARCHAR(1000),
    @CustomError INT,
    @CustomState INT;
SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
SET @CustomError = 54321;
SET @CustomState = 1;
THROW @CustomError, @CustomMessage, @CustomState;
end catch
go

--proc + transaction thực hiện xóa tuần tự 1 ACCOUNT của STUDENT
create procedure deleteACCOUNT_STUDENT_sequently @username nvarchar(50)
as
if exists (select Accounts.Username from Accounts where Username = @username)
begin
begin transaction
execute deleteSTUDENT_sequently @username;
delete from Accounts where Username = @username;
commit transaction
end
else
begin
DECLARE @CustomMessage VARCHAR(1000),
    @CustomError INT,
    @CustomState INT;
SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
SET @CustomError = 54321;
SET @CustomState = 1;
THROW @CustomError, @CustomMessage, @CustomState;
end 
go

create view Student_Info as
select distinct Students.Username, Students.Name as StudentName, convert (varchar(100),Students.Date_Birth, 103) as DateOfBirth, 
Students.Address,  Students.Email, Students.Phone,
Courses.Name as CourseName, Classes.Name as ClassName, Teachers.Name as TeacherName
from Students inner join Class_Students on Students.Username=Class_Students.Username
inner join Classes on Class_Students.Class_ID=Classes.ID inner join Teachers on Classes.Username=Teachers.Username
inner join Courses on Course_ID = Courses.ID;
go


create procedure GetListStudent as
select Username, Name as StudentName, convert (varchar(100),Date_Birth, 103) as DateOfBirth, Address,  Email, Phone from Students;
go

create procedure GetStudentByStudentName @name nvarchar(50)
as
begin
select distinct Username, Name as StudentName, convert (varchar(100),Date_Birth, 103) as DateOfBirth, Address,  Email, Phone from Students
where Name= @name
end
go

create procedure GetStudentByTeacherName @name nvarchar(50)
as
begin
select distinct Username, StudentName, DateOfBirth, Address,  Email, Phone from Student_Info
where Student_Info.TeacherName = @name
end
go

create procedure GetStudentByCourseName @name nvarchar(50)
as
begin
select distinct Username, StudentName, DateOfBirth, Address,  Email, Phone from Student_Info
where Student_Info.CourseName = @name
end
go

create procedure GetStudentByClassName @name nvarchar(50)
as
begin
select distinct Username, StudentName, DateOfBirth, Address,  Email, Phone from Student_Info
where Student_Info.ClassName = @name
end
go

create procedure AddStudent @username varchar(100), @name nvarchar(50), @dateofbirth date, @address nvarchar(100), @email varchar(50), @phone varchar(11)
as
begin try
begin transaction
insert into Accounts values (@username, 'Abc@123', 3);
insert into Students values (@username, @dateofbirth, @address, @name, @email, @phone);
commit transaction
end try
begin catch
DECLARE @CustomMessage VARCHAR(1000),
    @CustomError INT,
    @CustomState INT;
SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
SET @CustomError = 54321;
SET @CustomState = 1;
THROW @CustomError, @CustomMessage, @CustomState;
end catch
go

create procedure UpdateStudent @username varchar(100), @name nvarchar(50), @dateofbirth date, @address nvarchar(100), @email varchar(50), @phone varchar(11)
as
begin
if exists (select Accounts.Username from Accounts where Username = @username)
begin
update Students
set Name=@name, Date_Birth=@dateofbirth, Address=@address, Email = @email, Phone=@phone where Username=@username
end
else
begin
DECLARE @CustomMessage VARCHAR(1000),
    @CustomError INT,
    @CustomState INT;
SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
SET @CustomError = 54321;
SET @CustomState = 1;
THROW @CustomError, @CustomMessage, @CustomState;
end
end
go

create procedure DeleteStudent @username nvarchar(100)
as
begin
if exists (select Accounts.Username from Accounts where Username = @username)
exec deleteACCOUNT_STUDENT_sequently @username;
else
begin
DECLARE @CustomMessage VARCHAR(1000),
    @CustomError INT,
    @CustomState INT;
SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
SET @CustomError = 54321;
SET @CustomState = 1;
THROW @CustomError, @CustomMessage, @CustomState;
end
end
go

----------------------------------TEACHER MANAGE FORM----------------------------------
--proc + transaction thực hiện xóa tuần tự 1 ACCOUNT của TEACHER
create procedure deleteACCOUNT_TEACHER_sequently @username nvarchar(50)
as
if exists (select Accounts.Username from Accounts where Username = @username)
begin
begin transaction
delete from Teachers where Username=@username;
delete from Accounts where Username = @username;
commit transaction
end
else
begin
DECLARE @CustomMessage VARCHAR(1000),
    @CustomError INT,
    @CustomState INT;
SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
SET @CustomError = 54321;
SET @CustomState = 1;
THROW @CustomError, @CustomMessage, @CustomState;
end
go

create procedure GetTeacherByTeacherName @name nvarchar(50)
as
begin
select distinct * from Teacher_Info where TeacherName= @name
end
go

create procedure GetTeacherByCourseName @name nvarchar(50)
as
begin
select distinct Username, TeacherName, DateOfBirth, Address, Email, Phone, Salary from TeacherAndSalary where CourseName= @name
end
go

create procedure GetTeacherByClassName @name nvarchar(50)
as
begin
select distinct Username, TeacherName, DateOfBirth, Address, Email, Phone, Salary from TeacherAndSalary where ClassName= @name
end
go

create procedure AddTeacher @username varchar(100), @name nvarchar(50), @dateofbirth date, @address nvarchar(100), @email varchar(50), @phone varchar(11)
as
begin try
begin transaction
insert into Accounts values (@username, 'Abc@123', 2);
insert into Teachers values (@username, @dateofbirth, @address, @name, @email, @phone);
commit transaction
end try
begin catch
DECLARE @CustomMessage VARCHAR(1000),
    @CustomError INT,
    @CustomState INT;
SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
SET @CustomError = 54321;
SET @CustomState = 1;
THROW @CustomError, @CustomMessage, @CustomState;
end catch
go

create procedure UpdateTeacher @username varchar(100), @name nvarchar(50), @dateofbirth date, @address nvarchar(100), @email varchar(50), @phone varchar(11)
as
begin
if exists (select Accounts.Username from Accounts where Username = @username)
begin
update Teachers
set Name=@name, Date_Birth=@dateofbirth, Address=@address, Email = @email, Phone=@phone where Username=@username
end
else
begin
DECLARE @CustomMessage VARCHAR(1000),
    @CustomError INT,
    @CustomState INT;
SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
SET @CustomError = 54321;
SET @CustomState = 1;
THROW @CustomError, @CustomMessage, @CustomState;
end
end
go

create function TinhLuong (@noclass as int)
returns int
as begin
declare @result int = 5000000*@noclass
if @noclass is null
set @result =0
return @result
end;
go

create view TeacherAndSalary as
select Teachers.Username,  Teachers.Name as TeacherName,convert (varchar(100),Date_Birth, 103) as DateOfBirth, Address, Email, 
Phone, ISNULL(LUONG,0) as Salary, Classes.Name as ClassName, Courses.Name as CourseName from Teachers left join (select *, 
dbo.TinhLuong(A.HSL) as LUONG from (select Username, count (*) as HSL from Classes group by Username)A)B on 
B.Username= Teachers.Username inner join Classes on B.Username = Classes.Username inner join Courses 
on Classes.Course_ID=Courses.ID;
go

create view Teacher_Info as
select Teachers.Username,  Teachers.Name as TeacherName,convert (varchar(100),Date_Birth, 103) as DateOfBirth, Address, Email, 
Phone, ISNULL(LUONG,0) as Salary from Teachers left join (select *, 
dbo.TinhLuong(A.HSL) as LUONG from (select Username, count (*) as HSL from Classes group by Username)A)B on 
B.Username= Teachers.Username
go

create procedure DeleteTeacher @username nvarchar(100)
as
begin
if exists (select Accounts.Username from Accounts where Username = @username)
exec deleteACCOUNT_TEACHER_sequently @username;
else
begin
DECLARE @CustomMessage VARCHAR(1000),
    @CustomError INT,
    @CustomState INT;
SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
SET @CustomError = 54321;
SET @CustomState = 1;
THROW @CustomError, @CustomMessage, @CustomState;
end
end
go

----------------------------------STAFF MANAGE FORM----------------------------------
--proc + transaction thực hiện xóa tuần tự 1 ACCOUNT của STAFF
create procedure deleteACCOUNT_STAFF_sequently @username nvarchar(50)
as
begin try
begin transaction
delete from Staff where Username=@username;
delete from Accounts where Username = @username;
commit transaction
end try
begin catch
DECLARE @CustomMessage VARCHAR(1000),
    @CustomError INT,
    @CustomState INT;
SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
SET @CustomError = 54321;
SET @CustomState = 1;
THROW @CustomError, @CustomMessage, @CustomState;
end catch
go

create function Tinh_Luong (@position as nvarchar(40))
returns int
as begin
declare @result int
if @position = 'Admin'
set @result = 12000000
if @position = 'HR'
set @result = 10000000
if @position = 'Marketing'
set @result = 9000000
if @position = 'Sales' or @position = 'Trainer'
set @result = 7000000
if @position = 'Receptionist'
set @result = 4000000
return @result
end;
go

create view Staff_Info as
select Username, Name as StaffName, convert (varchar(100),Date_Birth, 103) as DateOfBirth, Address, Email, Phone, Position, dbo.Tinh_Luong(Position) as Salary
from Staff
go

create procedure GetStaffByStaffName @name nvarchar(50)
as
select * from Staff_Info where StaffName =@name
go

create procedure GetStaffByPosition @name nvarchar(50)
as
select * from Staff_Info where Position =@name
go

create procedure AddStaff @username varchar(100), @name nvarchar(50), @dateofbirth date, @address nvarchar(100), @email varchar(50), @phone varchar(11)
, @position nvarchar(40)
as
begin try
begin transaction
insert into Accounts values (@username, 'Abc@123', 1);
insert into Staff values (@username, @dateofbirth, @address, @name, @email, @phone, @position);
commit transaction
end try
begin catch
DECLARE @CustomMessage VARCHAR(1000),
    @CustomError INT,
    @CustomState INT;
SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
SET @CustomError = 54321;
SET @CustomState = 1;
THROW @CustomError, @CustomMessage, @CustomState;
end catch
go

create procedure UpdateStaff @username varchar(100), @name nvarchar(50), @dateofbirth date, @address nvarchar(100), @email varchar(50), @phone varchar(11),
@position nvarchar(40) as
begin
if exists (select Accounts.Username from Accounts where Username = @username)
begin
update Staff
set Name=@name, Date_Birth=@dateofbirth, Address=@address, Email = @email, Phone=@phone, Position=@position where Username=@username
end
else
begin
DECLARE @CustomMessage VARCHAR(1000),
    @CustomError INT,
    @CustomState INT;
SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
SET @CustomError = 54321;
SET @CustomState = 1;
THROW @CustomError, @CustomMessage, @CustomState;
end
end
go

create procedure DeleteStaff @username nvarchar(100)
as
begin
if exists (select Accounts.Username from Accounts where Username = @username)
exec deleteACCOUNT_STAFF_sequently @username;
else
begin
DECLARE @CustomMessage VARCHAR(1000),
    @CustomError INT,
    @CustomState INT;
SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
SET @CustomError = 54321;
SET @CustomState = 1;
THROW @CustomError, @CustomMessage, @CustomState;
end
end
go

----------------------------------PAYMENTS MANAGE FORM----------------------------------
-- *** FUNCTIONS ***

go
-- lấy tên payment method
create function PaymentMethodName_byId (@id int)
returns nvarchar(20)
as begin
declare @name nvarchar(20) 
set @name = (select Payment_Methods.Name from Payment_Methods where Payment_Methods.ID = 1)
return @name
end

--lấy trạng thái thanh toán theo status bit
go
create function TrangThaiThanhToan (@status bit)
returns nvarchar(30)
as begin 
declare @status_name nvarchar(30)
set @status_name = ''
if @status = 1
	begin 
	set @status_name = N'Đã thanh toán'
	end
if @status = 0
	begin 
	set @status_name = N'Chưa thanh toán'
	end
return @status_name
end
go
--select [dbo].TrangThaiThanhToan(1)

--Quản lí thanh toán chung tất cả Students
create view PaymentsView
as
select ID ,Students.Username,Students.Name as 'Họ tên', Students.Email, Students.Phone as 'Số điện thoại', 
Payments.Payment_Date 'Ngày thanh toán', Amount as 'Số lượng' ,[dbo].PaymentMethodName_byId(Payments.Payment_Method_ID) as 'Phương thức thanh toán',  [dbo].TrangThaiThanhToan(Payments.Status) as 'Trạng thái thanh toán'
from Payments inner join Students on Students.Username = Payments.Username

go
-- procedure lấy thông tin Payments
create procedure getPayments
as begin 
select * from PaymentsView
end

go
exec getPayments

-- procedure insert Payment
go
create procedure InsertPayment @payment_date date, @amount int, @method_id int, @status int, @username nvarchar(30)
as begin
insert into Payments values(@payment_date, @amount, @method_id	, @status, @username)
end

select * from Payments

go
-- procedure update Payment
create procedure updatePayment @id int ,@payment_date date, @amount int, @method_id int, @status int, @username nvarchar(30)
as begin
update Payments
set Payment_Date = @payment_date, Amount = @amount, Payment_Method_ID = @method_id, Status = @status, Username = @username
where ID = @id
end

go
-- procedure delete payment
create procedure deletePayment @id int
as begin
delete from Payments where Payments.ID = @id
end
