using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item that when used changes to the next song, when out of songs turns off, when used while off, plays first song.
/// 
/// TODO; It should auto play, randomise order potentially and go to next track when used.
///     In other words, act kind of like the radio in a GTA style game.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class BoomBoxItem : InteractiveItem
{
    //TODO: you will need more data than this, like clips to play and a way to know which clip is playing

    //Here, I have created an Array of AudioClips, under the audioSource object (that was already created for us).
    protected AudioSource audioSource;
    [SerializeField] AudioClip[] musicClips;
    
    int track = -1;


    bool isUsed = false;

    protected override void Start()
    {
        base.Start();
        //Below, we used the GetComponent function to associate the newly created 'audioSource' object to the the Audiosource, were the audioclips are stored.
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicClips[0];



        //TODO; prep the boom box
    }

    public void PlayClip()
    {
        //TODO; this is where you might want to setup and ensure the desire clip is playing on the source
        audioSource.clip = musicClips[track];
        audioSource.Play();
    }

    void Update()
    {

        //This is the function that activates upon using the Boombox.
        //We are using the 'if' function to check if an audiosource is (not) playing. The '!' is used to indicate 'not'. We are telling it, that if nothing is playing,
        //then we want it to pick a random clip from our(my) Array called musicClips. To do this, we have told it to produce a random varaible (integer) ranging betwewn the 1st and 5th clip in my array MusicClips.
        //Then, from audioSource.clip, we assign the randomised pick, by calling the the Array, element 'i'. We then make the song play by inputting the play function.
        //Lines 47 + 48 can also be written as //audioSource.clip = musicClips[Random.Range(0, musicClips.Length)];// But below is an expanded way of coding it.

        if (!audioSource.isPlaying && isUsed)
        {

            track++;

            if (track > musicClips.Length - 1)
                track = 0;


            PlayClip();


            //  This has initially been used for randomised song selection but is no longer needed.
            //int i = Random.Range(0, musicClips.Length);
            //audioSource.clip = musicClips[i];
            //audioSource.Play();

        }

    }

    public override void OnUse()
    {
        base.OnUse();
        isUsed = true;

        if (track < musicClips.Length - 1)
        {
            track++;
            PlayClip();
        }
        else
        {
            audioSource.Stop();
            track = 0;
            isUsed = false;


        }
        
        //TODO; this where we need to go to next track and start and stop playing
    }
}
