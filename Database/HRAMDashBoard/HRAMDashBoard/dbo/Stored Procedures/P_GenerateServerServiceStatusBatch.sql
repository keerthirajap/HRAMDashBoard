



CREATE PROC [dbo].[P_GenerateServerServiceStatusBatch] 
		@UserId bigint
		
  AS
begin

INSERT INTO [dbo].[ServerStatusBatch]
           ([CreatedOn]
           ,[CreatedBy]
           ,[ModifiedOn]
           ,[ModifiedBy])
		   SELECT GETDATE() 
		   ,@UserId
			,GETDATE() 
		   ,@UserId

	DECLARE @ID BIGINT = SCOPE_IDENTITY()

	SELECT @ID
	
end







