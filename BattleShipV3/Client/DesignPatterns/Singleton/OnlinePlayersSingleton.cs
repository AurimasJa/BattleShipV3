using BattleShipV3.Models;
using System.Collections.Concurrent;

namespace BattleShipV3.Client.DesignPatterns.Singleton
{
    public class OnlinePlayersSingleton
    {
        private static OnlinePlayersSingleton instance = null;
        public static BlockingCollection<User> OnlineUsers { get; set; }

        private OnlinePlayersSingleton()
        {
            OnlineUsers = new BlockingCollection<User>();
        }

        public static OnlinePlayersSingleton getInstance()
        {
            if (instance is null)
            {
                instance = new OnlinePlayersSingleton();
            }

            return instance;
        }
    }
}
