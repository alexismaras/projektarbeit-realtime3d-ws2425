using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAmbientAudio : MonoBehaviour
{
    [SerializeField] AudioSource shipHorn;

    bool cycleActive;
    // Start is called before the first frame update
    void Start()
    {
        cycleActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!cycleActive)
        {
            int randomTime = Random.Range(60, 200);
            StartCoroutine(SoundCycle(randomTime));
        }
    }

    IEnumerator SoundCycle( int time)
    {
        cycleActive = true;
        yield return new WaitForSeconds((float)time);
        shipHorn.Play();
        cycleActive = false;
    }
}
