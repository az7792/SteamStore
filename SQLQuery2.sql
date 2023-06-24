--CREATE TABLE [dbo].[7792GL]([GID] INT NOT NULL, PRIMARY KEY([GID]))
--insert into _7792GL (GId) values (2)
--insert into _7792GL (GId) values (3)
--insert into _7792GL (GId) values (4)
--insert into _7792GL (GId) values (5)
--insert into _7792GL (GId) values (6)
select GImage,Gname,GAuthor,GTime,GType,GPrice from GameTable
JOIN _7792GL ON GameTable.GId = _7792GL.GID;