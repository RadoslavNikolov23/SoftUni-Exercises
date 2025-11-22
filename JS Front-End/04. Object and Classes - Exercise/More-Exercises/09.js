function solve(inputArr) {

    const patters = {
        addLeader: /(.+)\sarrives/,
        addArmy: /(.+):\s(.+),\s(\d+)/,
        addCountArmy: /(.+)\s\+\s(\d+)/,
        delLeader: /(.+)\sdefeated/
    };

    let armies = {};

    for(let element of inputArr){
        let match;

        if((match = element.match(patters.addLeader))!=null){
            let leader = match[1];
            if(!armies.hasOwnProperty(leader)){
                armies[leader] = {};
            }
        }
        else if((match = element.match(patters.addArmy))!=null){
            let leader = match[1];
            let armyName = match[2];
            let armyCount = Number(match[3]);

            if(armies.hasOwnProperty(leader)){
                armies[leader][armyName] = armyCount;
            }
        }
        else if((match = element.match(patters.addCountArmy))!=null){
            let army = match[1];
            let armyCount = Number(match[2]);

            for(const leader in armies){
                if(armies[leader].hasOwnProperty(army)){
                    armies[leader][army] += armyCount;
                }
            }

        }
        else if((match = element.match(patters.delLeader))!=null){
            let leader = match[1];

            if(armies.hasOwnProperty(leader)){
                delete armies[leader];
            }
        }
    }

    let sortedLeaders = Object.entries(armies).sort((a,b)=>{
        let totalA = Object.values(a[1]).reduce((acc,curr)=>acc+curr,0);
        let totalB = Object.values(b[1]).reduce((acc,curr)=>acc+curr,0);

        return totalB - totalA;
    });

    for(const [leader,armyObj] of sortedLeaders){
        let totalArmyCount = Object.values(armyObj).reduce((acc,curr)=>acc+curr,0);
        console.log(`${leader}: ${totalArmyCount}`);

        let sortedArmies = Object.entries(armyObj).sort((a,b)=>b[1]-a[1]);

        for(const [armyName,armyCount] of sortedArmies){
            console.log(`>>> ${armyName} - ${armyCount}`);
        }
    }

}



solve([
  "Rick Burr arrives",
  "Fergus: Wexamp, 30245",
  "Rick Burr: Juard, 50000",
  "Findlay arrives",
  "Findlay: Britox, 34540",
  "Wexamp + 6000",
  "Juard + 1350",
  "Britox + 4500",
  "Porter arrives",
  "Porter: Legion, 55000",
  "Legion + 302",
  "Rick Burr defeated",
  "Porter: Retix, 3205",
]);
solve([
  "Rick Burr arrives",
  "Findlay arrives",
  "Rick Burr: Juard, 1500",
  "Wexamp arrives",
  "Findlay: Wexamp, 34540",
  "Wexamp + 340",
  "Wexamp: Britox, 1155",
  "Wexamp: Juard, 43423",
]);
