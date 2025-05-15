
Dictionary<string, List<string>> wordsSynonyms = new Dictionary<string, List<string>>();

int number = int.Parse(Console.ReadLine());

for (int i = 0; i < number; i++)
{
    string word = Console.ReadLine();
    string synonym = Console.ReadLine();

    if (!wordsSynonyms.ContainsKey(word))
    {
        wordsSynonyms.Add(word,new List<string>());
    }

    wordsSynonyms[word].Add(synonym);
}

foreach (var word in wordsSynonyms)
{
    Console.WriteLine($"{word.Key} - {String.Join(", ",word.Value)}");
}
