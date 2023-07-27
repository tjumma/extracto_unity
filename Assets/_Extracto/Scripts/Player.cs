using Cysharp.Threading.Tasks;

namespace Extracto
{
    public class Player
    {
        public readonly AsyncReactiveProperty<PlayerData> PlayerDataRP = new AsyncReactiveProperty<PlayerData>(null);
    }
}