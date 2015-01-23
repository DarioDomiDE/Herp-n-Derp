using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {

    public float PointCounter = 0.0f;

    private static Points _instance = null;
    public static Points Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);
    }

}
