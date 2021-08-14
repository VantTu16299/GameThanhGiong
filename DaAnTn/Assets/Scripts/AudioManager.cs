using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;
	public Slider sfxVolSlider;
	public Slider musicVolSlider;
	public float delayInCrossfading = 0.3f;
	public List<MusicTrack> tracks = new List<MusicTrack>();
	public List<Sound> sounds = new List<Sound>();
	private bool sfxMute;
	private bool musicMute;
	private AudioSource music;
	private AudioSource sfx;

	private Sound GetSoundByName(string sName) => sounds.Find(x => x.name == sName);

	private static readonly List<string> mixBuffer = new List<string>();
	private const float mixBufferClearDelay = 0.05f;

	internal string currentTrack;

	public float MusicVolume => !PlayerPrefs.HasKey("Music Volume") ? 1f : PlayerPrefs.GetFloat("Music Volume");

	public float SfxVolume => !PlayerPrefs.HasKey("SFX Volume") ? 1f : PlayerPrefs.GetFloat("SFX Volume");

	private void Awake()
	{
		
		instance = this;
		// Configuring Audio Source For Playing Music And SFX 
		//Định cấu hình nguồn âm thanh để chơi nhạc và SFX
	    music = gameObject.AddComponent<AudioSource>();
		music.loop = true;
		sfx = gameObject.AddComponent<AudioSource>();

		sfxMute = false;

		musicMute = false;

		// Check If Sfx Volume Is Not 0  
		//Kiểm tra xem khối lượng Sfx không phải là 0
		if (Math.Abs(SfxVolume) > 0.05f)
		{
			// Set The Saved Value Of SFX Volume Đặt giá trị đã lưu của khối lượng SFX
			sfxVolSlider.value = SfxVolume;
			sfx.volume = SfxVolume;
		}
		// Set The Values To 0  Đặt các giá trị thành 0
		else
		{
			sfxVolSlider.value = 0;
			sfx.volume = 0;
		}

		// Check If Music Volume Is Not 0  
		//Kiểm tra xem âm lượng nhạc không phải là 0
		if (Math.Abs(MusicVolume) > 0.05f)
		{
			// Set The Saved Value Of Music Volume
			// Đặt giá trị đã lưu của âm lượng nhạc
			musicVolSlider.value = MusicVolume;
			music.volume = MusicVolume;
		}
		// Set The Values To 0
		// Đặt các giá trị thành 0
		else
		{
			musicVolSlider.value = 0;
			music.volume = 0;
		}

		StartCoroutine(MixBufferRoutine());
	}

	// Responsible for limiting the frequency of playing sounds

	// Chịu trách nhiệm giới hạn tần số phát âm thanh
	private IEnumerator MixBufferRoutine()
	{
		float time = 0;

		while (true)
		{
			time += Time.unscaledDeltaTime;
			yield return 0;
			if (time >= mixBufferClearDelay)
			{
				mixBuffer.Clear();
				time = 0;
			}
		}
	}

	// Play a music track with Cross fading
	// Phát một bản nhạc với Cross fade
	public void PlayMusic(string trackName)
	{
		if (trackName != "")
			currentTrack = trackName;
		AudioClip to = null;
		foreach (MusicTrack track in tracks)
			if (track.name == trackName)
				to = track.track;

		StartCoroutine(CrossFade(to));
	}

	// Cross fading - Smooth Transition When Track Is Switched

	// Làm mờ chéo - Chuyển tiếp mượt mà khi bản nhạc được chuyển đổi
	private IEnumerator CrossFade(AudioClip to)
	{
		if (music.clip != null)
		{
			while (delayInCrossfading > 0)
			{
				music.volume = delayInCrossfading * MusicVolume;
				delayInCrossfading -= Time.unscaledDeltaTime;
				yield return 0;
			}
		}
		music.clip = to;
		if (to == null)
		{
			music.Stop();
			yield break;
		}
		delayInCrossfading = 0;

		if (!music.isPlaying)
			music.Play();

		while (delayInCrossfading < 1f)
		{
			music.volume = delayInCrossfading * MusicVolume;
			delayInCrossfading += Time.unscaledDeltaTime;
			yield return 0;
		}
		music.volume = MusicVolume;
	}

	//public void StopSound()
	//{
	//	sfx.Stop();
	//}
	
	public void PlaySound(string clip)
	{
		Sound sound = GetSoundByName(clip);

		if (sound != null && !mixBuffer.Contains(clip))
		{
			if (sound.clips.Count == 0)
				return;
			mixBuffer.Add(clip);
			sfx.PlayOneShot(sound.clips
				.GetRandom()); // Randomly Play Sound Each Time Through The Array Of clip Phát ngẫu nhiên âm thanh mỗi lần qua dãy clip
		}
	}

	// Changing Sfx Vol Using Slider
	// Thay đổi Sfx Vol bằng Slider
	public void SfxSlider()
	{
		float vol = sfxVolSlider.value;
		sfx.volume = vol;
		// Sets And Save The Value When User Use Slider

		// Đặt và lưu giá trị khi người dùng sử dụng thanh trượt
		PlayerPrefs.SetFloat("SFX Volume", vol);
		PlayerPrefs.Save();
	}

	// Changing Music Vol Using Slider
	public void MusicSlider()
	{
		float vol = musicVolSlider.value;
		music.volume = vol;
		// Sets And Save The Value When User Use Slider
		PlayerPrefs.SetFloat("Music Volume", vol);
		PlayerPrefs.Save();
	}

	[Serializable]
	public class MusicTrack
	{
		public string name;
		public AudioClip track;
	}

	[Serializable]
	public class Sound
	{
		public string name;
		public List<AudioClip> clips = new List<AudioClip>();
	}
}
