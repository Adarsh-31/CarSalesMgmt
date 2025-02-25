USE [CarSalesMgntDb]
GO
/****** Object:  StoredProcedure [dbo].[InsertCarDetails]    Script Date: 05-12-2024 01:54:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[InsertCarDetails]
    @BrandId INT,
    @ClassId INT,
    @ModelName NVARCHAR(100),
    @ModelCode NVARCHAR(50),
    @Description NVARCHAR(MAX),
    @Features NVARCHAR(MAX),
    @Price DECIMAL(18, 2),
    @DateOfManufacturing DATE,
    @Active BIT,
    @SortOrder INT,
    @Images VARBINARY(MAX)
AS
BEGIN
        INSERT INTO CarModel (
            BrandId,
            ClassId,
            ModelName,
            ModelCode,
            Description,
            Features,
            Price,
            DateOfManufacturing,
            Active,
            SortOrder,
            Images
        )
        VALUES (
            @BrandId,
            @ClassId,
            @ModelName,
            @ModelCode,
            @Description,
            @Features,
            @Price,
            @DateOfManufacturing,
            @Active,
            @SortOrder,
            @Images
        );
END;