using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class Playlist : MonoBehaviour {

    public List<AudioClip> songs;
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        List<AudioClip> shuffledSongs = Shuffle(songs);
        StartCoroutine(PlayList(shuffledSongs));
    }

    private IEnumerator PlayList(List<AudioClip> shuffledSongs)
    {
        while (true)
        {
            for (int i = 0; i < shuffledSongs.Count; i++)
            {
                audioSource.PlayOneShot(shuffledSongs[i]);
                while (audioSource.isPlaying)
                {
                    yield return null;
                }
            }
        }
    }

    private List<AudioClip> Shuffle(List<AudioClip> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        return list;
    }
}
