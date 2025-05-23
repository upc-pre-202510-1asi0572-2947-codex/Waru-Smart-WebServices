﻿namespace WaruSmart.API.Crops.Interfaces.REST.Resources;

public record GeneralInformationDeviceResource(
    int SowingId,
    int QuantityDevices,
    int QuantityActiveDevices,
    int QuantityInactiveDevices,
    int QuantityDisconnectedDevices,
    int QuantityHumidityDevices,
    int QuantityTemperatureDevices,
    int QuantitySoilMoistureDevices
    );