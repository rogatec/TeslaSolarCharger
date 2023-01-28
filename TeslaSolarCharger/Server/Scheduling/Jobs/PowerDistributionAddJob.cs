﻿using Quartz;
using TeslaSolarCharger.Server.Contracts;

namespace TeslaSolarCharger.Server.Scheduling.Jobs;

[DisallowConcurrentExecution]
public class PowerDistributionAddJob : IJob
{
    private readonly ILogger<PowerDistributionAddJob> _logger;
    private readonly IChargingCostService _service;

    public PowerDistributionAddJob(ILogger<PowerDistributionAddJob> logger, IChargingCostService service)
    {
        _logger = logger;
        _service = service;
    }
    public async Task Execute(IJobExecutionContext context)
    {
        _logger.LogTrace("{method}({context})", nameof(Execute), context);
        await _service.AddPowerDistributionForAllChargingCars().ConfigureAwait(false);
    }
}
