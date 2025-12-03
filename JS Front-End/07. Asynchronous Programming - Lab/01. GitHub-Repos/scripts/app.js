async function loadRepos() {
   const getResultEl = document.getElementById('res');

   const result = await fetch('https://api.github.com/users/octocat/repos');
   const data = await result.text();

   getResultEl.textContent = data;
}