function solve(input){

    let newInput = input.split(/[^a-zA-Z0-9]+/)
                        .filter(char => char !== '');

    console.log(newInput.map(char => char.toUpperCase()).join(', '));
    
}

solve('Hi, how are you?');
solve('hello');