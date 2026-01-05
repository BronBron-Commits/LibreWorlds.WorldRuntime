using LibreWorlds.WorldQueue.Interfaces;

namespace LibreWorlds.WorldRuntime
{
    public sealed class WorldCommandProcessor
    {
        private readonly IWorldCommandQueue _queue;
        private readonly IWorldEngine _engine;

        public WorldCommandProcessor(
            IWorldCommandQueue queue,
            IWorldEngine engine)
        {
            _queue = queue;
            _engine = engine;
        }

        public void Process()
        {
            while (_queue.TryDequeue(out var command))
            {
                command.ExecuteOn(_engine);
            }
        }
    }
}
