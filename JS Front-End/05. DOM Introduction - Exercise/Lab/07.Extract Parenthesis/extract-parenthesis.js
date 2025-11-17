function extract(content) {
    
    const getEl = document.getElementById(content);
    const patternt = /\(.+?\)/g
    
    const text = getEl.textContent;
    const matchArr = text.match(patternt)
                         .map(x => x.slice(1,-1));

                         console.log(matchArr.join('; '));


}