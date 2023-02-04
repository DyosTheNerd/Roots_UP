using UnityEngine.EventSystems;

namespace DefaultNamespace.Plants
{
    public interface TogglePlantAliveEvent: IEventSystemHandler
    {
        void TogglePlantAliveMessage();
    }
}