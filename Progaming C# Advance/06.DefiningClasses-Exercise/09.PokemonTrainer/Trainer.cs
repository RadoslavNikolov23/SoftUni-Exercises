using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int badges;
        private List<Pokemon> pokemon;

        public Trainer(string name, int badges, List<Pokemon> pokemon)
        {
            Name = name;
            Badges = badges;
            Pokemon = pokemon;
        }

        public List<Pokemon> Pokemon
        {
            get { return pokemon; }
            set { pokemon = value; }
        }

        public int Badges
        {
            get { return badges; }
            set { badges = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
