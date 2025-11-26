document.addEventListener("DOMContentLoaded", solve);

function solve() {
  const divProfilesElms = document.querySelectorAll(".profile");

  for (const profile of divProfilesElms) {
    const btnEl = profile.querySelector("button");

    btnEl.addEventListener("click", clickFunct);
  }

  function clickFunct(event) {
    const userHiddenInfoEl = event.target.parentElement.querySelector(
      "div#user2HiddenFields"
    );
    const isLocked = event.target.parentElement.querySelector(
      'input[type="radio"][name="user2Locked"]'
    );

    if (!isLocked.checked) {
      if (event.target.textContent === "Show more") {
        userHiddenInfoEl.style.display = "block";
        event.target.textContent = "Show less";
      } else {
        userHiddenInfoEl.style.display = "none";
        event.target.textContent = "Show more";
      }
    }
  }
}
