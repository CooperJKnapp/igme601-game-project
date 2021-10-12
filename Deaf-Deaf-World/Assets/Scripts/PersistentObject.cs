using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    private static PersistentObject inst;

    public static PersistentObject Inst { get { return inst; } }

    void Awake()
    {
        if (inst != null && inst != this)
        {
            Destroy(this.gameObject);
            return;
        }

        inst = this;
        DontDestroyOnLoad(this.gameObject);
    }


}


