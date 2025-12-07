async function lockedProfile() {
    
    const getUrl = 'http://localhost:3030/jsonstore/advanced/profiles';

    const resultProfiles = await fetch(getUrl);
    const dataProfiles = await resultProfiles.json();

    const mainSection = document.getElementById('main');
    mainSection.innerHTML = '';

    const profileKeys = Object.values(dataProfiles);

    for (let i = 0; i < profileKeys.length; i++) {
        const profile = profileKeys[i];
        const profileDiv = document.createElement('div');
        profileDiv.className = 'profile';
    
        const img = document.createElement('img');
        img.src = './iconProfile2.png';
        img.className = 'userIcon';
        profileDiv.appendChild(img);
    
        const lockLabel = document.createElement('label');
        lockLabel.textContent = 'Lock';
        profileDiv.appendChild(lockLabel);
    
        const lockRadio = document.createElement('input');
        lockRadio.type = 'radio';
        lockRadio.name = `${profile._id}Locked`;
        lockRadio.value = 'lock';
        lockRadio.checked = true;
        profileDiv.appendChild(lockRadio);
    
        const unlockLabel = document.createElement('label');
        unlockLabel.textContent = 'Unlock';
        profileDiv.appendChild(unlockLabel);
    
        const unlockRadio = document.createElement('input');
        unlockRadio.type = 'radio';
        unlockRadio.name = `${profile._id}Locked`;
        unlockRadio.value = 'unlock';
        profileDiv.appendChild(unlockRadio);
    
        profileDiv.appendChild(document.createElement('hr'));
    
        const usernameLabel = document.createElement('label');
        usernameLabel.textContent = 'Username';
        profileDiv.appendChild(usernameLabel);
    
        const usernameInput = document.createElement('input');
        usernameInput.type = 'text';
        usernameInput.name = `user${i+1}Username`;
        usernameInput.value = profile.username;
        usernameInput.disabled = true;
        usernameInput.readOnly = true;
        profileDiv.appendChild(usernameInput);
    
        const detailsDiv = document.createElement('div');
        detailsDiv.style.display = 'none';
        detailsDiv.id = `user${i}HiddenFields`;
    
        detailsDiv.appendChild(document.createElement('hr'));
    
        const emailLabel = document.createElement('label');
        emailLabel.textContent = 'Email:';
        detailsDiv.appendChild(emailLabel);
    
        const emailInput = document.createElement('input');
        emailInput.type = 'email';
        emailInput.name = `${profile._id}Email`;
        emailInput.value = profile.email;
        emailInput.disabled = true;
        emailInput.readOnly = true;
        detailsDiv.appendChild(emailInput);
    
        const ageLabel = document.createElement('label');
        ageLabel.textContent = 'Age:';
        detailsDiv.appendChild(ageLabel);
    
        const ageInput = document.createElement('input');
        ageInput.type = 'number';
        ageInput.name = `${profile._id}Age`;
        ageInput.value = profile.age;
        ageInput.disabled = true;
        ageInput.readOnly = true;
        detailsDiv.appendChild(ageInput);
    
        profileDiv.appendChild(detailsDiv);
    
        const showMoreBtn = document.createElement('button');
        showMoreBtn.textContent = 'Show more';
        profileDiv.appendChild(showMoreBtn);

        showMoreBtn.addEventListener('click', () => {
            if (lockRadio.checked) return; 
            if (detailsDiv.style.display === 'none') {
                detailsDiv.style.display = 'block';
                showMoreBtn.textContent = 'Hide it';
            } else {
                detailsDiv.style.display = 'none';
                showMoreBtn.textContent = 'Show more';
            }
        });

        lockRadio.addEventListener('change', () => {
            detailsDiv.style.display = 'none';
            showMoreBtn.textContent = 'Show more';
        });

        unlockRadio.addEventListener('change', () => {
            // No action needed, button will work
        });
    
        mainSection.appendChild(profileDiv);
    }
}