USE [MoneFi]
GO
/****** Object:  Table [dbo].[BorrowerDebt]    Script Date: 6/23/2023 4:41:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorrowerDebt](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HomeMortgage] [decimal](10, 2) NULL,
	[CarPayments] [decimal](10, 2) NULL,
	[CreditCard] [decimal](10, 2) NOT NULL,
	[OtherLoans] [decimal](10, 2) NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
 CONSTRAINT [PK_BorrowerDebt] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BorrowerDebt] ADD  CONSTRAINT [DF_BorrowerDebt_DateCreated]  DEFAULT (getutcdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[BorrowerDebt] ADD  CONSTRAINT [DF_BorrowerDebt_DateModified]  DEFAULT (getutcdate()) FOR [DateModified]
GO
