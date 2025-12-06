function attachEvents() {
    
    const requestUrl = 'http://localhost:3030/jsonstore/messenger';	
    
    const authorInput = document.querySelector('div#controls > input[name="author"]');
    const contentInput = document.querySelector('div#controls > input[name="content"]');

    const submitBtn = document.querySelector('div#controls > input#submit');
    const refreshBtn = document.querySelector('div#controls > input#refresh');

    const messagesArea = document.querySelector('div#main > textarea#messages');   

    submitBtn.addEventListener('click', sendMessage);
    refreshBtn.addEventListener('click', loadMessages);

    async function sendMessage(){

        const author = authorInput.value;
        const content = contentInput.value;

        const message = {
            author,
            content
        };

        await fetch(requestUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(message)
        });

        authorInput.value = '';
        contentInput.value = '';
    }

    async function loadMessages(){
        const dataReceive = await fetch(requestUrl);
        const data = await dataReceive.json();

        // const messages = Object.values(data)
        //                         .map(m => `${m.author}: ${m.content} /n`);
        //                        // .join('\n');
        let messages = '';
        for(const mes of Object.values(data)){
            messages += `${mes.author}: ${mes.content}\n`;
        }

        
        messagesArea.value = messages.trim();

    }

}

attachEvents();