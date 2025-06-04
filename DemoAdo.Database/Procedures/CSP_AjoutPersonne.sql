CREATE PROCEDURE [dbo].[CSP_AjoutPersonne]
	@Nom NVARCHAR(75),
	@Prenom NVARCHAR(75),
	@Email NVARCHAR(384),
	@Tel NVARCHAR(20) = null
AS
BEGIN

	BEGIN TRY
		IF @Nom IS NULL
			RAISERROR ('Le paramètre @Nom est invalide', 16, 1);

		IF @Prenom IS NULL
			RAISERROR ('Le paramètre @Prenom est invalide', 16, 1);

		IF @Email IS NULL
			RAISERROR ('Le paramètre @Email est invalide', 16, 1);

		IF EXISTS(SELECT * FROM Personne WHERE Email = @Email)
			RAISERROR ('L''adresse email est déjà utilisée', 16, 1);

		INSERT INTO Personne (Nom, Prenom, Email, Tel) VALUES (@Nom, @Prenom, @Email, @Tel);
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
		DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
		DECLARE @ErrorState INT = ERROR_STATE();

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH


END
	
