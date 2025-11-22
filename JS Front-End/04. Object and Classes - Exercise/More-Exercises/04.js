function solve(inputArray) {
  const allFlights = inputArray[0];
  const newStatus = inputArray[1];
  const flightStatus = inputArray[2];

  const flightMap = {};

  for (const flightInfo of allFlights) {
    const regex = /^(?<flight>\w+) (?<city>.+)/;
    const match = flightInfo.match(regex);

    const flightNumber = match.groups.flight;
    const destination = match.groups.city;
    
    flightMap[flightNumber] = { destination, status: "Ready to fly" };
  }

  for (const statusInfo of newStatus) {
    const regex = /^(?<flight>\w+) (?<status>.+)/;
    const match = statusInfo.match(regex);

    const flightNumber = match.groups.flight;
    const status = match.groups.status;

    if (flightMap.hasOwnProperty(flightNumber)) {
      flightMap[flightNumber].status = status;
    }
  }

  for(const flightNumber in flightMap) {
    if (flightMap[flightNumber].status === flightStatus[0]) {
      console.log({ Destination: flightMap[flightNumber].destination, Status: flightMap[flightNumber].status });
    }
  }
}

solve([
  [
    "WN269 Delaware",
    "FL2269 Oregon",
    "WN498 Las Vegas",
    "WN3145 Ohio",
    "WN612 Alabama",
    "WN4010 New York",
    "WN1173 California",
    "DL2120 Texas",
    "KL5744 Illinois",
    "WN678 Pennsylvania",
  ],
  [
    "DL2120 Cancelled",
    "WN612 Cancelled",
    "WN1173 Cancelled",
    "SK430 Cancelled",
  ],
  ["Cancelled"],
]);

solve([
  [
    "WN269 Delaware",
    "FL2269 Oregon",
    "WN498 Las Vegas",
    "WN3145 Ohio",
    "WN612 Alabama",
    "WN4010 New York",
    "WN1173 California",
    "DL2120 Texas",
    "KL5744 Illinois",
    "WN678 Pennsylvania",
  ],
  [
    "DL2120 Cancelled",
    "WN612 Cancelled",
    "WN1173 Cancelled",
    "SK330 Cancelled",
  ],
  ["Ready to fly"],
]);
