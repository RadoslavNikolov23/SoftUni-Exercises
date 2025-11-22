function solver(inputArr) {
  let heroes = [];

  for (const element of inputArr) {
    const [name, level, items] = element.split(" / ");

    heroes.push({
      name,
      level: Number(level),
      items: items ? items.split(", ") : [],
    });
  }

  const sortedHeroes = heroes.sort((a, b) => a.level - b.level);

  for (const hero of sortedHeroes) {
    console.log(
      `Hero: ${hero.name}\nlevel => ${hero.level}\nitems => ${hero.items.join(", ")}`
    );
  }
}

solver([
  "Isacc / 25 / Apple, GravityGun",
  "Derek / 12 / BarrelVest, DestructionSword",
  "Hes / 1 / Desolator, Sentinel, Antara",
]);

solver([
  "Batman / 2 / Banana, Gun",
  "Superman / 18 / Sword",
  "Poppy / 28 / Sentinel, Antara",
]);
