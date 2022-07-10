class Typing {
    constructor(inputIds) {
        this.textContainer = document.querySelector(inputIds[0]);
        this.userEntryContainer = document.querySelector(inputIds[1]);
        this.statusContainer = document.querySelector(inputIds[2]);
        this.seconds = 0;
        this.minutes = 0;
        this.timerActive = false;
        this.timerInterval = "";
        this.textOptions = [
            "Marte es el cuarto planeta en orden de distancia al Sol y el segundo más pequeño del sistema solar, después de Mercurio. Recibió su nombre en homenaje al dios de la guerra de la mitología romana, y también es conocido como el planeta rojo​ debido a la apariencia rojiza​ que le confiere el óxido de hierro predominante en su superficie.",
            "Un asteroide es un cuerpo celeste rocoso, más pequeño que un planeta y mayor que un meteoroide. La mayoría orbita entre Marte y Júpiter, en la región del sistema solar conocida como cinturón de asteroides.",
            "La astronomía es la ciencia natural que estudia los cuerpos celestes del universo, incluidos las estrellas, los planetas, sus satélites naturales, los asteroides, cometas y meteoroides, la materia interestelar, las nebulosas, la materia oscura, las galaxias y demás.",
            "Venus es el segundo planeta del sistema solar en orden de proximidad al Sol y el tercero en cuanto a tamaño en orden ascendente después de Mercurio y Marte. Al igual que Mercurio, carece de satélites naturales. Recibe su nombre en honor a Venus, la diosa romana del amor.",
            "Isaac Newton fue un físico, teólogo, inventor, alquimista y matemático inglés. Es autor de los Philosophiae naturalis principia mathematica, más conocidos como los Principia, donde describe la ley de la gravitación universal y estableció las bases de la mecánica clásica mediante las leyes que llevan su nombre.",
            "Saturno es el sexto planeta del sistema solar contando desde el Sol, el segundo en tamaño y masa después de Júpiter y el único con un sistema de anillos visible desde la Tierra. Su nombre proviene del dios romano Saturno.",
            "Se denomina telescopio al instrumento óptico que permite observar objetos lejanos con mucho más detalle que a simple vista al captar radiación electromagnética, tal como la luz. Es un utensilio fundamental en astronomía."

        ]
        this.changeText();
        this.seconds = 0;
        this.minutes = 0;
        this.mistakes = 0;
    }

    changeText() {
        console.log('a');
        let randomOption = Math.floor(Math.random() * this.textOptions.length);
        this.textContainer.textContent = this.textOptions[randomOption];
        this.userEntryContainer.placeholder = this.textOptions[randomOption];
        this.userEntryContainer.value = "";
        if (this.timerInterval != "") {
            this.stopTimer();
        }
    }

    startTimer() {
        this.timerInterval = setInterval(() => {
            if (this.timerActive) {
                if (this.seconds + 1 == 60) {
                    this.minutes += 1;
                    this.seconds = 0;
                } else {
                    this.seconds++;
                }
            }
        }, 1000);
    }

    stopTimer() {
        this.seconds = 0;
        this.minutes = 0;
        this.timerActive = false;
    }

    checkChar() {
        if (!this.timerActive) {
            this.startTimer();
            this.timerActive = true;
        }
        let value = this.userEntryContainer.value;
        let textValue = this.textContainer.textContent;
        if (value[value.length - 1] == textValue[value.length - 1]) {
            this.changeToGoodText();
        } else {
            this.changeToBadText();
            this.mistakes += 1;
        }
        let progress = (value.length * 100 / textValue.length);
        return progress;
    }

    getStats() {
        let timeStat = this.minutes + ":" + this.seconds;
        let damage = Math.round(this.mistakes * 100 / this.textContainer.textContent.length);
        return [damage, timeStat];
    }

    changeToGoodText() {
        let statusClasses = this.statusContainer.classList;
        let status = this.statusContainer;
        if (!statusClasses.contains("bg-success")) {
            status.textContent = "Misión va sin problemas";
            statusClasses.remove("bg-danger");
            statusClasses.add("bg-success");
        }
    }

    changeToBadText() {
        let statusClasses = this.statusContainer.classList;
        let status = this.statusContainer;
        if (!statusClasses.contains("bg-danger")) {
            status.textContent = "Estamos perdiendo la misión";
            statusClasses.remove("bg-success");
            statusClasses.add("bg-danger");
        }
    }
}