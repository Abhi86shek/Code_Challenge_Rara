using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rara.Collectables
{
    public interface ICollectable<in T> where T : ICollectable<T>
    {
        void Collect();
    }
}
