namespace LibreWorlds.WorldRuntime.Interfaces
{
    public interface IWorldRuntime
    {
        void Start();
        void Stop();
        void Tick(double deltaSeconds);
    }
}
