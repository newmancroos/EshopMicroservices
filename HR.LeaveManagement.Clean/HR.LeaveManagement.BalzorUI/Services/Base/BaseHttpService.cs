using Blazored.LocalStorage;

namespace HR.LeaveManagement.BalzorUI.Services.Base;

public class BaseHttpService
{
    protected IClient _client;
    protected readonly ILocalStorageService _localStorageService;

    //LocalStorageService is used to store the token in the local storage and retrieve it when needed.
    //This is done to avoid having to pass the token in every request.
    // Install Blazored.LocalStorage package to use this service.
    // Register the service in the Program.cs file as shown below:
    // builder.Services.AddBlazoredLocalStorage();
    // Then inject the service in the constructor of the class that inherits from BaseHttpService as shown below:
    // Modify AuthenticationService, Inject ILocalStorageService in the constructor and pass it to the base class constructor as shown below:
    public BaseHttpService(IClient client, ILocalStorageService localStorageService)
    {
        _client = client;
        _localStorageService = localStorageService;
    }

    protected Response<Guid> CovertApiException<Guid>(ApiException ex)
    {

        if (ex.StatusCode == 400)
        {
            return new Response<Guid>() { Message = "Invalid data was submitted.", ValidationErrors = ex.Response, Success = false };
        }
        else if (ex.StatusCode == 404)
        {
            return new Response<Guid>() { Message = "The record was not found.", Success = false };
        }

        return new Response<Guid>() { Message = "Something went wrong, please try again.", Success = false };

    }

    protected async Task AddBearerToken()
    {
        if (await _localStorageService.ContainKeyAsync("token"))
        {
            _client.HttpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await _localStorageService.GetItemAsync<string>("token"));
        }
    }
}