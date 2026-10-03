using System.Collections.Generic;
using UnityEngine;

public class BoardHandler : MonoBehaviour
{
    private Dictionary<PlayerType, SpotLogic> spotsCached = new();

    void Start()
    {
        spotsCached.Add(PlayerType.p1, null);
        spotsCached.Add(PlayerType.p2, null);
    }

    public void ActivateSpot(SpotLogic spotLogic, PlayerType playerType)
    {
        SpotLogic cachedSpot = spotsCached[playerType];
        if (cachedSpot)
        {
            cachedSpot.DeactivateSpot(playerType);
        }

        spotsCached[playerType] = spotLogic;

        spotLogic.ActivateSpot(playerType);
    }

    public void TryDeactivate(PlayerType playerType)
    {
        SpotLogic cachedSpot = spotsCached[playerType];
        Debug.Log(playerType);
        if (cachedSpot)
        {
            cachedSpot.DeactivateSpot(playerType);
        }

        spotsCached[playerType] = null;
    }

    public void TriggerActionActiveSpot(PlayerType playerType)
    {
        Debug.Log("Fig");
        SpotLogic cachedSpot = spotsCached[playerType];
        if (cachedSpot)
        {
            cachedSpot.TriggerSpot(playerType);
        }
    }
}
