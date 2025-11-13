function solve(input){

    let movies = {};
    let patterns = {
        addMovie: /^addMovie (?<name>.+)$/,
        directedBy: /^(?<name>.+) directedBy (?<director>.+)$/,
        onDate: /^(?<name>.+) onDate (?<date>.+)$/
    }

    for(const element of input){
     
        let match;
        if((match= element.match(patterns.addMovie))!=null){
            const name = match.groups["name"];

            movies[name] = {name};
        }else if((match = element.match(patterns.directedBy))!=null){
            const name = match.groups["name"];
            const director = match.groups["director"];

            if(movies[name]){
                movies[name]["director"] = director;
            }
        }else if((match = element.match(patterns.onDate))!=null){
            const name = match.groups["name"];
            const date = match.groups["date"];

            if(movies[name]){
                movies[name]["date"] = date;
            }

        }

        

    }

    const moviesArr = Object.values(movies);
        for (let movie of moviesArr){
            if (movie.hasOwnProperty("name") && movie.hasOwnProperty("director") && movie.hasOwnProperty("date"))
                console.log(JSON.stringify(movie));
            
        }
}

solve([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
    ]);

solve([
    'addMovie The Avengers',
    'addMovie Superman',
    'The Avengers directedBy Anthony Russo',
    'The Avengers onDate 30.07.2010',
    'Captain America onDate 30.07.2010',
    'Captain America directedBy Joe Russo'
    ]);