using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class S_Move : MonoBehaviour
{
    public AudioSource[] moveSounds;

    private float currentX, currentY;

    void Start()
    {
        currentX = transform.position.x;
        currentY = transform.position.y;
    }

    void Update()
    {
        if (Mathf.Abs(currentX - transform.position.x) > 0.35f || Mathf.Abs(currentY - transform.position.y) > 0.35f)
        {
            foreach (var sound in moveSounds)
            {
                if (sound.isPlaying) return;
            }

            int i = Random.Range(-1, moveSounds.Length);
            moveSounds[i].Play();
            currentX = transform.position.x;
            currentY = transform.position.y;

        }
    }
}
