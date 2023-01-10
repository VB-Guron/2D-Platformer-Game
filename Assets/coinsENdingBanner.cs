
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinsENdingBanner : MonoBehaviour
{
    // Start is called before the first frame update
    public Text coinCounter;

    private void Update() {
        coinCounter.text = "" + GameManager.instance.getCoins();
    }
}
