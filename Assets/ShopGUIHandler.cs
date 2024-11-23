using UnityEngine;

public class MenuController : MonoBehaviour {
	public GameObject menuCanvas;
    public AudioClip soundEffect;
    private AudioSource audioSource;

	void Start() {
		menuCanvas.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        
        // Optionally, set the AudioClip in code
        if (soundEffect != null)
        {
            audioSource.clip = soundEffect; // Assign the AudioClip
        }
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.M)) {
			menuCanvas.SetActive(!menuCanvas.activeSelf);
            audioSource.Play();
		}
	}
}