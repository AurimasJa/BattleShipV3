using BattleShipV3.Client.DesignPatterns.Decorator;
using BattleShipV3.Client.DesignPatterns.Strategy;
using BattleShipV3.Models;
using BattleShipV3.Shared.Data.Commands.Listing.Create;
using BattleShipV3.Shared.Data.Commands.Listing.Update;
using BattleShipV3.Shared;
using Microsoft.AspNetCore.SignalR.Client;

namespace BattleShipV3.Client.Pages.Listings
{
    partial class Listings
    {
        private HubConnection? hubConnection;
        private string searchString = "";
        private Listing selectedListing;

        List<Listing> listings { get; set; } = new List<Listing>();

        private bool isLobbyCreatePopUpOpen = false;

        //Lobby creation
        double eloFrom, eloTo;
        string lobbyName;

        int onlineUsers { get; set; }

        IFilterStrategy filterStrategy { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Global.CurrentUser == null)
                Navigation.NavigateTo("/login");

            hubConnection = new HubConnectionBuilder()
                .WithUrl(Navigation.ToAbsoluteUri("/lobbyhub"))
                .WithAutomaticReconnect()
                .Build();


            hubConnection.On<Listing, Models.User>("CreateListing", (lobby, user) =>
            {
                lobby.PlayerOne = user;
                listings.Add(lobby);
                InvokeAsync(StateHasChanged);
            });

            hubConnection.On<Listing, Models.User>("JoinedListing", (lobby, user) =>
            {
                listings[listings.FindIndex(e => e.Id == lobby.Id)].PlayerTwo = user;
                InvokeAsync(StateHasChanged);
            });

            hubConnection.On<Listing, Models.User>("LeftListing", (lobby, user) =>
            {
                if (GetLobbySize(lobby) == 0)
                    listings.Remove(lobby);
                else
                    listings[listings.FindIndex(e => e.Id == lobby.Id)].PlayerTwo = null;

                InvokeAsync(StateHasChanged);
            });

            hubConnection.On<Listing, Models.User>("DeleteListing", (lobby, user) =>
            {
                listings.RemoveAll(e => e.Id == lobby.Id);
                InvokeAsync(StateHasChanged);
            });

            hubConnection.On<Models.User, int>("UserLoggedIn", (user, userCount) =>
            {
                //OnlinePlayersSingleton.OnlineUsers.Add(user);
                onlineUsers = userCount;
                InvokeAsync(StateHasChanged);
            });

            hubConnection.On<int>("fetchusercount", (userCount) =>
            {
                //OnlinePlayersSingleton.OnlineUsers.Add(user);
                onlineUsers = userCount;
                InvokeAsync(StateHasChanged);
            });

            await hubConnection.StartAsync();

            SetStrategy("By Name");

            await Load();

            await hubConnection.SendAsync("FetchUserCount");

            await InvokeAsync(StateHasChanged);
            StateHasChanged();
        }

        private void ToggleLobbyCreate()
        {
            isLobbyCreatePopUpOpen = isLobbyCreatePopUpOpen ? false : true;
        }

        private async Task JoinLobby()
        {
            if (hubConnection is null)
                return;

            await hubConnection.SendAsync("JoinedListing", selectedListing, Global.CurrentUser);

            var cmd = new UpdateListingCommand(Global.CurrentUser);

            await listingService.UpdateListingAsync(selectedListing.Id, cmd);

            Navigation.NavigateTo($"/listingslist/{selectedListing.Id}");
        }

        private async Task CreateDecoratedLobby()
        {
            if (hubConnection is null || Global.CurrentUser is null)
                return;

            CreateListingComponent component = new CreateListingComponent();
            NameDecorator nameDecorator = new NameDecorator(component, lobbyName);
            EloFromDecorator eloDecorated = new EloFromDecorator(nameDecorator, eloFrom);
            EloToDecorator eloToDecorated = new EloToDecorator(eloDecorated, eloTo);

            await CreateLobby(eloToDecorated);
        }

        public async Task CreateLobby(CreateListingComponent listingComp)
        {
            Listing ListingToCreate = listingComp.GetCreatedListing();

            ToggleLobbyCreate();

            var createdListing = new CreateListingCommand(ListingToCreate.Name, ListingToCreate.EloFrom.Value, ListingToCreate.EloTo.Value, Global.CurrentUser);

            var response = await listingService.InsertListingAsync(createdListing);

            await hubConnection.SendAsync("CreateListing", response, Global.CurrentUser);

            Navigation.NavigateTo($"/listingslist/{response?.Id}");
        }

        private int GetLobbySize(Listing arg)
        {
            int ret = 0;
            if (arg.PlayerOne != null)
                ret++;
            if (arg.PlayerTwo != null)
                ret++;

            return ret;
        }

        private async Task Load()
        {
            listings = await listingService.GetListingsAsync();
        }

        private bool FilterFunc1(Listing element) => FilterFunc(element, searchString);

        private bool FilterFunc(Listing element, string searchString)
        {
            return filterStrategy.FilterFunction(element, searchString);
        }

        public void SetStrategy(string strategy)
        {
            if (strategy.Equals("By Creator"))
                this.filterStrategy = new FilterStrategyByCreator();
            else if (strategy.Equals("By Lobby Name"))
                this.filterStrategy = new FilterStrategyByName();
            else if (strategy.Equals("Max Elo Less Than"))
                this.filterStrategy = new FilterStrategyByLessMaxElo();
            else
                this.filterStrategy = new FilterStrategyByMoreMaxElo();

        }

        public async ValueTask DisposeAsync()
        {
            if (hubConnection is not null)
            {
                await hubConnection.DisposeAsync();
            }
        }
    }
}
