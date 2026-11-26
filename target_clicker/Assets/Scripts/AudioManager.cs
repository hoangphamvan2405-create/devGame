using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;   // nguồn phát nhạc nền
    public AudioSource sfxSource;     // nguồn phát tiếng động (audioSource cũ)

    public AudioClip menuMusic;       // modaugame
    public AudioClip gameMusic;       // nhạc khi chơi

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(transform.root.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(transform.root.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        if (musicSource != null)
            musicSource.ignoreListenerPause = true; // pause không làm im nhạc
        PlayMusicForScene(SceneManager.GetActiveScene());
    }

    void OnDestroy()
    {
        if (Instance != this) return;

        SceneManager.sceneLoaded -= OnSceneLoaded;
        Instance = null;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene);
    }

    private void PlayMusicForScene(Scene scene)
    {
        if (scene.name == "StartScene")
            PlayMusic(menuMusic);
        else if (scene.name == "SampleScene")
            PlayMusic(gameMusic);
        else if (scene.name == "EndScene")
            PlayMusic(menuMusic);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip && musicSource.isPlaying) return;
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayMenuMusic() { PlayMusic(menuMusic); }
    public void PlayGameMusic() { PlayMusic(gameMusic); }
}