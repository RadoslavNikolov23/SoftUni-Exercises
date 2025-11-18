function toggle() {
    const contentElem = document.getElementById('extra');
    const buttonElem = document.querySelector('div span.button');
   
    if (buttonElem.innerHTML === 'More') {
        contentElem.style.display = 'block';
        buttonElem.innerHTML = 'Less';
    } else {
        contentElem.style.display = 'none';
        buttonElem.innerHTML = 'More';
    }
}