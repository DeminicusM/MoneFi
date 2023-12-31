USE [MoneFi]
GO
/****** Object:  StoredProcedure [dbo].[BorrowerDebt_DeleteById]    Script Date: 6/23/2023 4:41:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: <Author,,Deminicus McKinnon>
-- Create date: <5/5/2023,,>
-- Description: <This is the delet proc for BorrowerDebt,,>
-- Code Reviewer:

-- MODIFIED BY: author
-- MODIFIED DATE: 12/1/20
-- Code Reviewer: Dong hae Kim
-- Note:
-- =============================================



CREATE PROC [dbo].[BorrowerDebt_DeleteById]
		    @Id int



as

/*-------Test Code----------

Declare @Id int = 2


		   
Select HomeMortgage
	  ,CarPayments 
	  ,CreditCard 
	  ,OtherLoans 
	  ,CreatedBy 
	  ,ModifiedBy
From  dbo.BorrowerDebt
Where Id = @Id;
		

Execute dbo.BorrowerDebt_DeleteById
							@Id
Select HomeMortgage
	  ,CarPayments 
	  ,CreditCard 
	  ,OtherLoans 
	  ,CreatedBy 
	  ,ModifiedBy
From  dbo.BorrowerDebt
Where Id = @Id;
		
*/


BEGIN



DELETE FROM [dbo].[BorrowerDebt]
	   WHERE Id = @Id;


END


GO
