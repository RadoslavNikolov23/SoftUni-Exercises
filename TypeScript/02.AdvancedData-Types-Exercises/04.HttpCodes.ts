type httpCode = {code: 200 | 201 | 301, text: string};
type httpCodeWithChar = { code: 400 | 404 | 500, text: string, printChars?: number};

function htttpCodeInfromation(httpCode: httpCode | httpCodeWithChar) :void{

    // I Case:
    // switch(httpCode.code){
    //     case 200:
    //     case 201:
    //     case 301: console.log(httpCode.text); return;
    //     case 400:
    //     case 404:
    //     case 500: console.log(httpCode.text.slice(0,httpCode.printChars)); return;
    // }

    // II Case:
    if("printChars" in httpCode){
        console.log(httpCode.text.substring(0,httpCode.printChars));
    }
    else{
        console.log(httpCode.text);
    }
}

htttpCodeInfromation({ code: 200, text: 'OK'});
htttpCodeInfromation({ code: 201, text: 'Created'});
htttpCodeInfromation({ code: 400, text: 'Bad Request', printChars: 4});
htttpCodeInfromation({ code: 404, text: 'Not Found'});
htttpCodeInfromation({ code: 404, text: 'Not Found', printChars: 3});
htttpCodeInfromation({ code: 500, text: 'Internal Server Error', printChars: 1});