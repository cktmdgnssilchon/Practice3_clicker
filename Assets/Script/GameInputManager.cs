using UnityEngine;
using System.Collections;

public class GameInputManager : FFMonoBehaviour
{
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameScene.Instance.TouchScreen(Input.mousePosition);
        }
    }
}