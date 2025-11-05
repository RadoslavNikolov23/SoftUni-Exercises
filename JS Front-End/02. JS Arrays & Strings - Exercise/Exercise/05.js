function solve(words, text) {

    let wordsArray = words.split(', ');

    for (let word of wordsArray) {
        const regex = new RegExp(`\\*{${word.length}}`);
        text = text.replace(regex, word);
    }

    console.log(text);

}

solve('great', 'softuni is ***** place for learning new programming languages');
solve('great, learning', 'softuni is ***** place for ******** new programming languages');