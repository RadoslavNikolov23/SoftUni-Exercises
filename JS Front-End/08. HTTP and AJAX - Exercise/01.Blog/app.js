function attachEvents() {
    
    const postURL = 'http://localhost:3030/jsonstore/blog/posts';
    const commentsURL = 'http://localhost:3030/jsonstore/blog/comments';

    const selectEl = document.getElementById('posts');
    const loadBtnEl = document.getElementById('btnLoadPosts');
    const viewBtnEl = document.getElementById('btnViewPost');


    loadBtnEl.addEventListener('click', async () => {
        const postsRecieved = await fetch(postURL);
        const posts = await postsRecieved.json();

        selectEl.replaceChildren();

        for(const [key, post] of Object.entries(posts)){
            const optionEl = document.createElement('option');
            optionEl.value = post.id;
            optionEl.textContent = post.title.toUpperCase();

            selectEl.appendChild(optionEl); 
        }
    });
    

    viewBtnEl.addEventListener('click', async () => {
        const postId = selectEl.value;

        const postsReceived= await fetch(postURL);
        const postForPosts  = await postsReceived.json();
        const post = postForPosts[postId];

        const postTitleEl = document.getElementById('post-title');
        const postBodyEl = document.getElementById('post-body');
        postTitleEl.textContent = post.title;
        postBodyEl.textContent = post.body;
        
        const commentsRecieved = await fetch(commentsURL);
        const commentsData = await commentsRecieved.json();
        const commentsForPost = Object.values(commentsData).filter(c => c.postId === postId);

        const commentsUlEl = document.getElementById('post-comments');

        commentsUlEl.replaceChildren();

        for(const comment of commentsForPost){
            const liEl = document.createElement('li');
            liEl.textContent = comment.text;

            commentsUlEl.appendChild(liEl);
        }
    });




}

attachEvents();