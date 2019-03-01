using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLibrary : MonoBehaviour
{
    Vector3 mouse;

    GameObject[] _gameObject = new GameObject[1];
    public enum Effect
    {
        TOUCH,
        MAX_EFFECT
    };
    // Use this for initialization
    void Start()
    {
        _gameObject[0] = (GameObject)Resources.Load("PlayerTouchEffect/PlayerTouchEffect");
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0;
            EffectInstantiate(EffectLibrary.Effect.TOUCH, mouse);
        }
    }
    public void EffectInstantiate(Effect effect, Vector3 pos)
    {

        Instantiate(_gameObject[(int)effect], pos, Quaternion.identity);
        //_gameObject[ ( int )effect ] = Instantiate( _gameObject[ ( int )effect ], pos, Quaternion.identity );

    }

    public void EffectDestroy(Effect effect)
    {
        Destroy(_gameObject[(int)effect]);
    }


}
