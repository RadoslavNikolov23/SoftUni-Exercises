function solve(input){

    const arrayInput = input.split(' ');
    const wordsCount = {};

    for(const word of arrayInput){
        const wordLower = word.toLowerCase();
        if(!wordsCount.hasOwnProperty(wordLower)){
            wordsCount[wordLower] = 0;
        }
        wordsCount[wordLower]++;
    }

    console.log(`${Object.keys(wordsCount)
                         .filter(word => wordsCount[word] % 2 !== 0)
                         .sort((a,b)=> wordsCount[b] - wordsCount[a])
                         .join(' ')} `);
    
};

solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
solve('Cake IS SWEET is Soft CAKE sweet Food');