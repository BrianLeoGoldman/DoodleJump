﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

    public float coins;

    public void CoinCollected()
    {
        coins += 1;
    }
}
