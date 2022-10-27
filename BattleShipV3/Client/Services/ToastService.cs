using System.Timers;
using static BattleShipV3.Data.Enums;
using Timer = System.Timers.Timer;

public class ToastService : IDisposable
{
    public event Action<string, ToastLevel> OnShow;
    public event Func<string, ToastLevel, Task> OnShowAsync;
    public event Action OnHide;
    private Timer Countdown;

    public void ShowToast(string message, ToastLevel level)
    {
        OnShow?.Invoke(message, level);
        StartCountdown();
    }
    public async Task ShowToastAsync(string message, ToastLevel level)
    {
        OnShowAsync?.Invoke(message, level);
        StartCountdown();
    }
    private void StartCountdown()
    {
        SetCountdown();

        if (Countdown.Enabled)
        {
            Countdown.Stop();
            Countdown.Start();
        }
        else
        {
            Countdown.Start();
        }
    }

    private void SetCountdown()
    {
        if (Countdown == null)
        {
            Countdown = new Timer(30000);
            Countdown.Elapsed += HideToast;
            Countdown.AutoReset = false;
        }
    }

    private void HideToast(object source, ElapsedEventArgs args)
    {
        OnHide?.Invoke();
    }

    public void Dispose()
    {
        Countdown?.Dispose();
    }
}