function converToJson(firstName,lastName,hairColor){

    let person = {
        name:firstName,
        lastName,
        hairColor
    }

    let personJson = JSON.stringify(person);

    console.log(personJson);

}

converToJson('George', 'Jones', 'Brown');
converToJson('Peter', 'Smith', 'Blond');