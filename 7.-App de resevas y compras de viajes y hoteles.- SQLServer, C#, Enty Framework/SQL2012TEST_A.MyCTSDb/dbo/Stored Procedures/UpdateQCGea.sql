﻿



-- =============================================
-- Author:		Marcos Q. Ramirez Luna
-- Create date: 22 - 03 - 2010
-- Description:	Procedure that update values in Gea qualityControls
-- =============================================
CREATE Procedure [dbo].[UpdateQCGea]
 --Variables
    @ATTRIBUTE1 varchar(6),
	@C1 varchar(3),
	@C2 varchar(3),
	@C3 varchar(3),
	@C4 varchar(3),
	@C5 varchar(3),
	@C6 varchar(3),
	@C7 varchar(3),
	@C8 varchar(3),
	@C9 varchar(3),
	@C10 varchar(3),
	@C11 varchar(3),
	@C12 varchar(3),
	@C13 varchar(3),
	@C14 varchar(3),
	@C15 varchar(3),
	@C16 varchar(3),
	@C17 varchar(3),
	@C18 varchar(3),
	@C19 varchar(3),
	@C20 varchar(3),
	@C21 varchar(3),
	@C22 varchar(3),
	@C23 varchar(3),
	@C24 varchar(3),
	@C25 varchar(3),
	@C26 varchar(3),
	@C27 varchar(3),
	@C28 varchar(3),
	@C29 varchar(3),
	@C30 varchar(3),
	@C31 varchar(3),
	@C32 varchar(3),
	@C33 varchar(3),
	@C34 varchar(3),
	@C35 varchar(3),
	@C36 varchar(3),
	@C37 varchar(3),
	@C38 varchar(3),
	@C39 varchar(3),
	@C40 varchar(3),
	@C41 varchar(3),
	@C42 varchar(3),
	@C43 varchar(3),
	@C44 varchar(3),
	@C45 varchar(3),
	@C46 varchar(3),
	@C47 varchar(3),
	@C48 varchar(3),
	@C49 varchar(3),
	@C50 varchar(3),
	@C51 varchar(3),
	@C52 varchar(3),
	@C53 varchar(3),
	@C54 varchar(3),
	@C55 varchar(3),
	@C56 varchar(3),
	@C57 varchar(3),
	@C58 varchar(3),
	@C59 varchar(3),
	@C60 varchar(3),
	@C61 varchar(3),
	@C62 varchar(3),
	@C63 varchar(3),
	@C64 varchar(3),
	@C65 varchar(3),
	@C66 varchar(3),
	@C67 varchar(3),
	@C68 varchar(3),
	@C69 varchar(3),
	@C70 varchar(3),
	@C71 varchar(3),
	@C72 varchar(3),
	@C73 varchar(3),
	@C74 varchar(3),
	@C75 varchar(3),
	@C76 varchar(3),
	@C77 varchar(3),
	@C78 varchar(3),
	@C79 varchar(3),
	@C80 varchar(3),
	@C81 varchar(3),
	@C82 varchar(3),
	@C83 varchar(3),
	@C84 varchar(3),
	@C85 varchar(3),
	@C86 varchar(3),
	@C87 varchar(3),
	@C88 varchar(3),
	@C89 varchar(3),
	@C90 varchar(3),
	@C91 varchar(3),
	@C92 varchar(3),
	@C93 varchar(3),
	@C94 varchar(3),
	@C95 varchar(3),
	@C96 varchar(3),
	@C97 varchar(3),
	@C98 varchar(3),
	@C99 varchar(3),
	@C100 varchar(3)

AS
Begin
	update GEAP..GEA.CTS_TB_QUALITYCONTROLS
    set
    C1 = @C1, C2 = @C2, C3 = @C3, C4 = @C4, C5 = @C5, C6 = @C6, C7 = @C7, C8 = @C8, C9 = @C9, C10 = @C10,
	C11 = @C11, C12 = @C12, C13 = @C13, C14 = @C14, C15 = @C15, C16 = @C16, C17 = @C17, C18 = @C18, C19 = @C19, C20 = @C20,
    C21 = @C21, C22 = @C22, C23 = @C23, C24 = @C24, C25 = @C25, C26 = @C26, C27 = @C27, C28 = @C28, C29 = @C29, C30 = @C30,
    C31 = @C31, C32 = @C32, C33 = @C33, C34 = @C34, C35 = @C35, C36 = @C36, C37 = @C37, C38 = @C38, C39 = @C39, C40 = @C40,
    C41 = @C41, C42 = @C42, C43 = @C43, C44 = @C44, C45 = @C45, C46 = @C46, C47 = @C47, C48 = @C48, C49 = @C49, C50 = @C50,
    C51 = @C51, C52 = @C52, C53 = @C53, C54 = @C54, C55 = @C55, C56 = @C56, C57 = @C57, C58 = @C58, C59 = @C59, C60 = @C60,
    C61 = @C61, C62 = @C62, C63 = @C63, C64 = @C64, C65 = @C65, C66 = @C66, C67 = @C67, C68 = @C68, C69 = @C69, C70 = @C70,
    C71 = @C71, C72 = @C72, C73 = @C73, C74 = @C74, C75 = @C75, C76 = @C76, C77 = @C77, C78 = @C78, C79 = @C79, C80 = @C80,
    C81 = @C81, C82 = @C82, C83 = @C83, C84 = @C84, C85 = @C85, C86 = @C86, C87 = @C87, C88 = @C88, C89 = @C89, C90 = @C90,
    C91 = @C91, C92 = @C92, C93 = @C93, C94 = @C94, C95 = @C95, C96 = @C96, C97 = @C97, C98 = @C98, C99 = @C99, C100 = @C100
	where ATTRIBUTE1 = @ATTRIBUTE1
End





