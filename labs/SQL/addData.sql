use RabbitDb
go

INSERT INTO Rabbits (Age, Name) VALUES(0, 'Flopsy') , (0, 'Gary')

--SET IDENTITY_INSERT Rabbits ON
--INSERT INTO Rabbits ( RabbitId, Age, Name) VALUES (4,0, 'Rabbit04')
--SET IDENTITY_INSERT Rabbits OFF

--DELETE FROM Rabbits WHERE RabbitId = 4

SELECT 'Rabbits Database'
SELECT * FROM Rabbits