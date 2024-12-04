CREATE TABLE [dbo].[CarBrand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]



CREATE TABLE [dbo].[CarClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[CarModel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
	[ModelName] [nvarchar](100) NOT NULL,
	[ModelCode] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Features] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[DateOfManufacturing] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
	[SortOrder] [int] NOT NULL,
	[Images] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[CarModel]  WITH CHECK ADD  CONSTRAINT [FK_CarModel_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[CarBrand] ([Id])
GO

ALTER TABLE [dbo].[CarModel] CHECK CONSTRAINT [FK_CarModel_Brand]
GO

ALTER TABLE [dbo].[CarModel]  WITH CHECK ADD  CONSTRAINT [FK_CarModel_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[CarClass] ([Id])
GO

ALTER TABLE [dbo].[CarModel] CHECK CONSTRAINT [FK_CarModel_Class]


CREATE TABLE [dbo].[Sales](
	[Salesman] [int] NULL,
	[CarClassId] [int] NULL,
	[Audi] [int] NULL,
	[Jaguar] [int] NULL,
	[Land_Rover] [int] NULL,
	[Renault] [int] NULL
) ON [PRIMARY]


CREATE TABLE [dbo].[Salesman](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[LastYearSales] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

INSERT INTO CarBrand (Id, Name) VALUES (1, 'Audi');  
INSERT INTO CarBrand (Id, Name) VALUES (2, 'Jaguar');  
INSERT INTO CarBrand (Id, Name) VALUES (3, 'Land Rover');  
INSERT INTO CarBrand (Id, Name) VALUES (4, 'Renault');  


INSERT INTO CarClass (Id, Name) VALUES (1, 'A-Class');  
INSERT INTO CarClass (Id, Name) VALUES (2, 'B-Class');  
INSERT INTO CarClass (Id, Name) VALUES (3, 'C-Class');  


INSERT INTO CarModel (Id, BrandId, ClassId, ModelName, ModelCode, Description, Features, Price, DateOfManufacturing, Active, SortOrder, Images) VALUES   
(1, 1, 1, 'Audi A4', 'AUD12345', 'Luxury Sedan with advanced technology.', 'Sunroof, Leather seats, Navigation system', 35000.00, '2023-01-01 00:00:00.000', 1, 1, NULL),  
(2, 1, 2, 'Audi Q7', 'AUD12346', 'Premium SUV with spacious interior.', 'All-wheel drive, Sunroof, Heated seats', 55000.00, '2022-06-15 00:00:00.000', 1, 2, NULL),  
(4, 2, 2, 'Jaguar XF', 'JAG12346', 'Sedan with high performance and elegant design.', 'Sunroof, Leather seats, Adaptive cruise control', 45000.00, '2021-11-05 00:00:00.000', 1, 3, NULL),  
(5, 3, 1, 'Land Rover Range Rover', 'LR12345', 'High-performance luxury SUV with off-road capability.', 'Leather seats, Sunroof, All-wheel drive', 75000.00, '2024-02-10 00:00:00.000', 1, 1, NULL),  
(6, 3, 3, 'Land Rover Discovery', 'LR12346', 'Versatile off-road SUV with modern amenities.', 'All-terrain tires, Leather seats, Navigation', 65000.00, '2023-08-22 00:00:00.000', 1, 2, NULL),  
(7, 4, 1, 'Renault Captur', 'RE12345', 'Compact SUV with efficient fuel consumption.', 'Bluetooth connectivity, Backup camera, Sunroof', 30000.00, '2022-03-18 00:00:00.000', 1, 1, NULL),  
(8, 4, 2, 'Renault Koleos', 'RE12346', 'SUV with spacious interior and smooth ride.', 'Leather seats, Bluetooth, All-wheel drive', 40000.00, '2021-12-01 00:00:00.000', 1, 2, NULL),  
(10, 2, 1, 'F-Pace', 'F-Pace', 'Luxury Sedan with advanced technology.', 'Sunroof, Leather seats, Navigation system', 40000.00, '2024-12-04 00:00:00.000', 1, 4, NULL);  




INSERT INTO Sales (Salesman, CarClassId, Audi, Jaguar, Land_Rover, Renault) VALUES   
(1, 1, 1, 3, 0, 6),  
(1, 2, 2, 4, 2, 2),  
(1, 3, 3, 6, 1, 1),  
(2, 1, 0, 5, 5, 3),  
(2, 2, 0, 4, 2, 2),  
(2, 3, 0, 2, 1, 1),  
(3, 1, 4, 2, 1, 6),  
(3, 2, 2, 7, 2, 3),  
(3, 3, 0, 1, 3, 1);


INSERT INTO Salesman (Id, Name, LastYearSales) VALUES   
(1, 'Salesman 1 (John Smith)', 490000.00),  
(2, 'Salesman 2 (Richard Porter)', 1000000.00),  
(3, 'Salesman 3 (Tony Grid)', 650000.00); 
