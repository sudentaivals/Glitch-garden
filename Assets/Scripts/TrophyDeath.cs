using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyDeath : MonoBehaviour
{

    private void Start()
    {
        Invoke("DestroyTrophy", 2.0f);

    }

    public void DestroyTrophy()
    {
        Destroy(gameObject);
    }

}
