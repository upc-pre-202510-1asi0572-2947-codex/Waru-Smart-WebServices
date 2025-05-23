﻿using WaruSmart.API.Profiles.Domain.Model.Aggregates;
using WaruSmart.API.Profiles.Interfaces.REST.Resources;

namespace WaruSmart.API.Profiles.Interfaces.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(entity.Id, entity.FullName,
            entity.EmailAddress, entity.CountryId,
            entity.CityId, entity.SubscriptionId, entity.UserId.Id);
    }
}