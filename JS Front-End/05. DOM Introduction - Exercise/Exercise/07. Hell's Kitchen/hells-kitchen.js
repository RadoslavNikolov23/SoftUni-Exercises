function solve() {

  const patternt = /(?<name>[A-Za-z]+) - (?<workers>[^"]+)/g;

  const inputArea = document.querySelector(`div#inputs textarea`);

  const matches = inputArea.value.match(patternt);

  let restorantData = {};

  for (const match of matches) {

    const arrayMatch = match.split(" - ");
    const restorantName = arrayMatch[0];
    const workersData = arrayMatch[1];
    const workers = workersData.split(", ");

    if (!restorantData[restorantName]) {
      restorantData[restorantName] = [];
    }
    for (const worker of workers) {
      const [name, salary] = worker.split(" ");
      restorantData[restorantName].push({ name, salary: Number(salary) });
    }
  }

  let bestRestorant = "";
  let bestAverageSalary = 0;

  for (const restorant in restorantData) {
    const totalSalary = restorantData[restorant].reduce(
      (acc, worker) => acc + worker.salary, 0);
    const averageSalary = totalSalary / restorantData[restorant].length;

    if (averageSalary > bestAverageSalary) {
      bestAverageSalary = averageSalary;
      bestRestorant = restorant;
    }
  }

  const bestWorkers = restorantData[bestRestorant]
    .sort((a, b) => b.salary - a.salary)
    .map((worker) => `Name: ${worker.name} With Salary: ${worker.salary}`)
    .join(" ");

  const outputArea1 = document.querySelector(`div#bestRestaurant p`);
  const bestSalary = Math.max(...restorantData[bestRestorant].map((w) => w.salary));
  outputArea1.textContent = `Name: ${bestRestorant} Average Salary: ${bestAverageSalary.toFixed(2)} Best Salary: ${bestSalary.toFixed(2)}`;
 
  const outputArea2 = document.querySelector(`div#workers p`);
  outputArea2.textContent = bestWorkers;
}
