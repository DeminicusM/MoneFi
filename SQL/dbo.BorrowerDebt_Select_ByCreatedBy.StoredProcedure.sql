USE [MoneFi]
GO
/****** Object:  StoredProcedure [dbo].[BorrowerDebt_Select_ByCreatedBy]    Script Date: 6/23/2023 4:41:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: <Author,,Deminicus McKinnon>
-- Create date: <5/5/2023,,>
-- Description: <This is the selectby_createdby proc for BorrowerDebt,,>
-- Code Reviewer:

-- MODIFIED BY: author
-- MODIFIED DATE:12/1/2020
-- Code Reviewer: Dong hae Kim
-- Note:
-- =============================================



CREATE PROC [dbo].[BorrowerDebt_Select_ByCreatedBy]
		    @CreatedBy  int



as

/*-------Test Code----------

Declare @CreatedBy int = 2
		

Execute dbo.BorrowerDebt_Select_ByCreatedBy
							@CreatedBy

SELECT *
FROM dbo.BorrowerDebt
		
*/


BEGIN


SELECT [Id]
	  ,[HomeMortgage]
      ,[CarPayments]
      ,[CreditCard]
      ,[OtherLoans] 
	  ,[DateCreated]
	  ,[DateModified]
      ,[CreatedBy]
      ,[ModifiedBy]
FROM [dbo].[BorrowerDebt]
WHERE CreatedBy = @CreatedBy


END


GO
