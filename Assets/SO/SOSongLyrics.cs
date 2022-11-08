using System;
using System.Net.Mime;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSong", menuName = "Lyrics/Song")]
public class SOSongLyrics : ScriptableObject
{
   [Serializable]
   public struct Line {
      public string text;
      public float appearanceTime;
      public float disappearTime;
   }
   public Line[] lyrics;
   
   [TextArea(3,10)]
   public string fullLyrics;
   private string previousFullLyrics;
   private void OnValidate()
   {
      if (previousFullLyrics != fullLyrics)
      {
         previousFullLyrics = fullLyrics;
         lyrics = ParseLyrics(fullLyrics);
         
      }
   }

   private Line[] ParseLyrics(string _lyrics)
   {
      string[] lines = _lyrics.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
      var newLyrics = new Line[lines.Length];
      for (int i = 0; i < lines.Length; i++)
      {
         newLyrics[i].text = lines[i];
         newLyrics[i].appearanceTime = 0;
         newLyrics[i].disappearTime = 0;
      }
      return newLyrics;
   }
   
}
