function solve(inpObj, inpArray) {

    inpObj["Open Tabs"] = inpObj["Open Tabs"] || [];
    inpObj["Recently Closed"] = inpObj["Recently Closed"] || [];
    inpObj["Browser Logs"] = inpObj["Browser Logs"] || [];

  for (let command of inpArray) {
    let [action, site] = command.split(" ");

    if (action === "Open") {
        inpObj["Open Tabs"].push(site);
        inpObj["Browser Logs"].push(command);
    } else if (action === "Close") {
        let index =  inpObj["Open Tabs"].indexOf(site);
        if (index !== -1) {
            inpObj["Open Tabs"].splice(index, 1);
            inpObj["Recently Closed"].push(site);
            inpObj["Browser Logs"].push(command);
        }
    } else if (command === "Clear History and Cache") {
        inpObj["Open Tabs"] = [];
        inpObj["Recently Closed"] = [];
        inpObj["Browser Logs"] = [];
    }
  }

  console.log(inpObj["Browser Name"]);
  console.log(`Open Tabs: ${inpObj["Open Tabs"].join(", ")}`);
  console.log(`Recently Closed: ${ inpObj["Recently Closed"].join(", ")}`);
  console.log(`Browser Logs: ${inpObj["Browser Logs"].join(", ")}`);
}

solve(
  {
    "Browser Name": "Google Chrome",
    "Open Tabs": ["Facebook", "YouTube", "Google Translate"],
    "Recently Closed": ["Yahoo", "Gmail"],
    "Browser Logs": [
      "Open YouTube",
      "Open Yahoo",
      "Open Google Translate",
      "Close Yahoo",
      "Open Gmail",
      "Close Gmail",
      "Open Facebook",
    ],
  },
  ["Close Facebook", "Open StackOverFlow", "Open Google"]
);

solve(
  {
    "Browser Name": "Mozilla Firefox",
    "Open Tabs": ["YouTube"],
    "Recently Closed": ["Gmail", "Dropbox"],
    "Browser Logs": [
      "Open Gmail",
      "Close Gmail",
      "Open Dropbox",
      "Open YouTube",
      "Close Dropbox",
    ],
  },
  ["Open Wikipedia", "Clear History and Cache", "Open Twitter"]
);
