using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameplayEventBus.Publish(GameplayEventType.UIObjectDeactivated, gameObject);
        }
    }
}
