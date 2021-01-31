using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Taken from https://www.daggerhartlab.com/unity-audio-and-sound-manager-singleton-script/
public class SoundManager : MonoBehaviour
{
	// Audio players components.
	public AudioSource EffectsSource;
	public AudioSource MusicSource;

	// Random pitch adjustment range.
	public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;

    // For keeping track of audioclips
    public AudioClip[] AudioClipArray;
    public Dictionary<string, int> AudioClipLibrary = new Dictionary<string, int>();

	// Singleton instance.
	public static SoundManager Instance = null;
	
	// Initialize the singleton instance.
	private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
            AudioClipLibrary.Add("Explosion", 0);
            AudioClipLibrary.Add("Footsteps", 1);
            AudioClipLibrary.Add("ColorChange", 2);
            AudioClipLibrary.Add("Spike", 3);
            AudioClipLibrary.Add("Checkpoint", 4);
            AudioClipLibrary.Add("Spit", 5);
            AudioClipLibrary.Add("Fart", 6);
            AudioClipLibrary.Add("Jump", 7);
			AudioClipLibrary.Add("LinkedInPark", 8);
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);
	}

	// Play a single clip through the sound effects source.
	public void Play(AudioClip clip)
	{
		EffectsSource.clip = clip;
		EffectsSource.Play();
	}

	// Play a single clip through the music source.
	public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();
	}

    // Play the sound effect with the given name from Sounds folder.
    public void PlaySoundWithName(string effectName, bool respectOtherAudio = false){
        if(AudioClipLibrary.ContainsKey(effectName)){
            int AudioClipIndex = AudioClipLibrary[effectName];

            if(!respectOtherAudio || !EffectsSource.isPlaying){
                EffectsSource.clip = AudioClipArray[AudioClipIndex];
		        EffectsSource.Play();
            }
        }
    }

	// Play a random clip from an array, and randomize the pitch slightly.
	public void RandomSoundEffect(params AudioClip[] clips)
	{
		int randomIndex = Random.Range(0, clips.Length);
		float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

		EffectsSource.pitch = randomPitch;
		EffectsSource.clip = clips[randomIndex];
		EffectsSource.Play();
	}
	
}