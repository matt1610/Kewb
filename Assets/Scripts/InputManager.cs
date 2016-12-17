using UnityEngine;
using System.Collections;
using Kewb;

public class InputManager {
    public float Horizontal {
        get {
            #if UNITY_IOS
                return MobileH();
            #endif

            return Input.GetAxisRaw("Horizontal");
        }
    }
    public float Vertical {
        get {
             #if UNITY_IOS
                return MobileV();
            #endif
            return Input.GetAxisRaw("Vertical");
        }
    }
    private float MobileH() 
    {
        return 0;
    }
    private float MobileV()
    {
        return 0;
    }
}