

List<string> listWords=Console.ReadLine()
    .Split()
    .ToList();

Dictionary<string,int> wordDictionary=new Dictionary<string,int>();


foreach (string word in listWords)
{
    string wordLowerCase= word.ToLower();

    if (!wordDictionary.ContainsKey(wordLowerCase))
    {
        wordDictionary.Add(wordLowerCase,0);
    }
    wordDictionary[wordLowerCase]++;
}

foreach (var word in wordDictionary)
{
    if (word.Value % 2 != 0)
    {
        Console.Write(word.Key + " ");
    }
}