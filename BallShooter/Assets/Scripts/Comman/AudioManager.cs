using System;
using UnityEngine;
using BallBlast.Comman.Sounds;
using BallBlast.Comman.Game;

namespace BallBlast.Comman.AudioManage
{

    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;
        public Music[] musics;
        void Awake()
        {
            foreach (Sound s in sounds)
            {
                s.audioSource = gameObject.AddComponent<AudioSource>();                      // add AudioSource to this gameobject
                s.audioSource.clip = s.clip;
                s.audioSource.volume = s.volume;
                s.audioSource.name = s.Name;
                s.audioSource.loop = s.Loop;
            }

            foreach (Music m in musics)
            {
                m.audioSource = gameObject.AddComponent<AudioSource>();                      // add AudioSource to this gameobject
                m.audioSource.clip = m.clip;
                m.audioSource.volume = m.volume;
                m.audioSource.name = m.Name;
                m.audioSource.loop = m.Loop;
            }
        }

        void Start()
        {
            MusicPlay("theme");
        }

        public void sfx(string name)
        {
            if (GameManager.instances.GetSfx() == 0)
                return;

            Sound s = Array.Find(sounds, sound => sound.Name == name);
            if (s == null)
            {
                print("Can not find " + name + " sfx");
                return;
            }
            if (s.audioSource.isPlaying == true)
                return;
            s.audioSource.Play();
        }



        public void MusicPlay(string name)
        {
            if (GameManager.instances.GetMusic() == 0)
                return;

            Music m = Array.Find(musics, music => music.Name == name);
            if (m == null)
            {
                print("Can not find " + name + " music");
                return;
            }
            if (m.audioSource.isPlaying == true)
                return;
            m.audioSource.Play();
        }

        public void MusicStop(string name)
        {
            if (GameManager.instances.GetMusic() == 0)
                return;

            Music m = Array.Find(musics, music => music.Name == name);
            if (m == null)
            {
                print("Can not find " + name + " music");
                return;
            }
            if (m.audioSource.isPlaying == false)
                return;
            m.audioSource.Stop();
        }

    }
}
