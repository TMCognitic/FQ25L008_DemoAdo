CREATE TABLE [dbo].[Personne]
(
	[Id] INT NOT NULL IDENTITY,
	[Nom] NVARCHAR(75) NOT NULL, 
    [Prenom] NVARCHAR(75) NOT NULL, 
    [Email] NVARCHAR(384) NOT NULL, 
    CONSTRAINT [PK_Personne] PRIMARY KEY ([Id]),
    CONSTRAINT [UK_Personne_Email] UNIQUE ([Email]),
)
