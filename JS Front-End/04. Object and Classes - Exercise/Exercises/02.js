function solve(inputArr) {

    let towns = [];

    for(let el of inputArr) {
        let [town, latitude, longitude] = el.split(" | ");

        let townObj = {
            town: town,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2)
        };

        towns.push(townObj);
    }

    for(let town of towns) {
        console.log(town);
    }
}

solve(["Sofia | 42.696552 | 23.32601", "Beijing | 39.913818 | 116.363625"]);
solve(["Plovdiv | 136.45 | 812.575"]);
