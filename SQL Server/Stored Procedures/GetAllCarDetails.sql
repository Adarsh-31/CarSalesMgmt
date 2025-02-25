USE [CarSalesMgntDb]
GO
/****** Object:  StoredProcedure [dbo].[GetAllCarDetails]    Script Date: 05-12-2024 01:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC GetAllCarDetails 'F'
ALTER PROCEDURE [dbo].[GetAllCarDetails]
    @SearchTerm NVARCHAR(100) = NULL 
AS
BEGIN
        SELECT
            B.Name AS BrandName,
            CC.Name AS ClassName,
            CM.ModelName,
            CM.ModelCode,
            CM.Description,
            CM.Features,
            CM.Price,
            CM.DateOfManufacturing,
            CM.Images
        FROM CarModel CM
        INNER JOIN CarBrand B ON CM.BrandId = B.Id
        INNER JOIN CarClass CC ON CM.ClassId = CC.Id
        WHERE
            (@SearchTerm IS NULL OR
             CM.ModelName LIKE '%' + @SearchTerm + '%' OR
             CM.ModelCode LIKE '%' + @SearchTerm + '%')
        ORDER BY
            CM.DateOfManufacturing DESC,
            CM.SortOrder ASC;
END;