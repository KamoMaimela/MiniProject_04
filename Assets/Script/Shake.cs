using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shake: MonoBehaviour
{
    public Animator camAnim;

   

    public void CamShake()
    {
        camAnim.SetTrigger("Shake");
    }
}
