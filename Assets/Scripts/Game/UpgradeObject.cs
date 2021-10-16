using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeObject : MonoBehaviour
{
    public string UpgradeName = "";
    public long BasePrice = 0;
    public float PriceMultiplier = 0;
    public int UpgradeType = 0;
    public float UpgradeImpact = 0;

    private long currentPrice = BasePrice;
    private float currentImpact = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
