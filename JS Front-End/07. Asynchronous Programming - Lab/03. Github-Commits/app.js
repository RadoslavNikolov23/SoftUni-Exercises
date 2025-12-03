async function loadCommits() {
    const userNameEl = document.getElementById("username");
    const repoEl = document.getElementById("repo");

    const resylt = await fetch(`https://api.github.com/repos/${userNameEl.value}/${repoEl.value}/commits`);
    const data = await resylt.json();

    const commitsUl = document.getElementById("commits");
    commitsUl.replaceChildren();

    if(data.message){
        const li = document.createElement("li");
        li.textContent = `Error: ${data.message}`;
        commitsUl.appendChild(li);
        return;
    }

    data.forEach(c => {
        const li = document.createElement("li");
        li.textContent = `${c.commit.author.name}: ${c.commit.message}`;
        commitsUl.appendChild(li);
    });
}
