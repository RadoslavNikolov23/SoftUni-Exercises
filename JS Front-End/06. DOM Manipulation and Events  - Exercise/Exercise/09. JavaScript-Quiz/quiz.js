document.addEventListener("DOMContentLoaded", solve);

function solve() {
  const correctAnswers = {
    onclick: false,
    "JSON.stringify()": false,
    "A programming API for HTML and XML documents": false,
  };

  const allSections = document.querySelectorAll("section");
  const resultSection = document.querySelector("#results");

  for (const section of allSections) {
    section.addEventListener("click", ansewerQuestion);
  }

  function ansewerQuestion(event) {
    const liEl = event.target;
    const valie = liEl.textContent;

    const answers = Object.keys(correctAnswers);

    if (answers.includes(valie)) {
      correctAnswers[valie] = true;
    } else {
      correctAnswers[valie] = false;
    }

    liEl.parentElement.parentElement.classList.add("hidden");
    const nextSection = liEl.parentElement.parentElement.nextElementSibling;

    if (!nextSection.classList.contains("hidden")) {

      if (showResults(Object.values(correctAnswers))) {
        resultSection.style.display = "block";
        const createH1El = document.createElement("h1");
        createH1El.textContent = "You are recognized as top JavaScript fan!";
        resultSection.appendChild(createH1El);

      } else {
        resultSection.style.display = "block";
        const createH1El = document.createElement("h1");
        const rightAnswers = Object.values(correctAnswers)
                                   .filter((a) => a === true).length;

        createH1El.textContent = rightAnswers === 1? `You have ${rightAnswers} right answer`:`You have ${rightAnswers} right answers`;
        resultSection.appendChild(createH1El);
        
      }
    }
    nextSection.classList.remove("hidden");
  }

  function showResults(areAnswersCorrect) {
    return areAnswersCorrect.every((a) => a === true);
  }
}
