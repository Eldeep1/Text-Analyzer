module TextAnalysis

open System.Text.RegularExpressions
open System

(*  
   variable -> word - > when we add space
   variable -> sentence - > when we add '.'
   variable -> paragraph - > when we add '\n'
        - check if multiple '\n'
   --------------------

   word frequancy ??
   - display max frequant word

   ---------------------
   average sentence length
        - variable -> total number of words
        - variable -> total number of sentences 
        - avg sentence length = total number of words / total number of sentences 
*)

let analyzeText (txt : string) = 

    let mutable  sentences = 0
    let mutable  paragraphs = 0

    let rec split (txt: string) (index: int) (word: string) (last_char : char) (word_list : string list) = 
        if index < txt.Length then
            let current = txt.[index]
            let next_index =  index+1
            if current >= 'a' && current <= 'z' || current >= 'A' && current <= 'Z' then
                split txt next_index (word + string current) current word_list
            else
                match current with
                    | '.'  ->
                        if last_char <> current then
                            sentences <- sentences + 1
                    | '\n' ->
                        if last_char <> current then
                            paragraphs <- paragraphs + 1 
                        if last_char <> '.' then
                            sentences <- sentences + 1
                        printfn "%c" last_char
                    | _ ->
                        ()
                if word <> "" then
                    split txt next_index "" current (word :: word_list)
                else
                    split txt next_index "" current word_list
        else
            word_list
    
    let word_list = split txt 0 "" txt.[0] []

    let mostFrequencyWord,mostFrequencyCount = 
        word_list 
        |> List.map (fun str -> str.ToLower())
        |> List.countBy id  
        |> List.maxBy snd

    let words = word_list.Length
    let avgLength = words / sentences

    printfn "words %i" words
    printfn "sentences %i" sentences
    printfn "paragraphs %i" paragraphs
    printfn "mostFrequencyWord %s" mostFrequencyWord
    printfn "mostFrequencyCount %i" mostFrequencyCount
    printfn "avgLength %i" avgLength

    Map [
        "Number of Words", words.ToString()
        "Number of Sentences", sentences.ToString()
        "Number of Paragraphs", paragraphs.ToString()
        "Most Frequent Word",mostFrequencyWord.ToString()
        "Most Frequency Count",mostFrequencyCount.ToString()
        "Average Sentence Length", avgLength.ToString()
    ]

