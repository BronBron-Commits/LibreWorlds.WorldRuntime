using System;
using System.Numerics;
using LibreWorlds.WorldQueue.Interfaces;

namespace LibreWorlds.WorldRuntime;

public sealed class LoggingWorldEngine : IWorldEngine
{
    public void AddObject(
        long objectId,
        string modelName,
        ReadOnlyMemory<byte> modelBytes,
        Vector3 position,
        Quaternion rotation)
    {
        Console.WriteLine(
            $"[ENGINE] AddObject id={objectId} model={modelName} pos={position} rot={rotation}");
    }

    public void UpdateObjectTransform(
        long objectId,
        Vector3 position,
        Quaternion rotation)
    {
        Console.WriteLine(
            $"[ENGINE] UpdateObject id={objectId} pos={position} rot={rotation}");
    }

    public void RemoveObject(long objectId)
    {
        Console.WriteLine($"[ENGINE] RemoveObject id={objectId}");
    }
}
