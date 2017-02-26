using UnityEngine;

public class AudioController : MonoBehaviour {
	public AudioClip bgm;
	public AudioClip lineClear;
	public AudioClip turn;
	public AudioClip gameOver;

	private AudioSource bgmSource;
	private AudioSource seSource;

	public static AudioController Instance {
		get {
			if (_instance == null)
			{
				_instance = (AudioController)FindObjectOfType(typeof(AudioController));
			}
			return _instance;
		}
	}
	private static AudioController _instance;

	public void Awake()
	{
		if (Instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);

		InitSource();
	}

	public void InitSource()
	{
		this.bgmSource = this.gameObject.AddComponent<AudioSource>();
		this.bgmSource.loop = true;
		this.bgmSource.playOnAwake = false;
		this.bgmSource.clip = this.bgm;

		this.seSource = this.gameObject.AddComponent<AudioSource>();
		this.seSource.loop = false;
		this.seSource.playOnAwake = false;
	}

	public void StartBgm()
	{
		if (!this.bgmSource.isPlaying)
		{
			this.bgmSource.Play();
		}
	}
	public void StopBgm()
	{
		this.bgmSource.Stop();
	}

	public void PlaySe(SfxId id)
	{
		if (this.seSource.isPlaying)
		{
			this.seSource.Stop();
		}
		this.seSource.clip = ClipById(id);
		this.seSource.Play();
	}

	private AudioClip ClipById(SfxId id)
	{
		switch(id)
		{
			case SfxId.LineClear:
				return this.lineClear;
			case SfxId.TetriminoTurn:
				return this.turn;
			case SfxId.GameOver:
				return this.gameOver;
		}
		return null;
	}
}
