using Microsoft.AspNetCore.SignalR;

namespace WaiterCallSignalR.Hubs;

public class WaiterCallHub : Hub
{
    public async Task SendCall(int tableNumber)
    {
        await Clients.All.SendAsync("ReceiveCall", tableNumber);
        Console.WriteLine($"call reiceived! Tablenumber: {tableNumber}");
    }
}