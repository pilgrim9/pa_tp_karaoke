using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class LyricsManager : MonoBehaviour
{
    TextAsset jsonFile;
    public AudioSource audioSource;
    public Text lyricsText;

    // Start is called before the first frame update
    [Serializable]
    public class Line
    {
        public string words;
        public float timestamp;
    }

    [Serializable]
    private class Lyrics
    {
        public Line[] lyrics;
    }

    private void Start()
    {
        jsonFile = Resources.Load<TextAsset>("Lyrics");
        ResetQueue();
        CatchUp();
    }

    private Line currentLine;
    private void CatchUp()
    {
        while (lyricsQueue.Count > 0 && lyricsQueue.Peek().timestamp / 1000 < audioSource.time)
        {
            currentLine = lyricsQueue.Dequeue();
            Debug.Log(currentLine.words);
            lyricsQueue.Enqueue(currentLine);
        }
    }

    private Queue<Line> lyricsQueue = new Queue<Line>();

    private void ResetQueue()
    {
        lyricsQueue.Clear();
        Lyrics lyrics = JsonUtility.FromJson<Lyrics>(jsonFile.text);
        foreach (Line line in lyrics.lyrics)
        {
            lyricsQueue.Enqueue(line);
        }
    }
    
    private void Update()
    {
        if (lyricsQueue.Count > 0 && lyricsQueue.Peek().timestamp / 1000 < audioSource.time)
        {
            currentLine = lyricsQueue.Dequeue();
            lyricsText.text = currentLine.words;
            Debug.Log(currentLine.words);
            lyricsQueue.Enqueue(currentLine);
        }
    }
}
