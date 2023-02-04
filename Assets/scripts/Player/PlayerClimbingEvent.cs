using UnityEngine.EventSystems;

namespace DefaultNamespace.Player
{
    public interface PlayerClimbingEvent : IEventSystemHandler
    {
        void PlayerClimbingMessage(bool isClimbing);
    }
}