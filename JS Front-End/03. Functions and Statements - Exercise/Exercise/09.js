function loadingBar(number) {

  function generateLoadingBar(devidedByTen) {
    let output = [];

    for (let i = 0; i < 10; i++) {
      if (i < devidedByTen) {
        output.push("%");
      } else {
        output.push(".");
      }
    }
    return output;
  }

  function writeLoadingBar(number, loadingBar) {
    if (number === 100) {
      console.log("100% Complete!");
      console.log(`[${loadingBar.join("")}]`);
    } else {
      console.log(`${number}% [${loadingBar.join("")}]`);
      console.log("Still loading...");
    }
  }

  const devidedByTen = number / 10;
  let output = generateLoadingBar(devidedByTen);

  writeLoadingBar(number, output);
}

loadingBar(30);
loadingBar(50);
loadingBar(100);
