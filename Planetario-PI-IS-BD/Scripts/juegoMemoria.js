const cards = document.querySelectorAll('.memory-card');
const TOTAL_PAIRS = 6;

let hasFlippedCard = false;
let lockBoard = false;
let firstCard, secondCard;
let matchingPairs = 0;
let showInstructions = true;

window.onload = function () {
    document.getElementById("instructionsModal").click();
}

function flipCard() {
    if (lockBoard) return;
    if (this === firstCard) return;

    this.classList.add('flip');

    if (!hasFlippedCard) {
        hasFlippedCard = true;
        firstCard = this;

        return;
    }

    secondCard = this;
    checkForMatch();
}

function checkForMatch() {
    let isMatch = firstCard.dataset.framework === secondCard.dataset.framework;

    if (isMatch) {
        disableCards();
        ++matchingPairs;
        changeCardModal(id);
    } else {
        unflipCards();
    }
}

function disableCards() {
    firstCard.removeEventListener('click', flipCard);
    secondCard.removeEventListener('click', flipCard);

    resetBoard();
}

function unflipCards() {
    lockBoard = true;

    setTimeout(() => {
        firstCard.classList.remove('flip');
        secondCard.classList.remove('flip');

        resetBoard();
    }, 1000);
}

function resetBoard() {
    [hasFlippedCard, lockBoard] = [false, false];
    [firstCard, secondCard] = [null, null];
}

(function shuffle() {
    cards.forEach(card => {
        let randomPos = Math.floor(Math.random() * 12);
        card.style.order = randomPos;
    });
})();

cards.forEach(card => card.addEventListener('click', flipCard));

function closeModal(id) {
    document.getElementById(id).click();
}

function changeCardModal() {
    if (matchingPairs == TOTAL_PAIRS) {
        document.getElementById("cardModalButton").click();
    } 
}

function playAgain() {
    cards.forEach(card => card.classList.remove('flip'));
    cards.forEach(card => {
        let randomPos = Math.floor(Math.random() * 12);
        card.style.order = randomPos;
    });
    resetBoard();
    cards.forEach(card => card.addEventListener('click', flipCard));
    matchingPairs = 0;
    document.getElementById("continueButton").click();
}

function show(id) {
    document.getElementById(id).style.display = "initial";
}

function hide(id) {
    document.getElementById(id).style.display = "none";
}

function exit() {
    document.getElementById("finalButton").click();
}