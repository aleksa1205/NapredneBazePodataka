﻿namespace FragranceRecommendation.Services.UserService;

public interface IUserService
{
    public Task<bool> UserExistsAsync(string username);
    public Task<bool> UserOwnsFragranceAsync(string username, int id);
    public Task<IList<ReturnUserDto>> GetUsersAsync();
    public Task<User?> GetUserAsync(string username);
    public Task<PaginationInfiniteResponseDto> GetUserFragrancesPaginationAsync(string username, int page);
    public Task<ReturnUserDto?> GetUserDtoAsync(string username);
    public Task<User?> GetUserWithoutFragrancesAsync(string username);
    public Task AddUserAsync(AddUserDto user);
    public Task UpdateUserAsync(UpdateUserDto user);
    public Task AddFragranceToUserAsync(string username, int fragranceId);
    public Task DeleteFragranceFromUserAsync(string username, int fragranceId);
    public Task DeleteUserAsync(string username);
}