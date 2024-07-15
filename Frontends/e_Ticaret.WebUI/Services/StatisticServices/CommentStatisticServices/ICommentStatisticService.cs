﻿namespace e_Ticaret.WebUI.Services.StatisticServices.CommentStatisticServices;

public interface ICommentStatisticService
{
    Task<int> GetActiveCommentCount();
    Task<int> GetPassiveCommentCount();
    Task<int> GetCommentCount();
}
