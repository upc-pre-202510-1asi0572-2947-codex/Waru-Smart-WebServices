﻿namespace WaruSmart.API.Profiles.Interfaces.ACL;

public interface IProfilesContextFacade
{
    Task<int> CreateProfile(string firstName, string lastName, string email, int cityId, int subscriptionId,
        int countryId, int userId);

    Task<int> FetchProfileIdByEmail(string email);
}