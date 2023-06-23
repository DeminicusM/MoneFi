USE [MoneFi]
GO
/****** Object:  StoredProcedure [dbo].[Notes_DeleteById]    Script Date: 6/23/2023 4:41:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author: <Author,,Deminicus McKinnon>
-- Create date: <5/17/2023,,>
-- Description: <This is the deletebyID proc for Notes,,>
-- Code Reviewer:

-- MODIFIED BY: author
-- MODIFIED DATE:12/1/2020
-- Code Reviewer: Mark Nella Jr.
-- Note:
-- =============================================


CREATE PROC [dbo].[Notes_DeleteById]
						   @Id int


as

/*--------Test Code--------

Declare @Id int = 2

Select LectureNotes
	  ,LectureId
From dbo.Notes
Where Id = @Id

Execute dbo.Notes_DeleteById
					  @Id

Select LectureNotes
	  ,LectureId
From dbo.Notes
Where Id = @Id

*/

BEGIN

DELETE FROM [dbo].[Notes]
	  WHERE Id = @Id


END

GO
