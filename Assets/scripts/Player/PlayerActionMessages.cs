using UnityEngine.EventSystems;


public interface PlayerActionMessages:IEventSystemHandler {
    public void OnPlayerJumped();
    public void OnPlayerClimbing();

}