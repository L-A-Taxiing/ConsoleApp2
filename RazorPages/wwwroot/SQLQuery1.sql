--新建一个数据库：17bang，能指定/查看该数据库存放位置
CREATE DATABASE [17bang];

--依次备份/删除/恢复该数据库
BACKUP DATABASE [17bang] TO DISK ='E:\\17bang.bak';
DROP DATABASE [17bang];
RESTORE DATABASE [17bang] FROM DISK='E:\\17bang.bak';

USE [17bang]
--观察“一起帮”的：
--1.注册和发布求助功能，试着建表User：包含UserName（用户名），Password（密码）
--2.内容发布功能：试着建表Keyword：包含Name（名称），Used（使用次数）
CREATE TABLE [User]
(
   [UserName] NVARCHAR(10) NOT NULL,
   [Password] INT NOT NULL
);

CREATE TABLE Keyword(
   [Name] NVARCHAR(10) NOT NULL,
   [Used] INT NULL

);
--为User表添加一列：邀请人（InvitedBy），类型为INT
ALTER TABLE [User] ADD IncitedBy INT NOT NULL;
ALTER TABLE [User] Drop COLUMN IncitedBy;
ALTER TABLE [User] ADD InvitedBy INT NULL;

--将InvitedBy类型修改为NVARCHAR(10)
ALTER TABLE [User] ALTER COLUMN InvitedBy NVARCHAR(10);

--删除列InvitedBy
ALTER TABLE [User] DROP COLUMN InvitedBy;

ALTER TABLE [Keyword] ADD WORD INT NULL; 
ALTER TABLE [Keyword] DROP COLUMN WORD;

--观察“一起帮”的发布求助功能，试着建立表Problem，包含：
--1.Id
--2.Title（标题）
--3.Content（正文）
--4.NeedRemoteHelp（需要远程求助）
--5.Reward（悬赏）
--6.PublishDateTime（发布时间）
CREATE TABLE [Problem]
(
  [Id] INT NULL,
  [Title] NVARCHAR(20) NULL,
  [Content] NTEXT NULL,
  [NeedRemoteHelp] BIT,
  [Reward] INT NULL,
  [PublishDateTime] DATE

);

--1.在User表中插入以下四行数据：
INSERT [User](UserName,Password) VALUES(N'17bang',1234);
INSERT [User](UserName,Password) VALUES(N'Admin',NULL);
INSERT [User](UserName,Password) VALUES(N'Admin-1','');
INSERT [User](UserName,Password) VALUES(N'SuperAdmin',123456);

SELECT * FROM [User];

ALTER TABLE [User] ALTER COLUMN Password INT NULL;
INSERT [User](UserName,Password) VALUES(N'Admin',NULL);

--2.将Problem表中的Reward全部更新为0
UPDATE [Problem] SET Reward=0;
SELECT Reward FROM [Problem];

--3.使用事务，删除User表中的全部数据，回滚事务，撤销之前的删除行为
BEGIN TRAN 
DELETE [User]
SELECT * FROM [User];
ROLLBACK


--在User表中：
--1.查找没有录入密码的用户
SELECT UserName FROM [User] WHERE Password IS NULL;
--2.删除用户名（UserName）中包含“Admin”或者“17bang”字样的用户
SELECT * FROM [User];
BEGIN TRAN
DELETE [User] WHERE UserName Like '%Admin%' OR UserName Like'%17bang%';
ROLLBACK
 
--在Problem表中：
SELECT * FROM [Problem];
DELETE [Problem] WHERE ID IS NULL;
BEGIN TRAN
INSERT Problem(Id,Title,Reward,PublishDateTime) VALUES(1,N'编程开发基础',15,'2019-1-5');
INSERT Problem(Id,Title,Reward,PublishDateTime) VALUES(2,N'SQL',25,'2010-10-5');
INSERT Problem(Id,Title,Reward,PublishDateTime) VALUES(3,N'[C#怎么学]',8,'2020-1-5');
INSERT Problem(Id,Title,Reward,PublishDateTime) VALUES(4,N'[js怎么学]',25,'2010-1-5');
INSERT Problem(Id,Title,Reward,PublishDateTime) VALUES(5,N'数据库-100%',15,'2012-10-5');
INSERT Problem(Id,Title,Reward,PublishDateTime) VALUES(6,N'数据库-1%',12,'2020-10-5');
INSERT Problem(Id,Title,Reward,PublishDateTime) VALUES(7,N'数据库-2%',15,'2021-10-5');
INSERT Problem(Id,Title,Reward,PublishDateTime) VALUES(8,N'数据库',13,'2019-10-5');
INSERT Problem(Id,Title,Reward,PublishDateTime) VALUES(9,N'Razorpage',15,'2015-12-5');
INSERT Problem(Id,Title,Reward,PublishDateTime) VALUES(10,N'%',10,'2015-11-5');
COMMIT
--1.给所有悬赏（Reward）大于10的求助标题加前缀：【推荐】
SELECT * FROM [Problem];
BEGIN TRAN
UPDATE [Problem] SET Title=N'[推荐]'+Title WHERE Reward>10;
COMMIT
--2.给所有悬赏大于20且发布时间（Created）在2019年10月10日之后的求助标题加前缀：【加急】
SELECT * FROM [Problem];
BEGIN TRAN
UPDATE [Problem] SET Title=N'[加急]'+Title WHERE PublishDateTime>'2019/10/10';
--3.删除所有标题以中括号【】开头（无论其中有什么内容）的求助
SELECT * FROM [Problem];
BEGIN TRAN
DELETE [Problem] WHERE Title LIKE N'~[%]%' ESCAPE '~';
ROLLBACK
--4.查找Title中第5个起，字符不为“数据库”且包含了百分号（%）的求助
SELECT Title FROM [Problem] 
WHERE Id>=5 AND Title  NOT LIKE N'数据库' AND Title LIKE N'%~%%' ESCAPE '~';

--在Keyword表中：
SELECT * FROM [Keyword];
INSERT [Keyword](Name,Used) VALUES(N'编程开发基础',10)
INSERT [Keyword](Name,Used) VALUES(N'JavaScript',15)
INSERT [Keyword](Name,Used) VALUES(N'C#',70)
INSERT [Keyword](Name,Used) VALUES(N'SQL',8)
INSERT [Keyword](Name,Used) VALUES(N'Linq',13)
INSERT [Keyword](Name,Used) VALUES(N'Java',101)
INSERT [Keyword](Name,Used) VALUES(N'Go',0)
INSERT [Keyword](Name,Used) VALUES(N'Python',NULL)

--1.找出所有被使用次数（Used）大于10小于50的关键字名称（Name）
SELECT Name FROM [Keyword] WHERE Used BETWEEN 10 AND 50;
--2.如果被使用次数（Used）小于等于0，或者是NULL值，或者大于100的，将其更新为1
BEGIN TRAN
UPDATE [Keyword] SET Used=1 WHERE Used <=0 OR Used IS NULL OR Used>100;
COMMIT
--3.删除所有使用次数为奇数的Keyword
BEGIN TRAN
DELETE Keyword WHERE Used%2<>0;
ROLLBACK



