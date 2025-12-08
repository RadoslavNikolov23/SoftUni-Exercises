
    
    const urlGetAllArticles = 'http://localhost:3030/jsonstore/advanced/articles/list';

    function urlDetailsId(id) {
        return `http://localhost:3030/jsonstore/advanced/articles/details/${id}`;
    }

    async function showContext(id, parent) {
        const contentUrl = urlDetailsId(id);
        const getContent = await fetch(contentUrl);
        const contentData = await getContent.json();
        const extraDiv = parent.querySelector('.extra');
        extraDiv.style.display = 'block';
        extraDiv.querySelector('p').textContent = contentData.content;
    }
        
    async function hideContext(parent) {
        const extraDiv = parent.querySelector('.extra');
        extraDiv.style.display = 'none';
    }

    async function loadPage() {
        const getElements = await fetch(urlGetAllArticles);
        const data = await getElements.json();

        const main = document.getElementById('main');

        for(const element of data){
            const accordionDiv = document.createElement('div');
            accordionDiv.className = 'accordion';

            const head = document.createElement('div');
            head.className = 'head';
            
            const span = document.createElement('span');
            span.textContent = element.title;
            head.appendChild(span);
            
            const button = document.createElement('button');
            button.className = 'button';
            button.id = element._id;
            button.textContent = 'More';
            head.appendChild(button);

            button.addEventListener('click', async (e) => {
                if(button.textContent === 'More') {
                    await showContext(e.target.id, accordionDiv);
                    button.textContent = 'Less';
                }
                else {
                    await hideContext(accordionDiv);
                    button.textContent = 'More';
                }
            });

            accordionDiv.appendChild(head);

            const extra = document.createElement('div');
            extra.className = 'extra';
            extra.style.display = 'none';

            const paragraph = document.createElement('p');
            paragraph.textContent = element.content;
            extra.appendChild(paragraph);

            accordionDiv.appendChild(extra);

            main.appendChild(accordionDiv);
        }
    }

    loadPage();



 

