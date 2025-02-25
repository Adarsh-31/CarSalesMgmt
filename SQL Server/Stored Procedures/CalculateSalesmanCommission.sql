USE [CarSalesMgntDb]
GO
/****** Object:  StoredProcedure [dbo].[CalculateSalesmanCommission]    Script Date: 05-12-2024 01:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC CalculateSalesmanCommission  
ALTER PROCEDURE [dbo].[CalculateSalesmanCommission]  
AS  
BEGIN  
    CREATE TABLE #CommissionReport (  
        SalesmanName NVARCHAR(100),  
        TotalCommission DECIMAL(18, 2)  
    );  

    INSERT INTO #CommissionReport (SalesmanName, TotalCommission)  
    SELECT   
        sm.Name AS SalesmanName,  
        SUM(  
            CASE   
                WHEN cm.BrandId = 1 AND cm.Price > 25000 THEN 800 * (  
                    CASE   
                        WHEN sa.CarClassId = 1 THEN sa.Audi  
                        WHEN sa.CarClassId = 2 THEN sa.Audi  
                        WHEN sa.CarClassId = 3 THEN sa.Audi  
                        ELSE 0  
                    END  
                ) 
                WHEN cm.BrandId = 2 AND cm.Price > 35000 THEN 750 * (  
                    CASE   
                        WHEN sa.CarClassId = 1 THEN sa.Jaguar  
                        WHEN sa.CarClassId = 2 THEN sa.Jaguar  
                        WHEN sa.CarClassId = 3 THEN sa.Jaguar  
                        ELSE 0  
                    END  
                )
                WHEN cm.BrandId = 3 AND cm.Price > 30000 THEN 850 * (  
                    CASE   
                        WHEN sa.CarClassId = 1 THEN sa.Land_Rover  
                        WHEN sa.CarClassId = 2 THEN sa.Land_Rover  
                        WHEN sa.CarClassId = 3 THEN sa.Land_Rover  
                        ELSE 0  
                    END  
                )
                WHEN cm.BrandId = 4 AND cm.Price > 20000 THEN 400 * (  
                    CASE   
                        WHEN sa.CarClassId = 1 THEN sa.Renault  
                        WHEN sa.CarClassId = 2 THEN sa.Renault  
                        WHEN sa.CarClassId = 3 THEN sa.Renault  
                        ELSE 0  
                    END  
                )
                ELSE 0  
            END  
        ) +  
        SUM(   
            CASE   
                WHEN cm.BrandId = 1 AND sa.CarClassId = 1 THEN cm.Price * 0.08 * sa.Audi
                WHEN cm.BrandId = 1 AND sa.CarClassId = 2 THEN cm.Price * 0.06 * sa.Audi
                WHEN cm.BrandId = 1 AND sa.CarClassId = 3 THEN cm.Price * 0.04 * sa.Audi

                WHEN cm.BrandId = 2 AND sa.CarClassId = 1 THEN cm.Price * 0.06 * sa.Jaguar
                WHEN cm.BrandId = 2 AND sa.CarClassId = 2 THEN cm.Price * 0.05 * sa.Jaguar  
                WHEN cm.BrandId = 2 AND sa.CarClassId = 3 THEN cm.Price * 0.03 * sa.Jaguar 

                WHEN cm.BrandId = 3 AND sa.CarClassId = 1 THEN cm.Price * 0.07 * sa.Land_Rover
                WHEN cm.BrandId = 3 AND sa.CarClassId = 2 THEN cm.Price * 0.05 * sa.Land_Rover
                WHEN cm.BrandId = 3 AND sa.CarClassId = 3 THEN cm.Price * 0.04 * sa.Land_Rover 

                WHEN cm.BrandId = 4 AND sa.CarClassId = 1 THEN cm.Price * 0.05 * sa.Renault
                WHEN cm.BrandId = 4 AND sa.CarClassId = 2 THEN cm.Price * 0.03 * sa.Renault
                WHEN cm.BrandId = 4 AND sa.CarClassId = 3 THEN cm.Price * 0.02 * sa.Renault 
                ELSE 0  
            END  
        ) +  
        SUM(  
            CASE   
                WHEN sa.CarClassId = 1 AND sm.LastYearSales > 500000 THEN cm.Price * 0.02 * (  
                    CASE   
                        WHEN cm.BrandId = 1 THEN sa.Audi  
                        WHEN cm.BrandId = 2 THEN sa.Jaguar  
                        WHEN cm.BrandId = 3 THEN sa.Land_Rover  
                        WHEN cm.BrandId = 4 THEN sa.Renault  
                        ELSE 0  
                    END  
                )  
                ELSE 0  
            END  
        ) AS TotalCommission  
    FROM   
        Sales sa  
    INNER JOIN   
        Salesman sm ON sa.Salesman = sm.Id  
    INNER JOIN   
        CarModel cm ON sa.CarClassId = cm.ClassId  
    INNER JOIN   
        CarClass cc ON sa.CarClassId = cc.Id  
    GROUP BY   
        sm.Name;  

    SELECT * FROM #CommissionReport;  
    DROP TABLE #CommissionReport;  
END;