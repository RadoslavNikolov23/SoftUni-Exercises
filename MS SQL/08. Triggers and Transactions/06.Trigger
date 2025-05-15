USE Diablo

GO

---First task Trigger
CREATE TRIGGER tr_CheckIfGameLevelisAbove
ON UserGameItems
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @itemID INT = (Select ItemId FROM inserted)
	DECLARE @usergameID INT = (SELECT UserGameId FROM inserted)

	DECLARE @minLevelWanted INT = (Select MinLevel FROM Items WHERE Id=@itemID)
	DECLARE @gameLevel INT = (Select [Level] FROM UsersGames WHERE Id=@usergameID)

	IF(@minLevelWanted>@gameLevel)
		BEGIN
			;THROW 50005, 'Item level is greater than level!',4;
		END
	INSERT INTO UserGameItems(ItemId,UserGameId)
	VALUES (@itemID,@gameLevel)
END



INSERT INTO UserGameItems(ItemId,UserGameId)
VALUES (1,5)

--------Second task Update UserGames
UPDATE UsersGames
SET Cash +=50000
WHERE UserId IN (SELECT Id
			  FROM Users
			  WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
			  )
AND GameId IN (SELECT Id
			  FROM Games
			  WHERE [Name] ='Bali'
			  )

Select *
FROM UsersGames
WHERE UserId IN (SELECT Id
			  FROM Users
			  WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
			  )
AND GameId IN (SELECT Id
			  FROM Games
			  WHERE [Name] ='Bali'
			  )

GO
-----Third Task Create a stored procedure
CREATE PROC dbo.usp_BuyingItems
		@idUser INT, @itemID INT, @gameId INT
AS
BEGIN TRANSACTION
	DECLARE @user INT = (SELECT Id FROM Users WHERE Id=@idUser)
	IF(@user IS NULL)
		BEGIN ROLLBACK;
				THROW 50001, 'Invalid user',1;
		END	

	DECLARE @item INT = (SELECT Id FROM Items WHERE Id=@itemID)
	IF(@item IS NULL)
		BEGIN ROLLBACK;
				THROW 50002, 'Invalid item',2;
		END	

	DECLARE @game INT = (SELECT Id FROM Games WHERE Id=@gameId)
	IF(@game IS NULL)
		BEGIN ROLLBACK;
				THROW 50003, 'Invalid game',3;
		END

	DECLARE @gameName VARCHAR(50) = (SELECT [Name] FROM Games WHERE Id=@gameId)
	DECLARE @userAmount DECIMAL (18,2) = (SELECT Cash FROM UsersGames WHERE UserId=@idUser)
	DECLARE @itemPrice DECIMAL (18,2) = (SELECT Price FROM Items WHERE Id=@itemID)

	IF( @userAmount-@itemPrice<0)
		BEGIN ROLLBACK;
				THROW 50004, 'Not Enough Cash!',4;
		END

	INSERT INTO UserGameItems
	VALUES(@itemID,@gameId)

	UPDATE UsersGames
	SET Cash-=@itemPrice
	WHERE UserId=@idUser AND GameId=@gameId
COMMIT

GO

-----Forth task Create a Select
SELECT 
	u.Username
	,g.[Name] AS [Name]
	,ug.Cash AS Cash
	,i.[Name] AS [Item Name] 
FROM Users AS u
JOIN UsersGames AS ug 
  ON u.Id = ug.UserId
JOIN UserGameItems ugi 
  ON ug.GameId = ugi.UserGameId
JOIN Items AS i 
  ON ugi.ItemId = i.Id
JOIN Games AS g 
  ON ug.GameId = g.Id
WHERE g.Name = 'Bali'
ORDER BY u.Username, i.[Name]