using UnityEngine;

namespace DefaultNamespace.Player
{
    public class PlayerSingletonProvider : MonoBehaviour
    {
        private static GameObject instance;
        void Start()
        {
            instance = gameObject;
        }

        public static GameObject getPlayerGameObject()
        {
            return instance;
        }
    }
}