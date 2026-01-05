using LibreWorlds.WorldQueue.Interfaces;

namespace LibreWorlds.WorldRuntime;

public sealed class WorldRuntime
{
    private readonly IWorldCommandQueue _queue;
    private readonly WorldCommandProcessor _processor;

    public WorldRuntime(
        IWorldCommandQueue queue,
        WorldCommandProcessor processor)
    {
        _queue = queue;
        _processor = processor;
    }

    public void Tick()
    {
        while (_queue.TryDequeue(out var cmd))
        {
            _processor.Process(cmd);
        }
    }
}
