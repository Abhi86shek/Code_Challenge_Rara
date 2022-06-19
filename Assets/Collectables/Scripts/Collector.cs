using UnityEngine;

namespace Rara.Collectables
{
    public class Collector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var coin = other.GetComponentInParent<BaseCollectable<Coin>>();
            if (coin != null)
                coin.Collect();
            else
            {
                var flag = other.GetComponentInParent<BaseCollectable<Flag>>();
                if (flag != null)
                    flag.Collect();

            }
        }
    }
}
