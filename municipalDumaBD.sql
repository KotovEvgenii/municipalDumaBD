CREATE DATABASE MunicipalDuma
GO

USE MunicipalDuma
GO

CREATE TABLE f_person 
(
 f_person		int				IDENTITY NOT NULL,
 name			varchar(50)		NULL,
 surname		varchar(100)	NULL,
 address		varchar(255)	NULL,
 phone_number	varchar(20)		NULL,
 CONSTRAINT pk_f_person PRIMARY KEY (f_person)
)
GO


CREATE TABLE f_comission 
(
 f_comission			int				IDENTITY NOT NULL,
 name					varchar(512)	NOT NULL,
 CONSTRAINT pk_f_comission PRIMARY KEY (f_comission)
)
GO

CREATE TABLE f_meeting 
(
 f_meeting			int				IDENTITY NOT NULL,
 f_comission		int				NOT NULL,
 date_time			datetime		NULL DEFAULT GETDATE(),
 place				varchar(100)	NULL
 CONSTRAINT pk_f_meeting PRIMARY KEY (f_meeting),
 CONSTRAINT fk_f_meet_f_comission FOREIGN KEY (f_comission) REFERENCES f_comission (f_comission)
)
GO

CREATE TABLE l_comission_person 
(
 l_comission_person			int				IDENTITY NOT NULL,
 f_comission				int				NOT NULL,
 f_person					int				NOT NULL,
 stat						int				default 0,  -- 0 активный участник или 1 - удалён
 stat_main					int				default 0,  -- 1 председатель, 0-обычный
 date_begin					datetime		NULL,
 date_end					datetime		NULL,
 CONSTRAINT pk_l_comission_person PRIMARY KEY (l_comission_person),
 CONSTRAINT fk_lcp_f_comission FOREIGN KEY (f_comission) REFERENCES f_comission (f_comission),
 CONSTRAINT fk_lcp_f_person FOREIGN KEY (f_person) REFERENCES f_person (f_person)
)
GO

CREATE TABLE l_meeting_work
(
 l_meeting_work				int				IDENTITY NOT NULL,
 f_meeting					int				NOT NULL,
 f_person					int				NOT NULL,
 isAbsent					bit				NOT NULL,
 CONSTRAINT pk_l_meeting_work PRIMARY KEY (l_meeting_work),
 CONSTRAINT fk_l_meet_work_f_meeting FOREIGN KEY (f_meeting) REFERENCES f_meeting (f_meeting),
 CONSTRAINT fk_l_meet_work_f_person FOREIGN KEY (f_person) REFERENCES f_person (f_person)
)
GO

INSERT INTO f_comission
VALUES
('Комиссия по делам молодёжи'),
('Комиссия по жилищному хозяйству'),
('Комиссия по спорту'),
('Комиссия по еде'),
('Комиссия по воде')
GO

INSERT INTO f_person
VALUES
('Иван', 'Иванов', 'Саратов', '89171112211'),
('Петр', 'Петров', 'Саратов', '89171112235'),
('Сергей', 'Сергеев', 'Алгай', '89171112244'),
('Евгений', 'Морозов', 'Ровное', '89171112288'),
('Роман', 'Романов', 'Балашов', '89171112354'),
('Максим', 'Максимов', 'Жирновск', '89171114255'),
('Константин', 'Констатинов', 'Вольск', '89171112789'),
('Мурат', 'Муратов', 'Кочетное', '89171112790'),
('Игорь', 'Иванов', 'Степное', '89171112881')
GO

INSERT INTO f_meeting  
VALUES
(1, '20210109', 'Университет'),
(1, '20210201', 'Школа'),
(1, '20210501', 'Колледж'),
(2, '20210115', 'Подвал'),
(2, '20210308', 'Крыша дома'),
(2, '20210628', 'Окраины города'),
(3, '20210215', 'Спортплощадка №1'),
(3, '20210217', 'Спортплощадка №2'),
(3, '20211011', 'Спортплощадка №3'),
(4, '20210102', 'За столом'),
(4, '20210223', 'За столом'),
(4, '20210308', 'За столом'),
(4, '20210501', 'На природе'),
(4, '20210601', 'За столом')
GO

INSERT INTO l_comission_person
VALUES
(1, 1, 0, 1, '20210101', NULL),
(1, 2, 0, 0, '20210101', NULL),
(1, 3, 0, 0, '20210101', NULL),
(2, 1, 0, 0, '20210101', NULL),
(2, 4, 0, 1, '20210101', NULL),
(3, 5, 0, 1, '20210201', NULL),
(3, 6, 1, 0, '20210201', '20210301'),
(3, 7, 0, 0, '20210201', NULL),
(4, 6, 0, 1, '20210220', NULL),
(4, 7, 0, 0, '20210220', NULL),
(4, 8, 0, 0, '20210220', NULL),
(4, 1, 0, 0, '20210220', NULL),
(5, 2, 1, 0, '20210401', '20210501'),
(5, 3, 1, 1, '20210401', '20210501'),
(5, 7, 0, 0, '20210401', NULL),
(5, 8, 0, 1, '20210401', NULL)
GO

INSERT INTO l_meeting_work
 VALUES
 (1, 1, 0), 
 (2, 1, 0), 
 (3, 1, 0),
 (1, 2, 0), 
 (2, 2, 0), 
 (3, 2, 1),
 (1, 3, 1), 
 (2, 3, 1), 
 (3, 3, 1),
 (4, 1, 0), 
 (5, 1, 0),
 (6, 1, 1),
 (4, 4, 0), 
 (5, 4, 0),
 (6, 4, 1),
 (7, 5, 0), 
 (8, 5, 0),
 (9, 5, 0),
 (7, 6, 0), 
 (8, 6, 1),
 (7, 7, 1), 
 (8, 7, 0),
 (9, 7, 0), 
 (10, 6, 0), 
 (11, 6, 1),
 (12, 6, 1), 
 (13, 6, 0),
 (14, 6, 0), 
 (10, 7, 0), 
 (11, 7, 0),
 (12, 7, 0), 
 (13, 7, 0),
 (14, 7, 0), 
 (10, 8, 1), 
 (11, 8, 0),
 (12, 8, 0), 
 (13, 8, 0),
 (14, 8, 0),
 (11, 1, 0),
 (12, 1, 0), 
 (13, 1, 0),
 (14, 1, 1)
 GO




--Scaffold-DbContext "Server=DESKTOP-SN5T4D0;Database=MunicipalDuma;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models


