using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocean_music : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("Ocean");
    }

}
