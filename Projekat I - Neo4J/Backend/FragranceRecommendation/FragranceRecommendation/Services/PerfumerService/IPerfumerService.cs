﻿namespace FragranceRecommendation.Services.PerfumerService;

public interface IPerfumerService
{
    public Task<bool> PerfumerExistsAsync(int id);
    public Task<bool> IsFragranceCreatedByPerfumer(int perfumerId, int fragranceId);
    public Task<IList<INode>> GetPerfumersAsync();
    public Task<Perfumer> GetPerfumerAsync(int id);
    public Task AddPerfumerAsync(AddPerfumerDto perfumer);
    public Task UpdatePerfumerAsync(UpdatePerfumerDto perfumer);
    public Task AddFragranceToPerfumerAsync(AddFragranceToPerfumer dto);
    public Task DeletePerfumerAsync(DeletePerfumerDto perfumer);
}