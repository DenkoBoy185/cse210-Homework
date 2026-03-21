using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split text into words and create Word objects
        string[] splitText = text.Split(' ');
        foreach (string wordText in splitText)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        // Find all indices of words that are currently NOT hidden
        List<int> visibleIndices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleIndices.Add(i);
            }
        }

        // If there are fewer visible words than numberToHide, we hide all remaining visible words.
        if (visibleIndices.Count <= numberToHide)
        {
            foreach (int index in visibleIndices)
            {
                _words[index].Hide();
            }
            return;
        }

        // Otherwise, hide 'numberToHide' random words
        Random random = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            int randomIndexPicker = random.Next(0, visibleIndices.Count);
            int indexOfWordToHide = visibleIndices[randomIndexPicker];
            
            _words[indexOfWordToHide].Hide();
            
            // Remove the index from our visible list so we don't pick it again in this method call
            visibleIndices.RemoveAt(randomIndexPicker);
        }
    }

    public string GetDisplayText()
    {
        string text = $"{_reference.GetDisplayText()} ";
        
        List<string> displayWords = new List<string>();
        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }

        text += string.Join(" ", displayWords);
        return text;
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
