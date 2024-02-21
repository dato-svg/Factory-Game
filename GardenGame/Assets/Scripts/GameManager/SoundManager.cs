using UnityEngine;

namespace Assets.Scripts.GameManager
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource[] musicTracks;
        private int currentTrackIndex = 0;

        private void Start()
        {
        
            PlayNextTrack();
        }

        private void Update()
        {
        
            if (!musicTracks[currentTrackIndex].isPlaying)
            {
                PlayNextTrack();
            }
        }

        private void PlayNextTrack()
        {
        
            musicTracks[currentTrackIndex].Stop();
        
            currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;
        
            musicTracks[currentTrackIndex].Play();
        }
    }
}
