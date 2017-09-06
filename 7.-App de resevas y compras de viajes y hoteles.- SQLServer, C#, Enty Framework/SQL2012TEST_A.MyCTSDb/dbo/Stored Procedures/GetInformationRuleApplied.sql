-- =============================================
-- Author:		Angel Trejo Arizmendi
-- Create date: 11-02-2010
-- Description:	Procedure that gets infromation from the rule applied
-- =============================================
CREATE Procedure [dbo].[GetInformationRuleApplied]
@NumberRule int, @Status bit
AS
Begin
		if @Status=1
		begin
		declare @Var2 as Bit
		set @Var2=0
		select null as DefaultFee,null as DefaultMount, @Var2 as Mandatory, [Value] as Value2 ,tres.Target
		from dbo.TargetElementsRules as dos,dbo.TargetElements as tres
		where dos.RuleNumber = @numberRule and tres.IDTE = dos.IDTE
		union
		select null as DefaultFee,null as DefaultMount,@Var2 as Mandatory, 'No especificado' as Value2, Target
		from dbo.TargetElementsRules as dos, dbo.TargetElements as tres
		where tres.IDTE not in (select tres.IDTE
							    from dbo.TargetElementsRules as dos,dbo.TargetElements as tres
							    where dos.RuleNumber = @numberRule and tres.IDTE = dos.IDTE)
		order by Target
		end
		else
		begin
			if exists(select * from dbo.TargetElementsRules where RuleNumber=@NumberRule)
	begin
		select DefaultFee, DefaultMount, Mandatory, [Value] as Value2 ,tres.Target
		from dbo.CorporativeFeesRules as uno, dbo.TargetElementsRules as dos,
		dbo.TargetElements as tres
		where uno.RuleNumber = @numberRule and dos.RuleNumber = @numberRule 
		and tres.IDTE = dos.IDTE
		order by Tres.Target
	end
else
	begin
		declare
		@var1 as varchar(1)
		select DefaultFee, DefaultMount, Mandatory, @var1 as Value2 ,@var1 as Target
		from dbo.CorporativeFeesRules 
		where RuleNumber = @NumberRule
	end
		end
End


