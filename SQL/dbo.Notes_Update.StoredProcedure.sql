USE [MoneFi]
GO
/****** Object:  StoredProcedure [dbo].[Notes_Update]    Script Date: 6/23/2023 4:41:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author: <Author,,Deminicus McKinnon>
-- Create date: <5/17/2023,,>
-- Description: <This is the update proc for Notes,,>
-- Code Reviewer:

-- MODIFIED BY: author
-- MODIFIED DATE:12/1/2020
-- Code Reviewer: Mark Nella Jr.
-- Note:
-- =============================================


CREATE PROC [dbo].[Notes_Update]
							@LectureNotes nvarchar(MAX)
						   ,@Id int OUTPUT


as

/*--------Test Code--------

Declare @Id int = 3

Declare  @LectureNotes nvarchar(MAX) = 'This is a new blue note test'


Execute dbo.Notes_Update
					 @LectureNotes 
					,@Id

Select LectureNotes
	  ,LectureId
From dbo.Notes
Where Id = @Id

*/

BEGIN

UPDATE [dbo].[Notes]
SET	   [LectureNotes] = @LectureNotes
WHERE Id = @Id


END

GO
