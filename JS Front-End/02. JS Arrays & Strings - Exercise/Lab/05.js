/**
 * 
 * @param {string} text 
 * @param {string} censoredWord 
 */

function solve(text, censoredWord){
    
    const censoredText = text.replaceAll(censoredWord, '*'.repeat(censoredWord.length));
    console.log(censoredText);

}

solve('A small sentence with some words', 'small');
solve('Find the hidden word', 'hidden');