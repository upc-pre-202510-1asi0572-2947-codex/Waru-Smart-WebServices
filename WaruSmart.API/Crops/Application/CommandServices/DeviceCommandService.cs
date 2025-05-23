﻿using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Crops.Domain.Services;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.Crops.Application.CommandServices;

public class DeviceCommandService(IDeviceRepository deviceRepository, IUnitOfWork unitOfWork,
    ISowingRepository sowingRepository): IDeviceCommandService
{
    public async Task<Device?> Handle(CreateDeviceCommand command)
    {
        var sowing = sowingRepository.FindByIdAsync(command.sowingId);
        if (sowing == null)
        {
            throw new Exception("Sowing not found");
        }

        try
        {
            var device = new Device(command, sowing.Result);
            await deviceRepository.AddAsync(device);
            await unitOfWork.CompleteAsync();
            return device;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error creating device: " + e.Message);
            throw;
        }
        
    }

    public Task<Device> Handle(UpdateStatusDeviceCommand command, int deviceId)
    {
        var device = deviceRepository.FindByIdAsync(deviceId);
        if (device == null)
        {
            throw new Exception("Device not found");
        }
        try
        {
            device.Result?.UpdateStatus(command);
            if (device.Result == null) throw new Exception("Device not found");
            deviceRepository.Update(device.Result);
            unitOfWork.CompleteAsync();
            return Task.FromResult(device.Result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}