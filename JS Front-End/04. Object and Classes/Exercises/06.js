function solve(arrWords){

    let targetWords = arrWords.shift().split(' ');
    let wordsCount = {};

    for(const word of targetWords){
        wordsCount[word] = 0;
    }

    for(const word of arrWords){
        if(wordsCount.hasOwnProperty(word)){
            wordsCount[word]++;
        }
    }

    for(const [word, count] of Object.entries(wordsCount).sort((a,b) => b[1] - a[1])){
        console.log(`${word} - ${count}`);
    }
}

solve([
'this sentence', 
'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
]);

solve([
'is the', 
'first', 'sentence', 'Here', 'is', 'another', 'the', 'And', 'finally', 'the', 'the', 'sentence']);