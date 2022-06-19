using SAS.Utilities.TagSystem;
using System.Linq;
using UnityEngine;

namespace Rara.FSMCharacterController.AI
{
    [RequireComponent(typeof(Target))]
    public class TragetSpawnedNotifier : MonoBase
    {
        [FieldRequiresSelf] ITarget _target;

        protected override void Start()
        {
            base.Start();
            var listeners = FindObjectsOfType<MonoBehaviour>().OfType<ITargetSpawnedListener>();
            foreach (var listener in listeners)
                listener.OnSpawn(_target);
        }
    }
}
