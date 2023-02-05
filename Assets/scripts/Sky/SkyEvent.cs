using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace.Sky
{
    public interface SkyEvent : IEventSystemHandler
    {
        void DeltaEvent(Vector3 current, Vector3 old);
    }
}