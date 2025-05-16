function summarizePerson(
    id:number,
    firstName:string,
    lastName:string,
    age:number,
    middleName?:string,
    hobbies?:string[],
    workInfo?:[string,number]
): [number,string,number,string,string]{

    const fullName:string=middleName? `${firstName} ${middleName} ${lastName}` :
                                      `${firstName} ${lastName}`;

    const hobbiessStr:string=hobbies? hobbies.join(", ") : "-";
    const workInfoStr:string=workInfo? `${workInfo[0]} -> ${workInfo[1]}` : "-";

    return [id,fullName,age,hobbiessStr,workInfoStr]
}

console.log(summarizePerson(12, 'Eliot', 'Des', 20, 'Braylen', ['tennis', 'football', 'hiking'], ['Sales Consultant', 2500]));
console.log(summarizePerson(20, 'Mary', 'Trent', 25, undefined, ['fitness', 'rowing']));
console.log(summarizePerson(21, 'Joseph', 'Angler', 28));
console.log(summarizePerson(21, 'Kristine', 'Neva', 23, ''));
