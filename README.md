1. Preparing Database
   CREATE TABLE [dbo].[users](
	[uid] [uniqueidentifier] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[email] [nvarchar](150) NOT NULL,
	[hashed_password] [nvarchar](150) NOT NULL,
	[salt] [nvarchar](150) NOT NULL,
	[created_at] [datetime] NOT NULL,
	[status] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[vehicles](
	[uid] [uniqueidentifier] NOT NULL,
	[plate_no] [varchar](50) NOT NULL,
	[brand] [varchar](50) NOT NULL,
	[color] [varchar](50) NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_vehicles] PRIMARY KEY CLUSTERED 
(
	[uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
