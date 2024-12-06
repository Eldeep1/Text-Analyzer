module TextAnalysis

open System.Text.RegularExpressions
open System

let analyzeText text =
    let wordCount = Regex.Matches(text, @"\b\w+\b").Count
    let sentenceCount = Regex.Matches(text, @"[.!?]").Count
    let paragraphCount = text.Split([|"\r\n"; "\n"|], StringSplitOptions.RemoveEmptyEntries).Length
    let avgSentenceLength = 
        if sentenceCount > 0 then (float wordCount / float sentenceCount).ToString("0.##")
        else "N/A"

    Map [
        "Number of Words", wordCount.ToString()
        "Number of Sentences", sentenceCount.ToString()
        "Number of Paragraphs", paragraphCount.ToString()
        "Average Sentence Length", avgSentenceLength
    ]
