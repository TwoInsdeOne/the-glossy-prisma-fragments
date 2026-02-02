using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shake : MonoBehaviour
{
    public float timer;
    public float str;
    private float _timer;
    private float _str;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _timer -= Time.deltaTime;
        if (_timer > 0)
        {
            
            transform.localPosition = new Vector3(Random.Range(-_str, _str), Random.Range(-_str, _str), 0);
            
        } else
        {
            if(Gamepad.current != null)
            {
                Gamepad.current.SetMotorSpeeds(0, 0);
            }
            
            transform.localPosition = new Vector3(0, 0, 0);
        }
    }
    public void StartShake(float duration, float strenght, bool shakeJoystick)
    {
        if(shakeJoystick && Gamepad.current != null)
        {
            Debug.Log("gamepad present");
            
            Gamepad.current.SetMotorSpeeds(0.3f, 0.3f);
        }

        _timer = duration;
        _str = strenght;
    }
}
