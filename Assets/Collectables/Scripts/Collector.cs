using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SAS.Utilities.TagSystem;

namespace Rara.Collectables
{
    public class Collector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var coin = other.GetComponentInParent<ICollectable<Coin>>();
            if (coin != null)
                coin.Collect();
            else
            {
                var flag = other.GetComponentInParent<ICollectable<Flag>>();
                if (flag != null)
                    flag.Collect();

            }
        }
    }
}
