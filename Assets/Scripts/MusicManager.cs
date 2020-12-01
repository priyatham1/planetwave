
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager mInstance;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if(mInstance == null)
        {
            mInstance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    
}
