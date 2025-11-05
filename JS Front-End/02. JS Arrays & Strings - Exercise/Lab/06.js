function solve(text,wordToFind) {

    let count = 0;

    for(let word of text.split(' ')){
        if(word === wordToFind){
            count++;
        }
    }
    console.log(count);
}

solve('This is a word and it also is a sentence','is');
solve('softuni is great place for learning new programming languages','softuni');