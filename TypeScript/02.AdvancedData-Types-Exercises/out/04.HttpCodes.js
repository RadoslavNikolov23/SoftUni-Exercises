"use strict";
function htttpCodeInfromation(httpCode) {
    let resultText = httpCode.text;
    if (httpCode.printChars) {
        resultText = httpCode.text.substring(0, httpCode.printChars);
    }
    console.log(resultText);
}
htttpCodeInfromation({ code: 200, text: 'OK' });
htttpCodeInfromation({ code: 201, text: 'Created' });
htttpCodeInfromation({ code: 400, text: 'Bad Request', printChars: 4 });
htttpCodeInfromation({ code: 404, text: 'Not Found' });
htttpCodeInfromation({ code: 404, text: 'Not Found', printChars: 3 });
htttpCodeInfromation({ code: 500, text: 'Internal Server Error', printChars: 1 });
//# sourceMappingURL=04.HttpCodes.js.map