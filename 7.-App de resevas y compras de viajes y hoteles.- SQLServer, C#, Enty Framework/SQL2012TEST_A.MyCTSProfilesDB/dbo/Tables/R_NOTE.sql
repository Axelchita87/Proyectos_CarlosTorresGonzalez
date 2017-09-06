CREATE TABLE [dbo].[R_NOTE] (
    [ID_NOTE]                      BIGINT   NOT NULL,
    [VALUE_STR]                    TEXT     NULL,
    [GUI_LOCATION_X]               INT      NULL,
    [GUI_LOCATION_Y]               INT      NULL,
    [GUI_LOCATION_WIDTH]           INT      NULL,
    [GUI_LOCATION_HEIGHT]          INT      NULL,
    [FONT_NAME]                    TEXT     NULL,
    [FONT_SIZE]                    INT      NULL,
    [FONT_BOLD]                    CHAR (1) NULL,
    [FONT_ITALIC]                  CHAR (1) NULL,
    [FONT_COLOR_RED]               INT      NULL,
    [FONT_COLOR_GREEN]             INT      NULL,
    [FONT_COLOR_BLUE]              INT      NULL,
    [FONT_BACK_GROUND_COLOR_RED]   INT      NULL,
    [FONT_BACK_GROUND_COLOR_GREEN] INT      NULL,
    [FONT_BACK_GROUND_COLOR_BLUE]  INT      NULL,
    [FONT_BORDER_COLOR_RED]        INT      NULL,
    [FONT_BORDER_COLOR_GREEN]      INT      NULL,
    [FONT_BORDER_COLOR_BLUE]       INT      NULL,
    [DRAW_SHADOW]                  CHAR (1) NULL,
    PRIMARY KEY CLUSTERED ([ID_NOTE] ASC)
);

