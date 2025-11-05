function solve(wordToFind, text){
    let pattern = new RegExp(`\\b${wordToFind}\\b`, 'gi');
    let array = text.split(' ');

    for(let word of array){
        if(word.toLowerCase() === wordToFind.toLowerCase()){
            console.log(wordToFind);
            return;
        }
    }

    console.log(`${wordToFind} not found!`);


}


solve('javascript','JavaScript is the best programming language');
solve('python','JavaScript is the best programming language');