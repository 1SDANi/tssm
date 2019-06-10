using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{

    public float RefreshDelta;
    public player_controller_rigidbody[] Players { get; private set; }
    public float RefreshRate { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        RefreshDelta = 0.0f;
        Players = new player_controller_rigidbody[4];
    }

    // Update is called once per frame
    void Update()
    {
        RefreshRate = (float)Screen.currentResolution.refreshRate / 1000;
        RefreshDelta += Mathf.Ceil((Time.unscaledDeltaTime - RefreshDelta) * 0.1f / RefreshRate) * RefreshRate;
    }

    public bool AddPlayer(bool test = true, player_controller_rigidbody player = null)
    {
        for (int i = 0; i < Players.Length; i++)
        {
            if (Players[i] == null)
            {
                if (test)
                {
                    Players[i] = player;
                }
                return true;
            }
        }
        return false;
    }
}
