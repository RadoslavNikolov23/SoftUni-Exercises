function passwordValide(password){

    function lengthValid(password){
        return password.length >= 6 && password.length <= 10;
    }

    function contentValid(password){
        const pattern = /^[A-Za-z0-9]+$/;
        return pattern.test(password);
    }

    function digitLengthValid(password){
        let digitCount = 0;
        for (let char of password){
            if (char >= '0' && char <= '9'){
                digitCount++;
            }
        }
        return digitCount >= 2;
    }

    let isValid = true;

        if (!lengthValid(password)){
            console.log("Password must be between 6 and 10 characters");
            isValid = false;
        }

        if (!contentValid(password)){
            console.log("Password must consist only of letters and digits");
            isValid = false;
        }

        if (!digitLengthValid(password)){
            console.log("Password must have at least 2 digits");
            isValid = false;
        }

        if (isValid){
            console.log("Password is valid");
        }
}

passwordValide('logIn');
passwordValide('MyPass123');
passwordValide('Pa$s$s');