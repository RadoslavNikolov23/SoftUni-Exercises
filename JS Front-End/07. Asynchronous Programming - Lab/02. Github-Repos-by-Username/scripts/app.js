async function loadRepos() {
  const getUserName = document.getElementById("username").value;

  try {
    const result = await fetch(
      `https://api.github.com/users/${getUserName}/repos`
    );
	
	const list = document.getElementById("repos");
	list.innerHTML = "";	
	const data = await result.json();

	console.log(result);

	if(data.length === 0) {
		const li = document.createElement("li");
		li.textContent = `${result.status} - Not found!`;
		list.appendChild(li);
		return;
	}

    for (const repo of data) {
      const li = document.createElement("li");
      const a = document.createElement("a");
      a.href = repo.html_url;
      a.textContent = repo.name;
      li.appendChild(a);
      list.appendChild(li);
    }
  } catch (error) {
    alert(`Error: ${error.message}`);
  }
}
