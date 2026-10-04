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

    public void ActivateSpot(SpotLogic spotLogic, PlayerLogic playerLogic)
    {
        PlayerType playerType = playerLogic.playerType;
        SpotLogic cachedSpot = spotsCached[playerType];
        if (cachedSpot)
        {
            cachedSpot.DeactivateSpot(playerType);
        }

        spotsCached[playerType] = spotLogic;

        spotLogic.ActivateSpot(playerLogic);
    }

    public void TryDeactivate(PlayerType playerType)
    {
        SpotLogic cachedSpot = spotsCached[playerType];
        if (cachedSpot)
        {
            cachedSpot.DeactivateSpot(playerType);
        }

        spotsCached[playerType] = null;
    }

    public void TriggerActionActiveSpot(PlayerLogic playerLogic)
    {
        PlayerType playerType = playerLogic.playerType;
        SpotLogic cachedSpot = spotsCached[playerType];
        if (cachedSpot)
        {
            cachedSpot.TriggerSpot(playerLogic);
        }
    }
}
