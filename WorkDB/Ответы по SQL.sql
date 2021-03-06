1) Написать триггер который от будет отлавливать создание Контрагента и установливать дату создания
на 1 месяц назад.

CREATE TRIGGER Accounts_INSERT
ON Accounts
AFTER INSERT 
AS
	UPDATE Accounts
	SET CreateOn = DATEADD(Accounts, -1, CreateOn)
	WHERE Id = (SELECT Id FROM inserted)

Вставка значений
INSERT INTO [dbo].[Accounts]
           ([Id]
           ,[Name]
           ,[CreateOn]
           ,[ContactId])
     VALUES
           (NEWID(),'НОВАЯ','2000.09.12','GUID Контакта')
------------------------------------------------------------------------------------------------------------
2) Почему не выполнится этот запрос?
SELECT
user_name,
YEAR(user_birth_date) AS year_of_birth
FROM
users
WHERE
year_of_birth = 2000

Потому что year_of_birth не существует при формировании выборки. оно появляется уже после того как выборка из таблици уже была сделанна

------------------------------------------------------------------------------------------------------------

3) Написать хранимую процедуру с параметрами, которая будет выводить по запросу:
- При вводе имени контакта выводить название обращения в которых он присутствует.      


CREATE PROCEDURE Test
    @NameContakt nvarchar(MAX)   
AS   
    SELECT Name  
    FROM Cases  
    WHERE Name = @NameContakt;

Вызов процедуры 
	EXECUTE  Test @NameContakt ='Образение12';