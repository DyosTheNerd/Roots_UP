using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public interface SendWaterEvent: IEventSystemHandler
    {
        void SendWaterMessage();
    }
}