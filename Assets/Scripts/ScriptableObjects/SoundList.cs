using System.Collections.Generic;
using UnityEngine;

namespace Aftermath
{
    [CreateAssetMenu(fileName = "SoundList", menuName = "Aftermath/Sound List")]
    public class SoundList : ScriptableObject
    {
        [EnumNamedList(typeof(SoundPlayer.MusicEnum))]
        public List<AudioClip> Musics;

        [EnumNamedList(typeof(SoundPlayer.AudioEnum))]
        public List<AudioClip> AudioClips;
    }
}
