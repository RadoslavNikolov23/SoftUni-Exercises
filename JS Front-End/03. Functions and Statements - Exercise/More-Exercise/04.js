/**
 * Crystal processing optimization program
 * @param {Array} arrayNumbers - First element is target thickness, rest are crystal thicknesses
 */
function solve(arrayNumbers) {
    
  function cut(cristal) {
    return cristal / 4;
  }

  function lap(cristal) {
    return cristal * 0.8;
  }

  function grind(cristal) {
    return cristal - 20;
  }

  function etch(cristal) {
    return cristal - 2;
  }
  function xRay(cristal) {
    return cristal + 1;
  }

  function transportingAndWashing(cristal) {
    return Math.floor(cristal);
  }

  function radioCrystals(cristalOre, targetThickness, funcName) {
    let count = 0;
    while (cristalOre >= targetThickness - 1) {
      let tempOre = funcName(cristalOre);
      if (tempOre < targetThickness - 1) {
        break;
      }
      cristalOre = tempOre;
      count++;
    }
    if (count > 0) {
      const functText =
        funcName.name.slice(0, 1).toUpperCase() + funcName.name.slice(1);
      console.log(`${functText} x${count}`);
      cristalOre = transportingAndWashing(cristalOre);
      console.log(`Transporting and washing`);
      count = 0;
    }
    return cristalOre;
  }

  const targetThickness = arrayNumbers.shift();

  for (let cristalOre of arrayNumbers) {
    console.log(`Processing chunk ${cristalOre} microns`);

    cristalOre = radioCrystals(cristalOre, targetThickness, cut);
    cristalOre = radioCrystals(cristalOre, targetThickness, lap);
    cristalOre = radioCrystals(cristalOre, targetThickness, grind);
    cristalOre = radioCrystals(cristalOre, targetThickness, etch);

    if (cristalOre - targetThickness === -1) {
      cristalOre = xRay(cristalOre);
      console.log(`X-ray x1`);
    }

    console.log(`Finished crystal ${cristalOre} microns`);
  }
}

solve([1375, 50000]);
solve([1000, 4000, 8100]);
