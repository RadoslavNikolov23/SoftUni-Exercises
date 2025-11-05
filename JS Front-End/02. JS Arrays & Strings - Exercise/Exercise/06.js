function solve(input){
    let pattern = /#([A-Za-z]+)/g;
    let matches = input.match(pattern);
    if (matches) {
        let result = matches.map(word => word.slice(1));
        console.log(result.join('\n'));
    }

}

solve('Nowadays everyone uses # to tag a #special word in #socialMedia');
solve('The symbol # is known #variously in English-speaking #regions as the #number sign');