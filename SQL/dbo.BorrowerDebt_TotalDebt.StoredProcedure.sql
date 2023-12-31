USE [MoneFi]
GO
/****** Object:  StoredProcedure [dbo].[BorrowerDebt_TotalDebt]    Script Date: 6/23/2023 4:41:31 PM ******/
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



CREATE PROC [dbo].[BorrowerDebt_TotalDebt]
		    @CreatedBy int 
			, @TotalDebt float OUTPUT



as	

/*-------Test Code----------

Declare @CreatedBy int = 17
Declare @TotalDebt float 
		

Execute dbo.BorrowerDebt_TotalDebt
							@CreatedBy
							, @TotalDebt OUTPUT
SELECT @TotalDebt

*/


BEGIN


SET @TotalDebt = (SELECT SUM (HomeMortgage
       + CarPayments
       + CreditCard
       + OtherLoans) 
      


FROM [dbo].[BorrowerDebt]
WHERE CreatedBy = @CreatedBy)


END


GO
