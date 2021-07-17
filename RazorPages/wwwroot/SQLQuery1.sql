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
DELETE [User] WHERE UserName Like '%Admin%'OR USERNAME LIKE'%17bang%';
ROLLBACK
 
--在Problem表中：
SELECT * FROM [Problem];
DELETE [Problem] WHERE ID IS NULL;
BEGIN TRAN
INSERT Problem(Id,Title,Reward,NeedRemoteHelp,PublishDateTime) VALUES(1,N'编程开发基础',15,1,'2019-1-5');
INSERT Problem(Id,Title,Reward,NeedRemoteHelp,PublishDateTime) VALUES(2,N'SQL',25,1,'2010-10-5');
INSERT Problem(Id,Title,Reward,NeedRemoteHelp,PublishDateTime) VALUES(3,N'[C#怎么学]',8,0,'2020-1-5');
INSERT Problem(Id,Title,Reward,NeedRemoteHelp,PublishDateTime) VALUES(4,N'[js怎么学]',25,1,'2010-1-5');
INSERT Problem(Id,Title,Reward,NeedRemoteHelp,PublishDateTime) VALUES(5,N'数据库-100%',15,1,'2012-10-5');
INSERT Problem(Id,Title,Reward,NeedRemoteHelp,PublishDateTime) VALUES(6,N'数据库-1%',12,0,'2020-10-5');
INSERT Problem(Id,Title,Reward,NeedRemoteHelp,PublishDateTime) VALUES(7,N'数据库-2%',15,1,'2021-10-5');
INSERT Problem(Id,Title,Reward,NeedRemoteHelp,PublishDateTime) VALUES(8,N'数据库',13,1,'2019-10-5');
INSERT Problem(Id,Title,Reward,NeedRemoteHelp,PublishDateTime) VALUES(9,N'Razorpage',15,1,'2015-12-5');
INSERT Problem(Id,Title,Reward,NeedRemoteHelp,PublishDateTime) VALUES(10,N'%',10,0,'2015-11-5');
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

--在User表上的基础上：
--1.添加Id列，让Id成为主键
SELECT * FROM [User]
ALTER TABLE [User]
--ADD Id INT
--UPDATE [User] SET Id=1 WHERE UserName=N'17BANG'
--UPDATE [User] SET Id=2 WHERE UserName=N'ADMIN'
--UPDATE [User] SET Id=3 WHERE UserName=N'ADMIN-1'
--UPDATE [User] SET Id=4 WHERE UserName=N'SUPERADMIN'
--ALTER COLUMN Id INT NOT NULL
ADD CONSTRAINT PK_User_Id PRIMARY KEY(Id)
--2.添加约束，让UserName不能重复
ALTER TABLE [User] 
ADD CONSTRAINT UQ_User_UserName UNIQUE(UserName)

--在Problem表的基础上：
--1.为NeedRemoteHelp添加NOT NULL约束，再删除NeedRemoteHelp上NOT NULL的约束
SELECT * FROM Problem
UPDATE Problem SET NeedRemoteHelp=1 WHERE Id=1
UPDATE Problem SET NeedRemoteHelp=1 WHERE Id=2
UPDATE Problem SET NeedRemoteHelp=1 WHERE Id=3
UPDATE Problem SET NeedRemoteHelp=1 WHERE Id=4
UPDATE Problem SET NeedRemoteHelp=1 WHERE Id=5
UPDATE Problem SET NeedRemoteHelp=1 WHERE Id=6
UPDATE Problem SET NeedRemoteHelp=1 WHERE Id=7
UPDATE Problem SET NeedRemoteHelp=1 WHERE Id=8
UPDATE Problem SET NeedRemoteHelp=1 WHERE Id=9
ALTER TABLE PROBLEM ALTER COLUMN NeedRemoteHelp BIT NOT NULL
--2.添加自定义约束，让Reward不能小于10
UPDATE Problem SET Reward=13 WHERE Id=2
ALTER TABLE PROBLEM
ADD CONSTRAINT CK_Problem_Reward CHECK(Reward>=10)
--INSERT PROBLEM(NeedRemoteHelp,Reward) VALUES(1,9)

--1.观察一起帮的“关键字”功能，新建Keyword表，要求带一个自增的主键Id，起始值为10，步长为5；并存入若干条数据
DROP TABLE Keyword
SELECT * FROM Keyword;
CREATE TABLE Keyword(
   ID INT IDENTITY(10,5) CONSTRAINT PK_Keyword_Id PRIMARY KEY,
   [NAME] NVARCHAR(10)NOT NULL
)
INSERT Keyword(NAME) VALUES(N'编程开发基础')
INSERT Keyword(NAME) VALUES(N'JAVASCRIPT')
INSERT Keyword(NAME) VALUES(N'C#')
INSERT Keyword(NAME) VALUES(N'SQL')
INSERT Keyword(NAME) VALUES(N'RAZORPAGE')
INSERT Keyword(NAME) VALUES(N'PYTHON')
--2.将User表中Id列修改为可存储GUID的类型，并存入若干条包含GUID值的数据
SELECT * FROM [User]
ALTER TABLE [User]
--DROP CONSTRAINT PK_User_Id
ALTER COLUMN Id VARCHAR(50)
INSERT [User](UserName,Id) VALUES(N'叶子',NEWID())
INSERT [User](UserName,Id) VALUES(N'叶飞',NEWID())
INSERT [User](UserName,Id) VALUES(N'叶问',NEWID())
INSERT [User](UserName,Id) VALUES(N'叶剑英',NEWID())
INSERT [User](UserName,Id) VALUES(N'叶？',NEWID())
--3.Problem表已有Id列，如何给该列加上IDENTITY属性？
SELECT * FROM Problem
CREATE TABLE Problem2(
  Id INT IDENTITY
);
ALTER TABLE PROBLEM2 ADD Title NVARCHAR(20) NULL
ALTER TABLE PROBLEM2 ADD Content NTEXT NULL
ALTER TABLE PROBLEM2 ADD NeedRemoteHelp BIT NOT NULL
ALTER TABLE PROBLEM2 ADD Reward INT NULL
ALTER TABLE PROBLEM2 ADD PublishDateTime DATE NULL
SET IDENTITY_INSERT Problem2 ON
INSERT INTO Problem2(Id,Title,Content,NeedRemoteHelp,Reward,PublishDateTime)
SELECT Id,Title,Content,NeedRemoteHelp,Reward,PublishDateTime FROM Problem
SET IDENTITY_INSERT PROBLEM2 OFF
DROP TABLE Problem
exec sp_rename 'Problem2','Problem';

SELECT TOP 3 ID FROM Problem


--1.在Problem中插入不同作者（Author）不同悬赏（Reward）的若干条数据，以便能完成以下操作：
SELECT * FROM Problem
ALTER TABLE PROBLEM ADD Author NVARCHAR(10) 
UPDATE PROBLEM SET AUTHOR=N'飞哥' WHERE ID=1
UPDATE PROBLEM SET AUTHOR=N'飞哥' WHERE ID=2
UPDATE PROBLEM SET AUTHOR=N'飞弟' WHERE ID=4
UPDATE PROBLEM SET AUTHOR=N'飞兄' WHERE ID=5
UPDATE PROBLEM SET AUTHOR=N'飞儿' WHERE ID=6
UPDATE PROBLEM SET AUTHOR=N'飞爷' WHERE ID=7
UPDATE PROBLEM SET AUTHOR=N'飞子' WHERE ID=8
UPDATE PROBLEM SET AUTHOR=N'飞哥' WHERE ID=9
UPDATE PROBLEM SET AUTHOR=N'飞哥' WHERE ID=10
--1.查找出Author为“飞哥”的、Reward最多的3条求助
SELECT TOP 3 * FROM Problem
WHERE Author=N'飞哥'
ORDER BY Reward DESC
--2.所有求助，先按作者“分组”，然后在“分组”中按悬赏从大到小排序
SELECT AUTHOR,REWARD FROM PROBLEM
ORDER BY AUTHOR,REWARD DESC
--3.查找并统计出每个作者的：求助数量、悬赏总金额和平均值
SELECT AUTHOR,COUNT(TITLE) AS N'求助数量',SUM(REWARD) AS N'悬赏总金额',AVG(REWARD) AS N'悬赏平均值'
FROM PROBLEM
GROUP BY AUTHOR
--4.找出平均悬赏值少于20的作者并按平均值从小到大排序
SELECT AUTHOR,AVG(REWARD) AS N'平均值' FROM PROBLEM
GROUP BY AUTHOR
HAVING AVG(REWARD)<=20
ORDER BY AVG(REWARD)
--2.以Problem中的数据为基础，使用SELECT INTO，新建一个Author和Reward
--都没有NULL值的新表：NewProblem （把原Problem里Author或Reward为NULL值的数据删掉）
ALTER TABLE PROBLEM ALTER COLUMN NeedRemoteHelp BIT NULL;
INSERT PROBLEM(Author) VALUES(NULL)
SELECT * FROM PROBLEM
DELETE PROBLEM WHERE Author IS NULL OR Reward IS NULL
SELECT *
INTO NEWPROBLEM
FROM PROBLEM
SELECT * FROM NEWPROBLEM
--3.使用INSERT SELECT, 将Problem中Reward为NULL的行再次插入到NewProblem中
INSERT NEWPROBLEM(Title,Content,NeedRemoteHelp,Reward,PublishDateTime,Author )
SELECT Title,Content,NeedRemoteHelp,Reward,PublishDateTime,Author  
FROM PROBLEM WHERE REWARD IS NULL

--新建表Message(Id, FromUser, ToUser, UrgentLevel, Kind, HasRead, IsDelete, Content)，使用该表和SQL语句，证明：
CREATE TABLE [Message]
(
  Id INT,
  FromUser NVARCHAR(10) CONSTRAINT UQ_Message_FromUser UNIQUE,
  ToUser NVARCHAR(10),
  UrgentLevel INT NULL,
  Kind NVARCHAR(10),
  HasRead BIT CONSTRAINT DF_Message_HasRead  Default(1),
  IsDelete BIT CONSTRAINT DF_Message_IsDelete Default(0),
  Content NTEXT NULL
)
SELECT * FROM Message
SELECT [name], [type], is_unique, is_primary_key, is_unique_constraint 
FROM sys.indexes 
WHERE object_id = OBJECT_ID('Message')
--1.唯一约束依赖于唯一索引
DROP INDEX Message.UQ_Message_FromUser
--无法删除唯一索引，因为唯一索引上面有唯一约束
--报错：An explicit DROP INDEX is not allowed on index 'Message.UQ_Message_FromUser'. It is being used for UNIQUE KEY constraint enforcement.
ALTER TABLE Message
DROP CONSTRAINT UQ_Message_FromUser
--删除唯一约束会删除唯一索引
--2.主键上可以是非聚集索引
--在已有列添加聚集索引
CREATE CLUSTERED INDEX INDEX_Message_ToUser ON Message(ToUser)
--建立主键约束
ALTER TABLE  Message ALTER COLUMN Id INT NOT NULL
ALTER TABLE Message ADD CONSTRAINT PK_Message_Id PRIMARY KEY(Id)
--查询发现Id为非聚集唯一索引Type2
--并利用“执行计划”图演示说明：Scan、Seek和Lookup的使用和区别。



--观察并模拟17bang项目中的：
--1.用户资料，新建用户资料（Profile）表，和User形成1:1关联（有无约束？）。用SQL语句演示：
CREATE TABLE Profile(
   Id INT CONSTRAINT PK_Profile_User PRIMARY KEY,
   Icon NTEXT ,
   Gender BIT ,
   BirthYear INT,
   BirthMonth INT,
   Constellation NVARCHAR(3),
   SelfIntroduction NTEXT,
)
CREATE TABLE [User](
   Id INT CONSTRAINT PK_User_Id PRIMARY KEY IDENTITY(1,1),
   UserName NVARCHAR(10),
   PassWord INT,
   ProfileId INT CONSTRAINT UQ_Profile_UserId UNIQUE CONSTRAINT FK_Profile_Id Foreign KEY(ProfileId) REFERENCES [Profile](Id),
   InvitedBy INT CONSTRAINT FK_User_InvitedBy FOREIGN KEY(InvitedBy) REFERENCES [User](Id)
)
SELECT * FROM [User]
--DROP TABLE [User]
DELETE [User]
SELECT * FROM Profile
INSERT [User] VALUES(N'飞哥',1234,2,NULL)
INSERT [User] VALUES(N'飞兄',2345,4,NULL)
INSERT [User] VALUES(N'飞弟',3456,1,NULL)
INSERT [User] VALUES(N'飞爷',4567,3,NULL)
INSERT [User] VALUES(N'飞孙',5678,5,NULL)

INSERT Profile VALUES(1,NULL,1,1998,10,N'天蝎座',N'自我介绍-1')
INSERT Profile VALUES(2,NULL,1,2000,10,N'双鱼座',N'自我介绍-2')
INSERT Profile VALUES(3,NULL,1,1997,10,N'金牛座',N'自我介绍-3')
INSERT Profile VALUES(4,NULL,1,1999,10,N'水瓶座',N'自我介绍-4')
INSERT Profile VALUES(5,NULL,1,2001,10,N'天蝎座',N'自我介绍-5')
--   1.新建一个填写了用户资料的注册用户
INSERT Profile VALUES(6,NULL,0,2002,3,N'双子座',N'自我介绍-6')
--   2.通过Id查找获得某注册用户及其用户资料
SELECT * FROM [User] 
where Id=26
--   3.删除某个Id的注册用户
SELECT * FROM [User]
SELECT * FROM Profile
DELETE [User] WHERE Id=30
DELETE Profile WHERE Id=5
--必须先删除主表才能删除从表


--2.帮帮点说明：新建Credit表，可以记录用户的每一次积分获得过程，即：某个用户，在某个时间，因为某某原因，获得若干积分
CREATE TABLE Credit(
    Id INT PRIMARY KEY,
    UserId INT CONSTRAINT FK_Crdit_UserId FOREIGN KEY(UserId) REFERENCES  [User](Id),
    Time DATETIME,
    Reason NTEXT,
    Credits INT
)

--3.发布求助，在Problem和User之间建立1:n关联（含约束）。用SQL语句演示：
SELECT * FROM Problem
SELECT * FROM [User]
ALTER TABLE Problem ADD UID INT CONSTRAINT FK_Problem_UID FOREIGN KEY(UID) REFERENCES [User](Id)
--   1.某用户发布一篇求助，
INSERT Problem VALUES(17,NULL,0,20,NULL,N'飞弟',28)
--   2.将该求助的作者改成另外一个用户
UPDATE Problem SET UID=26
WHERE Id=2
--   3.删除该用户
DELETE Problem WHERE UID=26
DELETE [User] WHERE Id=26


--4.求助列表：新建Keyword表，和Problem形成n:n关联（含约束）。用SQL语句演示：
SELECT * FROM Keyword
SELECT * FROM Problem
SELECT * FROM Keyword2Problem
DROP TABLE Keyword
CREATE TABLE Keyword(
   Id INT PRIMARY KEY IDENTITY(1,5),
   Keyword NVARCHAR(10)
)
INSERT Keyword VALUES(N'编程开发基础')
INSERT Keyword VALUES(N'JAVA')
INSERT Keyword VALUES(N'Razorpage')
INSERT Keyword VALUES(N'SQL')
INSERT Keyword VALUES(N'JAVA')
INSERT Keyword VALUES(N'SQL')
INSERT Keyword VALUES(N'JAVASCRIPT')
INSERT Keyword VALUES(N'C#')
INSERT Keyword VALUES(N'JAVA')
INSERT Keyword VALUES(N'C#')
INSERT Keyword VALUES(N'从入门到弃坑')
ALTER TABLE Problem ADD CONSTRAINT PK_Problem_Id PRIMARY KEY(Id)
CREATE TABLE Keyword2Problem(
  KID INT CONSTRAINT FK_Keyword2Problem_KID FOREIGN KEY(KID) REFERENCES Keyword(Id),
  PID INT CONSTRAINT FK_Keyword2Priblem_PID FOREIGN KEY(PID) REFERENCES Problem(Id)
)
INSERT Keyword2Problem VALUES(1,4)
INSERT Keyword2Problem VALUES(1,5)
INSERT Keyword2Problem VALUES(6,5)
INSERT Keyword2Problem VALUES(6,6)
INSERT Keyword2Problem VALUES(6,8)
INSERT Keyword2Problem VALUES(11,4)
INSERT Keyword2Problem VALUES(11,9)
INSERT Keyword2Problem VALUES(21,10)
INSERT Keyword2Problem VALUES(21,18)
INSERT Keyword2Problem VALUES(21,19)
--   1.查询获得：每个求助使用了多少关键字，每个关键字被多少求助使用
SELECT COUNT(KID) AS N'使用了多少关键字',KID FROM Keyword2Problem WHERE KID=6
GROUP BY KID

SELECT COUNT(PID) AS N'每个关键字被多少求助使用',PID  FROM Keyword2Problem WHERE PID=10
GROUP BY PID
--   2.发布了一个使用了若干个关键字的求助
INSERT PROBLEM VALUES(N'JAVA',NULL,1,12,'2021-2-1',N'RICK',27)
INSERT Keyword2Problem VALUES(36,28)
INSERT Keyword2Problem VALUES(51,28)
--   3.该求助不再使用某个关键字
DELETE Keyword2Problem WHERE KID=36 AND PID=28
--   4.删除该求助
DELETE Keyword2Problem WHERE PID=28
DELETE PROBLEM WHERE ID=28
--   5.删除某关键字
INSERT Keyword2Problem VALUES(56,4)
DELETE Keyword2Problem WHERE KID=56
DELETE Keyword WHERE ID=56

SELECT * FROM Keyword
SELECT * FROM Problem
SELECT * FROM Keyword2Problem



--1.联表查出求助的标题和作者用户名
SELECT * FROM Problem
SELECT * FROM [User]
UPDATE  Problem SET UID=27 WHERE Id=4
UPDATE  Problem SET UID=27 WHERE Id=5
UPDATE  Problem SET UID=28 WHERE Id=6
UPDATE  Problem SET UID=28 WHERE Id=7
UPDATE  Problem SET UID=29 WHERE Id=8
UPDATE  Problem SET UID=29 WHERE Id=9
SELECT P.Title,U.UserName FROM Problem P 
JOIN [User] U
ON P.UID=U.Id

--2.查找并删除从未发布过求助的用户
DELETE Keyword2Problem WHERE PID>=10
SELECT * FROM Problem P
LEFT JOIN [User] U
ON P.UID=U.Id
WHERE U.Id IS NULL

BEGIN TRAN
DELETE Problem
FROM Problem P LEFT JOIN [User] U ON P.UID=U.Id
WHERE U.Id IS NULL
COMMIT


--3.用一句SELECT显示出用户和他的邀请人用户名
UPDATE [User] SET InvitedBy=29 WHERE Id=27
UPDATE [User] SET InvitedBy=28 WHERE Id=28
UPDATE [User] SET InvitedBy=27 WHERE Id=29
SELECT * FROM [User]
SELECT * FROM [User] U1 JOIN [User] U2
ON U1.Id=U2.InvitedBy


--4.17bang的关键字有“一级”“二级”和其他“普通（三）级”的区别：
--    1.请在表Keyword中添加一个字段，记录这种关系
CREATE TABLE Keyword2(
   Id INT PRIMARY KEY IDENTITY(1,1),
   Keyword NVARCHAR(10),
   Relation INT
)
SET IDENTITY_INSERT Keyword2 ON
INSERT Keyword2(Id,Keyword,Relation) VALUES(1,N'SQL',3)
INSERT Keyword2(Id,Keyword,Relation) VALUES(2,N'C#',3)
INSERT Keyword2(Id,Keyword,Relation) VALUES(3,N'编程开发基础',NULL)
INSERT Keyword2(Id,Keyword,Relation) VALUES(4,N'VS',5)
INSERT Keyword2(Id,Keyword,Relation) VALUES(5,N'开发工具',NULL)
INSERT Keyword2(Id,Keyword,Relation) VALUES(6,N'自联接',1)
INSERT Keyword2(Id,Keyword,Relation) VALUES(7,N'事务',1)
INSERT Keyword2(Id,Keyword,Relation) VALUES(8,N'泛型',2)
SET IDENTITY_INSERT Keyword2 OFF
--    2.然后用一个SELECT语句查出所有普通关键字的上一级、以及上上一级的关键字名称，比如：
SELECT K3.Keyword 关键字,K2.Keyword 上一级,K1.Keyword 再上一级  FROM Keyword2 K1
RIGHT JOIN Keyword2 K2
ON K1.Id=K2.Relation
RIGHT JOIN Keyword2 K3
ON K2.Id=K3.Relation
SELECT * FROM Keyword2


--5.17bang中除了求助（Problem），还有意见建议（Suggest）和文章（Article），
--他们都包含Title、Content、PublishTime和Auhthor四个字段，但是：
--      1.建议和文章没有悬赏（Reward）
--      2.建议多一个类型：Kind NVARCHAR(20)）
--      3.文章多一个分类：Category INT）
--请按上述描述建表。然后，用一个SQL语句显示某用户发表的求助、建议和文章的Title、Content，并按PublishTime降序排列
CREATE TABLE Content(
    Id INT PRIMARY KEY Identity,
    TiTle NVARCHAR(10),
    Content NTEXT,
    PublishTime DATETIME,
    Author NVARCHAR(10)

)
INSERT Content VALUES(N'标题-1',null,'2021-7-20',N'飞哥')
INSERT Content VALUES(N'标题-2',null,'2021-7-5',N'飞弟')
INSERT Content VALUES(N'标题-3',null,'2021-7-10',N'飞兄')
INSERT Content VALUES(N'标题-4',null,'2021-7-1',N'飞爷')
INSERT Content VALUES(N'标题-5',null,'2021-7-7',N'飞儿')
INSERT Content VALUES(N'标题-5',null,'2021-7-21',N'飞姐')
INSERT Content VALUES(N'标题-5',null,'2021-7-6',N'飞妹')
INSERT Content VALUES(N'标题-5',null,'2021-7-12',N'飞饼')
INSERT Content VALUES(N'标题-5',null,'2021-7-18',N'飞仔')
INSERT Content VALUES(N'标题-5',null,'2021-7-2',N'飞嫂')
CREATE TABLE Suggest(
    Id INT CONSTRAINT FK_Suggest_Id FOREIGN KEY(Id) REFERENCES Content(Id),
    Kind NVARCHAR(20),
)
INSERT Suggest VALUES(1,N'Suggest-1')
INSERT Suggest VALUES(4,N'Suggest-2')
INSERT Suggest VALUES(7,N'Suggest-3')
CREATE TABLE Article(
    Id INT CONSTRAINT FK_Article_Id FOREIGN KEY(Id) REFERENCES Content(Id),
    Category INT
)
ALTER TABLE Article ALTER COLUMN Category NVARCHAR(10)
INSERT Article VALUES(2,N'Article-1')
INSERT Article VALUES(3,N'Article-2')
INSERT Article VALUES(8,N'Article-3')
CREATE TABLE Problem0(
    Id INT CONSTRAINT FK_Problem0_Id FOREIGN KEY(Id) REFERENCES Content(Id),
    NeedRemoteHelp BIT,
    Reward INT
)
INSERT Problem0 VALUES(5,1,20)
INSERT Problem0 VALUES(6,1,25)
INSERT Problem0 VALUES(9,1,10)
INSERT Problem0 VALUES(10,0,15)
SELECT * FROM Content
SELECT * FROM Suggest
SELECT * FROM Article
SELECT * FROM Problem0
SELECT Title,Content,PublishTime,Author FROM Content 
ORDER BY PublishTime


--为求助添加一个发布时间（TPublishTime），使用子查询：
--1.删除每个作者悬赏最低的求助
ALTER TABLE keyword2Problem Drop FK_Keyword2Priblem_PID
SELECT * FROM Problem
BEGIN TRAN
DELETE Problem WHERE Id IN
(SELECT Id FROM(
   SELECT ROW_NUMBER() OVER(PARTITION BY Author ORDER BY Reward)AS SEQ,
   Id,Reward,Author FROM Problem)WS
WHERE WS.SEQ<=1)
COMMIT

--2.找到从未成为邀请人的用户
SELECT * FROM [User]
WHERE InvitedBy IS NULL

--3.如果一篇求助的关键字大于3个，将它的悬赏值翻倍//表有问题
UPDATE Problem SET Reward=2*Reward
WHERE Id IN(SELECT KID FROM Keyword2Problem
WHERE 3<=(SELECT COUNT(Keyword)FROM Keyword2Problem))
SELECT * FROM Keyword2
--4.查出所有发布一篇以上（不含一篇）文章的用户信息
SELECT * FROM [User] WHERE UserName IN(
SELECT Author FROM Problem ot
WHERE 2<=(SELECT COUNT(Title)FROM Problem it
WHERE ot.Author=it.Author))

--5.查找每个作者最近发布的一篇文章
SELECT * From Problem ot 
WHERE PublishDateTime=(SELECT MAX(PublishDateTime)FROM Problem it
WHERE ot.Author=it.Author)

--6.查出每一篇求助的悬赏都大于20个帮帮币的作者
SELECT Reward,Author FROM Problem ot 
WHERE 20<(SELECT MIN(Reward)FROM Problem it WHERE ot.Author=it.Author)
--派生表
SELECT * FROM(
SELECT Author,MIN(Reward)AS MIN FROM Problem
GROUP BY Author)NS
WHERE NS.MIN>20





--分别使用派生表和CTE，查询求助表（表中只有一列整体的发布时间，没有年月的列），以获得：
SELECT * FROM Problem;
--1.一起帮每月各发布了求助多少篇
WITH MonthedProblem
AS(
    SELECT 
    YEAR(PublishDateTime)AS PublishYear,
     YEAR(PublishDateTime)AS PublishMonth
    FROM Problem
)
SELECT PublishYear,PublishMonth,COUNT(*)AS COUNT FROM MonthedProblem
GROUP BY MonthedProblem.PublishYear,MonthedProblem.PublishMonth
--2.每月发布的求助中，悬赏最多的2篇
SELECT *FROM(
    SELECT ROW_NUMBER()OVER(PARTITION BY  YEAR(PublishDateTime), YEAR(PublishDateTime)
    ORDER BY Reward DESC) rn,*
    FROM Problem)NS
WHERE NS.rn<=2
--3.每个作者，每月发布的，悬赏最多的3篇
SELECT *FROM(
     SELECT ROW_NUMBER()OVER(PARTITION BY Author,
     YEAR(PublishDateTime),MONTH(PublishDateTime)
     ORDER BY Reward DESC) rn,*
     FROM Problem)NS
WHERE NS.rn<=2
--4.分别按发布时间和悬赏数量进行分页查询的结果
SELECT * FROM Problem
SELECT * FROM(
     SELECT  ROW_NUMBER()OVER(ORDER BY PublishDateTime)rn,*
     FROM Problem)NS
WHERE NS.rn BETWEEN 3 AND 5

SELECT * FROM Problem ORDER BY Reward
OFFSET 2 ROWS 
FETCH NEXT 3 ROWS ONLY

GO
