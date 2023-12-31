USE [MoneFi]
GO
/****** Object:  StoredProcedure [dbo].[BorrowerDebt_Insert]    Script Date: 6/23/2023 4:41:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: <Author,,Deminicus McKinnon>
-- Create date: <5/5/2023,,>
-- Description: <This is the insert proc for BorrowerDebt,,>
-- Code Reviewer:

-- MODIFIED BY: author
-- MODIFIED DATE:12/1/2020
-- Code Reviewer: Dong hae Kim
-- Note:
-- =============================================



CREATE PROC [dbo].[BorrowerDebt_Insert]
			@HomeMortgage decimal(10,2)
           ,@CarPayments decimal(10,2)
           ,@CreditCard decimal(10,2)
           ,@OtherLoans decimal(10,2)
           ,@CreatedBy int
           ,@ModifiedBy int
		   ,@Id int OUTPUT



as

/*-------Test Code----------

Declare @Id int = 0

Declare 	@HomeMortgage decimal(10,2) = 200
           ,@CarPayments decimal(10,2) = 400
           ,@CreditCard decimal(10,2) = 600
           ,@OtherLoans decimal(10,2) = 800
           ,@CreatedBy int = 15	
           ,@ModifiedBy int = 15
		   

Execute dbo.BorrowerDebt_Insert
							@HomeMortgage
						   ,@CarPayments 
						   ,@CreditCard 
						   ,@OtherLoans 
						   ,@CreatedBy 
						   ,@ModifiedBy
						   ,@Id OUTPUT


Select HomeMortgage
	  ,CarPayments 
	  ,CreditCard 
	  ,OtherLoans 
	  ,CreatedBy 
	  ,ModifiedBy
From  dbo.BorrowerDebt
Where Id = @Id
		
*/


BEGIN



INSERT INTO [dbo].[BorrowerDebt]
           ([HomeMortgage]
           ,[CarPayments]
           ,[CreditCard]
           ,[OtherLoans]
           ,[CreatedBy]
           ,[ModifiedBy])
     VALUES
          (@HomeMortgage
           ,@CarPayments 
           ,@CreditCard 
           ,@OtherLoans 
           ,@CreatedBy 
           ,@ModifiedBy)

SET @Id = SCOPE_IDENTITY()


END


GO
