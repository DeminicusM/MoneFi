USE [MoneFi]
GO
/****** Object:  StoredProcedure [dbo].[Notes_Insert]    Script Date: 6/23/2023 4:41:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author: <Author,,Deminicus McKinnon>
-- Create date: <5/17/2023,,>
-- Description: <This is the insert proc for Notes,,>
-- Code Reviewer:

-- MODIFIED BY: author
-- MODIFIED DATE:12/1/2020
-- Code Reviewer: Mark Nella Jr.
-- Note:
-- =============================================


CREATE PROC [dbo].[Notes_Insert]
							@LectureNotes nvarchar(MAX)
				           ,@LectureId int
						   ,@CreatedBy int
						   ,@Id int OUTPUT


as

/*--------Test Code--------

Declare @Id int = 0

Declare  @LectureNotes nvarchar(MAX) = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Non consectetur a erat nam at lectus urna. Malesuada fames ac turpis egestas integer. Dignissim diam quis enim lobortis scelerisque fermentum dui faucibus in. Sem nulla pharetra diam sit amet nisl suscipit adipiscing. Risus ultricies tristique nulla aliquet enim tortor. Eu non diam phasellus vestibulum. Amet dictum sit amet justo donec enim diam vulputate. Ridiculus mus mauris vitae ultricies leo integer. Mauris pellentesque pulvinar pellentesque habitant. Dui accumsan sit amet nulla facilisi. Varius vel pharetra vel turpis nunc eget lorem dolor. Leo urna molestie at elementum. Pharetra sit amet aliquam id. Sem nulla pharetra diam sit amet. Suscipit adipiscing bibendum est ultricies integer quis. 
Amet porttitor eget dolor morbi non arcu risus. A condimentum vitae sapien pellentesque habitant morbi.'
		,@LectureId int = 25
		,@CreatedBy int = 25

Execute dbo.Notes_Insert
					@LectureNotes 
				   ,@LectureId
				   ,@CreatedBy
				   ,@Id OUTPUT

Select LectureNotes
	  ,LectureId
From dbo.Notes
Where Id = @Id

*/

BEGIN

INSERT INTO [dbo].[Notes]
           ([LectureNotes]
           ,[LectureId]
		   ,[CreatedBy])
     VALUES
           (@LectureNotes
           ,@LectureId
		   ,@CreatedBy) 
SET @Id = SCOPE_IDENTITY()


END

GO
