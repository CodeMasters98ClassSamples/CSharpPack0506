-- CRUD => Create(insert) update delet read
-- TSQL

-- Student
SELECT * FROM dbo.Student
SELECT [Name],LastName FROM dbo.Student
SELECT [Name],LastName FROM dbo.Student WHERE Id = 1
SELECT [Name],LastName FROM dbo.Student WHERE Id = 1 AND NationalCode = '0020500000'
SELECT [Name],LastName FROM dbo.Student WHERE Id = 1 OR NationalCode = '0020500000'
SELECT [Name] AS FirstName,LastName FROM dbo.Student WHERE Id = 1 OR NationalCode = '0020500000'
SELECT TOP 1 * FROM dbo.Student
SELECT * FROM dbo.Student ORDER BY Id DESC

INSERT INTO dbo.Student([Name],LastName,MobileNumber,NationalCode,BirthDate,LastDocument)
VALUES (N'نرگس', N'انوشه', '09129564207', '0020500000',null,4)

--UPDATE dbo.Student SET MobileNumebr = '09129564206' WHERE Id = 1
--UPDATE dbo.Student SET [Name] = N'مهدی یار' , LastName = 'نهاوندی' WHERE Id = 1
--UPDATE dbo.Student SET [Name] = N'امیرمحمد' , LastName = 'خانزاده' WHERE Id = 3

--DELETE dbo.Student WHERE Id = 2	


-- Master

SELECT * FROM dbo.[Master]

--INSERT INTO [dbo].[Master]
--           ([Name]
--           ,[LastName]
--           ,[MobileNumber]
--           ,[NationalCode]
--           ,[BirthDate]
--           ,[Card])
--     VALUES
--           (N'ساناز'
--           ,N'عباس زاده'
--           ,N'09129564203'
--           ,N'0020523721'
--           ,null
--           ,'6219861072090001')
--GO

-- Course

SELECT * FROM [dbo].[Course]

--INSERT INTO [dbo].[Course]
--           ([Name]
--           ,[Description]
--           ,[Link]
--           ,[MasterId])
--     VALUES
--           (N'پایگاه داده'
--           ,N'تو این دوره خیلی چیزا قرار یاد بگیریم'
--           ,'https://sematec-co.com/course/sql-server-2025-database-implementation/'
--           ,2)

-- Term
SELECT * FROM Dbo.Term

INSERT INTO [dbo].[Term]
           ([Code]
           ,[Price]
           ,[CourseId])
     VALUES
           ('0509-Database'
           ,14900000
           ,3)
GO

-- لطفا بفرمایید هر استاد چه دوره هایی برگزار میکند و هر دوره چه ترم هایی داردگ

SELECT * FROM dbo.[Master] M INNER JOIN dbo.Course C ON M.Id = C.MasterId

SELECT * FROM dbo.[Master] M 
    INNER JOIN dbo.Course C ON M.Id = C.MasterId
    INNER JOIN dbo.Term T ON C.Id = T.CourseId

-- Functions
SELECT GETDATE()

select * from [dbo].[StudentTerm]

select * from [dbo].[StudentTerm] ST INNER JOIN dbo.Student s ON ST.StudentId = s.Id

INSERT INTO [dbo].[StudentTerm]
           ([RegistrationStatus]
           ,[PaidAmount]
           ,[StudentId]
           ,[TermId])
     VALUES
           (2
           ,2000000
           ,3
           ,3)
GO
