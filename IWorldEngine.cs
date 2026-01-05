using System.Numerics;

namespace LibreWorlds.WorldRuntime
{
    public interface IWorldEngine
    {
        void AddObject(
            int objectId,
            string modelName,
            ReadOnlyMemory<byte> modelData,
            Vector3 position,
            Quaternion rotation);

        void UpdateObjectTransform(
            int objectId,
            Vector3 position,
            Quaternion rotation);

        void RemoveObject(int objectId);
    }
}
