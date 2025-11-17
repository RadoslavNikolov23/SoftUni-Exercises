function editElement(elId,match,replacer) {
    
    let htmlEl = elId.textContent;
    let newHtml = htmlEl.replaceAll(match, replacer);
    elId.textContent = newHtml;

}