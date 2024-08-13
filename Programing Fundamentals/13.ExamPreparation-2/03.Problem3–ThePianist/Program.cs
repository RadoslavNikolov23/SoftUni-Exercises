namespace _03.Problem3_ThePianist
{
    internal class Program
    {
        class Pieces
        {
            public Pieces(string composer, string key)
            {
                Composer = composer;
                Key = key;
            }
            public string Composer { get; set; }
            public string Key { get; set; }

        }
        static void Main(string[] args)
        {

            int numberOfPieces = int.Parse(Console.ReadLine());

            Dictionary<string, Pieces> pieces = new Dictionary<string, Pieces>();

            for (int i = 0; i < numberOfPieces; i++)
            {
                string[] inputArray = Console.ReadLine().Split("|");
                string piece = inputArray[0];
                string composer = inputArray[1];
                string key = inputArray[2];

                pieces.Add(piece, new Pieces(composer, key));
            }

            string commands;
            while ((commands = Console.ReadLine()) != "Stop")
            {
                string[] commandsArray = commands.Split("|");
                string firstComand = commandsArray[0];

                switch (firstComand)
                {
                    case "Add":
                        string pieceAdd = commandsArray[1];
                        string composerAdd = commandsArray[2];
                        string keyAdd = commandsArray[3];
                        pieces = PiecesToAdd(pieces, pieceAdd, composerAdd, keyAdd);
                        break;

                    case "Remove":
                        string pieceRemove = commandsArray[1];
                        pieces = PiecesToRemove(pieces, pieceRemove);
                        break;

                    case "ChangeKey":
                        string pieceChange = commandsArray[1];
                        string keyChange = commandsArray[2];
                        pieces = PiecesToChangeKey(pieces, pieceChange, keyChange);
                        break;
                }
            }

            foreach (var (piece, comKey) in pieces)
            {
                Console.WriteLine($"{piece} -> Composer: {comKey.Composer}, Key: {comKey.Key}");
            }
        }

        static Dictionary<string, Pieces> PiecesToChangeKey(Dictionary<string, Pieces> pieces, string pieceChange, string keyChange)
        {
            if (!pieces.ContainsKey(pieceChange))
            {
                Console.WriteLine($"Invalid operation! {pieceChange} does not exist in the collection.");
            }
            else
            {
                pieces[pieceChange].Key = keyChange;
                Console.WriteLine($"Changed the key of {pieceChange} to {keyChange}!");
            }

            return pieces;
        }

        static Dictionary<string, Pieces> PiecesToRemove(Dictionary<string, Pieces> pieces, string pieceRemove)
        {
            if (!pieces.ContainsKey(pieceRemove))
            {
                Console.WriteLine($"Invalid operation! {pieceRemove} does not exist in the collection.");
            }
            else
            {
                pieces.Remove(pieceRemove);
                Console.WriteLine($"Successfully removed {pieceRemove}!");
                pieces = new Dictionary<string, Pieces>(pieces);
            }
            return pieces;
        }

        static Dictionary<string, Pieces> PiecesToAdd(Dictionary<string, Pieces> pieces, string pieceAdd, string composerAdd, string keyAdd)
        {
            if (pieces.ContainsKey(pieceAdd))
            {
                Console.WriteLine($"{pieceAdd} is already in the collection!");
            }
            else
            {
                pieces.Add(pieceAdd, new Pieces(composerAdd, keyAdd));
                Console.WriteLine($"{pieceAdd} by {composerAdd} in {keyAdd} added to the collection!");
            }
            return pieces;
        }
    }
}