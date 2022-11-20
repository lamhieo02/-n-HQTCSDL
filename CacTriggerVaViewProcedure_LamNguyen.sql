
-- trigger khi insert Payments thì Amount += Amount cũ if Amount < tổng price của tất cả khóa học của nó học thì status vẫn là 0 else thì là 1
create trigger Status_Payment
on Payments for insert 
as 
begin
	declare @current_Amount int;
	declare @price int;
	declare @cid int;
	
	select @current_Amount = sum(dbo.Payments.Amount) from dbo.Payments, inserted where inserted.Username = Payments.Username
	
	select @price = sum(c.Price)
	from inserted, Class_Students cs inner join Classes cl on cs.Class_ID = cl.ID inner join Courses c on cl.Course_ID = c.ID
	where inserted.Username = cs.Username

	if @current_Amount >= @price
	begin
		update dbo.Payments set dbo.Payments.Status = 1 from inserted, dbo.Payments where dbo.Payments.ID = inserted.ID
	end

end
go
-- Trigger dùng để tăng tự động thuộc tính No_Students trong table Classes với số lượng học viên thuộc lớp nào 
create trigger IncreaseNoStudent
on dbo.Class_Students for insert 
as
begin
	declare @noStudents int;
	select @noStudents = dbo.Classes.No_Students from dbo.Classes, inserted where inserted.Class_ID = dbo.Classes.ID
	if @noStudents > 10
	begin 
		raiserror (N'Lớp học đã full 10 học viên rồi',16,1)
		rollback transaction
	end
	
	else
	begin
		update dbo.Classes set dbo.Classes.No_Students += 1 from inserted, dbo.Classes where inserted.Class_ID = dbo.Classes.ID
	end
end

---- View LamNguyen
--Mã lớp, Tên lớp, Tên khóa học, Tên giáo viên, Ngày học, Thời gian học, Phòng học
create view StudentScheduleView
as

select cl.ID as 'Mã lớp', cl.Name as 'Tên lớp',c.Name as 'Tên khóa học' ,t.Name as 'Tên giáo viên', cl.WeekDays as 'Ngày học', CONCAT(SUBSTRING(convert(varchar, cl.Start_Time ,108),1,5),' : ' ,SUBSTRING(convert(varchar, cl.End_Time ,108),1,5)) as 'Thời gian học', cl.ClassRoom as 'Phòng học'
from Classes cl inner join Courses c on cl.Course_ID = c.ID inner join Teachers t on cl.Username = t.Username
go

-- procedure lấy thông tin Schedule
create procedure getScheduleStudent
as begin 
select * from StudentScheduleView
end


select * from Accounts
go
--Teacher Schedule
--Mã lớp, Tên lớp,Mã khóa học, Tên khóa học, Ngày học, Thời gian học, Phòng học
create view TeacherScheduleView
as

select cl.ID as 'Mã lớp', cl.Name as 'Tên lớp',cl.Course_ID as 'Mã khóa học',c.Name as 'Tên khóa học' , cl.WeekDays as 'Ngày học', CONCAT(SUBSTRING(convert(varchar, cl.Start_Time ,108),1,5),' : ' ,SUBSTRING(convert(varchar, cl.End_Time ,108),1,5)) as 'Thời gian học', cl.ClassRoom as 'Phòng học'
from Classes cl inner join Courses c on cl.Course_ID = c.ID inner join Teachers t on cl.Username = t.Username
go

-- procedure lấy thông tin Schedule
create procedure getScheduleTeacher
as begin 
select * from TeacherScheduleView
end
go
--Lịch sử giao dịch
--Username, Thời gian giao dịch, Số tiền, Phương thức thanh toán, tình trạng
create view PaymentView
as
select st.Username, pa.Payment_Date as 'Thời gian giao dịch', pa.Amount as 'Số tiền', pm.Name as 'Phương thức thanh toán', pa.Status as 'Tình trạng'
from Students st inner join Payments pa on st.Username = pa.Username inner join Payment_Methods pm on pa.Payment_Method_ID = pm.ID
go
create procedure GetTransactionHistory
as begin 
select * from PaymentView
end
go

