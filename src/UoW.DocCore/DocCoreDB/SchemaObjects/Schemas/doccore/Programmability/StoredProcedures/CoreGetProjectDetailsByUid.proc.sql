USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreGetProjectDetailsByUid]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreGetProjectDetailsByUid]
END

GO


CREATE PROCEDURE [doccore].[CoreGetProjectDetailsByUid] 
	@Uid int
AS
if (@Uid in (select ManagerID from [doccore].[ProjectManager]))
begin

select projectID,projectName from [doccore].[Project] a,[doccore].[ProjectManager] b where a.projectID =b.pID and b.ManagerID =@Uid ;
end
else if(@Uid in (select memberID from [doccore].[Members]))
begin
select projectID,projectName from [doccore].[Project] a, [doccore].[Members] b where a.projectID =b.pID and b.memberID =@Uid ;
end


GO

--EXEC [doccore].[CoreGetProjectDetailsByUid] @Uid= 5

----elect * from [doccore].[ProjectManager]
--select * from [doccore].[Members]