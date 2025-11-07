function charInRange(charOne, charTwo) {
    
  function getCharCode(char) {
    return char.charCodeAt(0);
  }

  let startCharCode = Math.min(getCharCode(charOne), getCharCode(charTwo));
  let endCharCode = Math.max(getCharCode(charOne), getCharCode(charTwo));

  let result = [];

  for (let i = startCharCode + 1; i < endCharCode; i++) {
    result.push(String.fromCharCode(i));
  }

  console.log(result.join(" "));
}

charInRange("a", "d");
charInRange("#", ":");
charInRange("C", "#");
