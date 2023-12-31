USE [MoneFi]
GO
/****** Object:  StoredProcedure [dbo].[BorrowerDebt_Update]    Script Date: 6/23/2023 4:41:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: <Author,,Deminicus McKinnon>
-- Create date: <5/5/2023,,>
-- Description: <This is the update proc for BorrowerDebt,,>
-- Code Reviewer:

-- MODIFIED BY: author
-- MODIFIED DATE:12/1/2020
-- Code Reviewer: Dong hae Kim
-- Note: 
-- =============================================



CREATE PROC [dbo].[BorrowerDebt_Update]
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

Declare 	@HomeMortgage decimal(10,2) =
           ,@CarPayments decimal(10,2) =
           ,@CreditCard decimal(10,2) =
           ,@OtherLoans decimal(10,2) =
           ,@CreatedBy int =
           ,@ModifiedBy int =
		   
Select HomeMortgage
	  ,CarPayments 
	  ,CreditCard 
	  ,OtherLoans 
	  ,CreatedBy 
	  ,ModifiedBy
From  dbo.BorrowerDebt
Where Id = 1
		

Execute dbo.BorrowerDebt_Update
							@HomeMortgage
						   ,@CarPayments 
						   ,@CreditCard 
						   ,@OtherLoans 
						   ,@CreatedBy 
						   ,@ModifiedBy

Select HomeMortgage
	  ,CarPayments 
	  ,CreditCard 
	  ,OtherLoans 
	  ,CreatedBy 
	  ,ModifiedBy
From  dbo.BorrowerDebt
Where Id = 1
		
*/


BEGIN



UPDATE [dbo].[BorrowerDebt]
   SET [HomeMortgage] = @HomeMortgage
      ,[CarPayments] = @CarPayments 
      ,[CreditCard] = @CreditCard
      ,[OtherLoans] = @OtherLoans
      ,[CreatedBy] = @CreatedBy 
      ,[ModifiedBy] = @ModifiedBy
WHERE Id = @Id


END


GO
