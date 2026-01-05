using LibreWorlds.WorldQueue.Interfaces;

namespace LibreWorlds.WorldRuntime
{
    public sealed class WorldRuntime
    {
        private readonly WorldCommandProcessor _processor;

        public WorldRuntime(
            IWorldCommandQueue queue,
            IWorldEngine engine)
        {
            _processor = new WorldCommandProcessor(queue, engine);
        }

        public void Tick()
        {
            _processor.Process();
        }
    }
}
