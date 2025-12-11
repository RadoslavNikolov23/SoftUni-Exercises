function solve(inputArray){

    class farmer{
        constructor(name, location, tasks){
            this.name = name;
            this.location = location;
            this.tasks = new Set(tasks);
        }
    }

    const farmersNumber = Number(inputArray.shift());
    const farmers = {};

    for(let i = 0; i < farmersNumber; i++){
        const [name, location, tasks] = inputArray.shift().split(" ");
        const farmerObj = new farmer(name, location, tasks.split(","));
        farmers[name] = farmerObj;
    }

    let commandLine  = inputArray.shift();

    while(commandLine !== "End"){
        const [command, name, param1, param2] = commandLine.split(" / ");

        if(command === "Execute"){

            const farmerObj = farmers[name];
            const location = param1;
            const task = param2;

            if(farmerObj.location === location && farmerObj.tasks.has(task)){
                console.log(`${name} has executed the task: ${task}!`);
            }else{
                console.log(`${name} cannot execute the task: ${task}.`);
            }

        }else if(command === "Change Area"){
             const farmerObj = farmers[name];
            const newLocation = param1;
            farmerObj.location = newLocation;
            console.log(`${name} has changed their work area to: ${newLocation}`);
        }else if(command === "Learn Task"){
            const newTask = param1;
            const farmerObj = farmers[name];

            if(!farmerObj.tasks.has(newTask)){
                farmerObj.tasks.add(newTask);
                console.log(`${name} has learned a new task: ${newTask}.`);
            } else{
                console.log(`${name} has already learned the task: ${newTask}.`);
            }
        }

        commandLine  = inputArray.shift();
    }

    for(const farmer of Object.values(farmers)){
        const sortedTasks = Array.from(farmer.tasks)
                                 .sort((a,b) => a.localeCompare(b));
        console.log(`Farmer: ${farmer.name}, Area: ${farmer.location}, Tasks: ${sortedTasks.join(", ")}`);
    }
}


solve([
  "2",
  "John garden watering,weeding",
  "Mary barn feeding,cleaning",
  "Execute / John / garden / watering",
  "Execute / Mary / garden / feeding",
  "Learn Task / John / planting",
  "Execute / John / garden / planting",
  "Change Area / Mary / garden",
  "Execute / Mary / garden / cleaning",
  "End"
]
);

solve([
  "3",
  "Alex apiary harvesting,honeycomb",
  "Emma barn milking,cleaning",
  "Chris garden planting,weeding",
  "Execute / Alex / apiary / harvesting",
  "Learn Task / Alex / beeswax",
  "Execute / Alex / apiary / beeswax",
  "Change Area / Emma / apiary",
  "Execute / Emma / apiary / milking",
  "Execute / Chris / garden / watering",
  "Learn Task / Chris / pruning",
  "Execute / Chris / garden / pruning",
  "End"
]
);