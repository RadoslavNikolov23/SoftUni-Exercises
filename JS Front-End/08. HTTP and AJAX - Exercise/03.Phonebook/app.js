function attachEvents() {

    const getAndPostUrl = 'http://localhost:3030/jsonstore/phonebook';

    function deleteUrl(key) {
        return `http://localhost:3030/jsonstore/phonebook/${key}`;
    }

    const phonebookUlEl = document.querySelector('ul#phonebook');

    const loadBtn = document.querySelector('button#btnLoad');
    loadBtn.addEventListener('click', getAllPhonebookEntries);

    const createBtn = document.querySelector('button#btnCreate');
    createBtn.addEventListener('click', createPhonebookEntry);

    async function getAllPhonebookEntries(){

        const receivePhonebookEntries = await fetch(getAndPostUrl);
        const dataPhonebookEntries = await receivePhonebookEntries.json();
        phonebookUlEl.replaceChildren();

        for (const phonebookEntry of Object.values(dataPhonebookEntries)) {
            const id = phonebookEntry._id;
            const person = phonebookEntry.person;
            const phone = phonebookEntry.phone;

            const liEl = document.createElement('li');
            liEl.textContent = `${person}: ${phone}`;
            liEl.setAttribute('data-id', id);

            const deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete';
            deleteBtn.addEventListener('click', deletePhonebookEntry);
            liEl.appendChild(deleteBtn);

            phonebookUlEl.appendChild(liEl);
        }
    }

    async function deletePhonebookEntry(event){
        const entryId = event.target.parentElement.getAttribute('data-id');

        await fetch(deleteUrl(entryId), {
            method: 'DELETE'
        });

        event.target.parentElement.remove();
    }

    async function createPhonebookEntry() {
        const personInputEl = document.querySelector('input#person');
        const phoneInputEl = document.querySelector('input#phone');

        const person = personInputEl.value;
        const phone = phoneInputEl.value;

        if (person === '' || phone === '') {
            return;
        }
        const newEntry = {
            person: person,
            phone: phone
        };

        await fetch(getAndPostUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newEntry)
        });

        personInputEl.value = '';
        phoneInputEl.value = '';

        getAllPhonebookEntries();

    }
}

attachEvents();