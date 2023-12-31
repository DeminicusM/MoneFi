USE [MoneFi]
GO
/****** Object:  StoredProcedure [dbo].[Notes_Select_ByLectureIdByCreatedBy]    Script Date: 6/23/2023 4:41:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author: <Author,,Deminicus McKinnon>
-- Create date: <5/17/2023,,>
-- Description: <This is the selectByLectureIdByCreatedBy proc for Notes,,>
-- Code Reviewer:

-- MODIFIED BY: author
-- MODIFIED DATE:12/1/2020
-- Code Reviewer: Mark Nella Jr
-- Note:
-- =============================================


CREATE PROC [dbo].[Notes_Select_ByLectureIdByCreatedBy] 
						          @LectureId int
								 ,@CreatedBy int

as

/*--------Test Code--------


Declare @LectureId int =22
Declare @CreatedBy int = 22

Execute dbo.Notes_Select_ByLectureIdByCreatedBy 
					             @LectureId
							    ,@CreatedBy


Select LectureNotes
	  ,LectureId
From dbo.Notes
Where LectureId = @LectureId

*/

BEGIN



SELECT Id
	  ,LectureNotes
	  ,LectureId
	  ,Tags = (
	   SELECT T.Id, T.Name 
		From dbo.Tags as T
		INNER JOIN dbo.EntityTags as ET on ET.TagId = T.Id
	   Where ET.EntityId = N.Id
	   For JSON Auto 
	  )
	  ,CreatedBy
FROM dbo.Notes as N
WHERE N.LectureId = @LectureId and N.CreatedBy = @CreatedBy
	

END

GO
