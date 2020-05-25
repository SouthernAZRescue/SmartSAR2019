namespace SSar.BC.Common.Application.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        bool IsAuthenticated { get; }
    }
}

// Credit: Jason Taylor, https://github.com/jasontaylordev/NorthwindTraders