function solve(inputArr){

    class Astronaut {
        constructor(name, section, skills) {
            this.name = name;
            this.section = section;
            this.skills = new Set(skills);
        }
    }

    const astronautsNumber = Number(inputArr.shift());
    const astronauts = new Map();

    for (let i = 0; i < astronautsNumber; i++) {
        const [name, section, skillsArr] = inputArr.shift().split(' ');
        const skills = skillsArr.split(',');
        astronauts.set(name, new Astronaut(name, section, skills));
    }
    
    let commandLine = inputArr.shift().split(' / ');
    
    while(commandLine[0] !== "End"){
        const command = commandLine[0];
        const astronautName = commandLine[1];

        switch(command){
            case "Perform":
               const section = commandLine[2];
               const skill = commandLine[3];

               const currentAstronautToPerform = astronauts.get(astronautName);

               if(currentAstronautToPerform.section === section && currentAstronautToPerform.skills.has(skill)){  
                     console.log(`${astronautName} has successfully performed the skill: ${skill}!`);
                } else {
                    console.log(`${astronautName} cannot perform the skill: ${skill}.`);
                }
                break;

            case "Transfer":
                const newSection = commandLine[2];
                const currentAstronautToTransfer = astronauts.get(astronautName);

                console.log(`${astronautName} has been transferred to: ${newSection}`);
                currentAstronautToTransfer.section = newSection;
                break;
    
            case "Learn Skill":
                const newSkill = commandLine[2];
                const currentAstronautToLearn = astronauts.get(astronautName);
                if(currentAstronautToLearn.skills.has(newSkill)){
                    console.log(`${astronautName} already knows the skill: ${newSkill}.`);
                } else {
                    currentAstronautToLearn.skills.add(newSkill);
                    console.log(`${astronautName} has learned a new skill: ${newSkill}.`);
                }
                break;
        }

        commandLine = inputArr.shift().split(' / ');
    }

    for (const astronaut of astronauts.values()) {
        astronaut.skills = Array.from(astronaut.skills)
                                 .sort((a, b) => a.localeCompare(b));
        console.log(`Astronaut: ${astronaut.name}, Section: ${astronaut.section}, Skills: ${astronaut.skills.join(', ')}`);
    }
}


solve([
  "2",
  "Alice command_module piloting,communications",
  "Bob engineering_bay repair,maintenance",
  "Perform / Alice / command_module / piloting",
  "Perform / Bob / command_module / repair",
  "Learn Skill / Alice / navigation",
  "Perform / Alice / command_module / navigation",
  "Transfer / Bob / command_module",
  "Perform / Bob / command_module / maintenance",
  "End"
]);

solve([
  "3",
  "Tom engineering_bay construction,maintenance",
  "Sara research_lab analysis,sampling",
  "Chris command_module piloting,communications",
  "Perform / Tom / engineering_bay / construction",
  "Learn Skill / Sara / robotics",
  "Perform / Sara / research_lab / robotics",
  "Transfer / Chris / research_lab",
  "Perform / Chris / research_lab / piloting",
  "Learn Skill / Tom / diagnostics",
  "Perform / Tom / engineering_bay / diagnostics",
  "End"
]);