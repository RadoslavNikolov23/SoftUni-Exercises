function solve(inputArray){
    
    class Manuscript{
        constructor(title, topicsList, preservationLevel){
            this.title = title;
            this.topicsList = topicsList;
            this.preservationLevel = Number(preservationLevel);
        }

        researchManuscript(topic, requiredPreservationLevel){
            if (
                this.topicsList.has(topic) &&
                this.preservationLevel >= requiredPreservationLevel &&
                this.preservationLevel > 0
            ) {
                this.preservationLevel -= requiredPreservationLevel;
                return true;
            }
            return false;
        }

        restoreManuscript(preservationAmountToRestore){
            if(this.preservationLevel === 100){
                this.preservationLevel = 100;
                return {restored: true, conditionDifference: 0};
            }

            if(this.preservationLevel + preservationAmountToRestore >= 100){
                const restoredDifference = 100 - this.preservationLevel;
                this.preservationLevel = 100;
                return {restored: false, restoredDifference: restoredDifference};
            }

            this.preservationLevel += preservationAmountToRestore;
            return {restored: false, restoredDifference: preservationAmountToRestore};
        }

        addToCatalog(newSubject){
            if(!this.topicsList.has(newSubject)){
                this.topicsList.add(newSubject);
                return {added: true};
            }

            return {added: false};
        }
    }

    let manuscriptsCollection = new Map();
    let numberOfManuscripts = Number(inputArray.shift());

    for(let i = 0; i < numberOfManuscripts; i++){
        let [title, topics, preservationLevel] = inputArray.shift().split("-");
        let topicsList = new Set(topics.split(","));
        let manuscript = new Manuscript(title, topicsList, preservationLevel);
        manuscriptsCollection.set(title, manuscript);
    }

    let commandLine = inputArray.shift();

    while(commandLine != "Restoration Complete!"){
        const commandsParts = commandLine.split(" & ");
        const command = commandsParts[0];
        
        if(command === "Research"){
            const title = commandsParts[1];
            const topic = commandsParts[2];
            const requiredPreservationLevel = Number(commandsParts[3]);

            if(manuscriptsCollection.has(title)){

                const manuscript = manuscriptsCollection.get(title);
                const isResearched = manuscript.researchManuscript(topic, requiredPreservationLevel);
                if(isResearched){
                    console.log(`${title} has been researched on ${topic} and now has ${manuscript.preservationLevel} preservation level!`);
                }else{
                    console.log(`${title} cannot be researched on ${topic} or is in poor condition!`);
                }
               
            }else{
                console.log(`${title} cannot be researched on ${topic} or is in poor condition!`);	
            }

        }else if(command === "Restore"){
            "Restore & {Title} & {Restoration Effort}"
            const title = commandsParts[1];
            const restorationEffort = Number(commandsParts[2]);

            const manuscript = manuscriptsCollection.get(title);

            if(manuscript){
                const restorationResult = manuscript.restoreManuscript(restorationEffort);

                if(restorationResult.restored){
                    console.log(`${title} is already fully restored!"`);
                }else{
                    console.log(`${title} has been restored and gained ${restorationResult.restoredDifference} preservation level!`);
                }
            }

            
        }else if(command === "Catalog"){
            "Catalog & {Title} & {New Topic}"
            const title = commandsParts[1];
            const newTopic = commandsParts[2];

            const manuscript = manuscriptsCollection.get(title);

            if(manuscript){
                const catalogResult = manuscript.addToCatalog(newTopic);

                if(catalogResult.added){
                    console.log(`${title} has been catalogued with ${newTopic}!`);
                }else{
                    console.log(`${title} is already catalogued with ${newTopic}.`);
                }
            }
        }


        commandLine = inputArray.shift();
    }

    for(const [title, manuscript] of manuscriptsCollection){
        console.log(`Manuscript: ${title}`);
        console.log(` - Topics: ${Array.from(manuscript.topicsList).join(", ")}`);
        console.log(` - Preservation Level: ${manuscript.preservationLevel}`);
    }




}

solve ([
    "3",
    "Codex Gigas-Demonology,Herbalism-80",
    "Voynich Manuscript-Cryptography-10",
    "Book of Kells-Illumination-60",
    "Research & Codex Gigas & Herbalism & 30",
    "Restore & Voynich Manuscript & 20",
    "Restore & Book of Kells & 50",
    "Catalog & Book of Kells & Calligraphy",
    "Research & Book of Kells & Calligraphy & 70", 
    "Restoration Complete!"
    ]);

solve([
    "2",
    "Voynich Manuscript-Cryptography-100",
    "Book of Kells-Illumination-10",
    "Restore & Voynich Manuscript & 20",
    "Restore & Book of Kells & 50",
    "Restore & Book of Kells & 50",
    "Research & Book of Kells & Illumination & 70",
    "Restoration Complete!"
    ]);


        