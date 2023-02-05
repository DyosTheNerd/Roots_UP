using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerOxygenSystem : MonoBehaviour
{
    
    public int oxygenCollisions = 0;
    
    public float maxO2 = 1000;

    public int lossPerSecond = 60;

    public int rechargePerSecond = 5 * 60;
    
    private float currentO2 = 1000;

    public GameObject playerCharacter;

    private PlayerStatus playerStatus;
    
    public void Start()
    {
        playerStatus = playerCharacter.GetComponent<PlayerStatus>();
        if (playerStatus == null)
        {
            Debug.Log("Setup Error: Player Status undefined");
        }
        
    }
    
    public float getCurrentO2()
    {
        return currentO2;
    }

    public float getMaxO2()
    {
        return maxO2;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Console.Write("collision enter");
        if (other.gameObject.CompareTag("OxygenSource") )
        {
            oxygenCollisions += 1;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Console.Write("collision exit");
        if (other.gameObject.CompareTag("OxygenSource"))
        {
            oxygenCollisions -= 1;
        }
    }

    bool canLooseOxygen()
    {
        return currentO2 > 0;
    }

    bool isInsideOxygenSource()
    {
        
        return oxygenCollisions > 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            currentO2 = 1000000000000;
        }
        float dt = Time.deltaTime;
        if (canLooseOxygen() && !isInsideOxygenSource())
        {
            currentO2 -= lossPerSecond * dt;
        }

        if (isInsideOxygenSource())
        {
            currentO2 += rechargePerSecond * dt;
            currentO2 = Math.Min(currentO2, maxO2);
        }

        checkAndActIfDead();
    }

    void checkAndActIfDead()
    {
        
        if (currentO2 <= 0 && !playerStatus.IsDead)
        {
            ExecuteEvents.Execute<PlayerDyingEvent>(playerCharacter, null, (x, y) => x.DyingMessage("oxygen"));
        }
    }
}
