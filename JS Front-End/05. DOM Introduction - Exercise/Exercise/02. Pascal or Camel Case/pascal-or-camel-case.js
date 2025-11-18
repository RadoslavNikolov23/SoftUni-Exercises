function solve() {
  function checkTextInput(textInput) {
  if (!textInput) {
    return false;
  }
  return true;
}

function checkNamingConvention(namingConvention) {
  if (namingConvention !== "Camel Case" && namingConvention !== "Pascal Case") {
    return false;
  }
  return true;
}

function capitalize(word, count, namingConvention) {
  if (count == 0) {
    if (namingConvention === "Camel Case") {
      return word.charAt(0).toLowerCase() + word.slice(1).toLowerCase();
    } else if (namingConvention === "Pascal Case") {
      return word.charAt(0).toUpperCase() + word.slice(1).toLowerCase();
    } else return "Error!";
  }

  return word.charAt(0).toUpperCase() + word.slice(1).toLowerCase();
}

  const textInput = document.getElementById("text").value;
  const namingConvention = document.getElementById("naming-convention").value;
  const resultElement = document.getElementById("result");

  let words = textInput.split(" ");
  let result = "";

  if (!checkTextInput(textInput)) result = "Error!";

  for (let i = 0; i < words.length; i++) {

    if (!checkNamingConvention(namingConvention)) {
      result = "Error!";
      break;
    }
    result += capitalize(words[i], i, namingConvention);
  }

  resultElement.textContent = result;
}
