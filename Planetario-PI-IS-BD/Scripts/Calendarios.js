﻿class SeleccionadorCalendario {

    constructor() {
        this.mapaCalendarios = new Map();
        this.mapaCalendarios["charlas eventos peliculas talleres telescopiadas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=NzZnOW04MGdjNWsya2VjY3RiYzFvczJpMWdAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=bGQxdGRqdDQxOWJiNzg1aTJuc3VvaWhtYTBAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=a201MzQ1cmFkdWhkYWJlcGN2cDFlbXNlNHNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=NnE5bzM1bGtkb29hZGRiY2V2NnFkdmJ0MWNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=ZzFpc2ZxZTVuZ2kxZ202bXAwNHJ2OHU4Z2dAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23800080&color=%23cc0000&color=%230000cc&color=%23cc8400&color=%2300cc00" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["charlas eventos peliculas talleres"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=NzZnOW04MGdjNWsya2VjY3RiYzFvczJpMWdAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=bGQxdGRqdDQxOWJiNzg1aTJuc3VvaWhtYTBAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=a201MzQ1cmFkdWhkYWJlcGN2cDFlbXNlNHNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=NnE5bzM1bGtkb29hZGRiY2V2NnFkdmJ0MWNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23800080&color=%23cc0000&color=%230000cc&color=%23cc8400" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["charlas eventos peliculas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=NzZnOW04MGdjNWsya2VjY3RiYzFvczJpMWdAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=bGQxdGRqdDQxOWJiNzg1aTJuc3VvaWhtYTBAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=a201MzQ1cmFkdWhkYWJlcGN2cDFlbXNlNHNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23800080&color=%23cc0000&color=%230000cc" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["charlas eventos"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=NzZnOW04MGdjNWsya2VjY3RiYzFvczJpMWdAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=bGQxdGRqdDQxOWJiNzg1aTJuc3VvaWhtYTBAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23800080&color=%23cc0000" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["charlas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=NzZnOW04MGdjNWsya2VjY3RiYzFvczJpMWdAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23800080" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["eventos"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=bGQxdGRqdDQxOWJiNzg1aTJuc3VvaWhtYTBAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23cc0000" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["eventos peliculas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=bGQxdGRqdDQxOWJiNzg1aTJuc3VvaWhtYTBAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=a201MzQ1cmFkdWhkYWJlcGN2cDFlbXNlNHNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23cc0000&color=%230000cc" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["peliculas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=a201MzQ1cmFkdWhkYWJlcGN2cDFlbXNlNHNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%230000cc" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["charlas peliculas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=NzZnOW04MGdjNWsya2VjY3RiYzFvczJpMWdAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=a201MzQ1cmFkdWhkYWJlcGN2cDFlbXNlNHNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23800080&color=%230000cc" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["charlas eventos talleres"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=NzZnOW04MGdjNWsya2VjY3RiYzFvczJpMWdAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=bGQxdGRqdDQxOWJiNzg1aTJuc3VvaWhtYTBAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=NnE5bzM1bGtkb29hZGRiY2V2NnFkdmJ0MWNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23800080&color=%23cc0000&color=%23cc8400" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["eventos talleres"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=bGQxdGRqdDQxOWJiNzg1aTJuc3VvaWhtYTBAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=NnE5bzM1bGtkb29hZGRiY2V2NnFkdmJ0MWNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23cc0000&color=%23cc8400" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["talleres"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=NnE5bzM1bGtkb29hZGRiY2V2NnFkdmJ0MWNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23cc8400" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["charlas talleres"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=NzZnOW04MGdjNWsya2VjY3RiYzFvczJpMWdAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=NnE5bzM1bGtkb29hZGRiY2V2NnFkdmJ0MWNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23800080&color=%23cc8400" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["charlas peliculas talleres"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=NzZnOW04MGdjNWsya2VjY3RiYzFvczJpMWdAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=a201MzQ1cmFkdWhkYWJlcGN2cDFlbXNlNHNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=NnE5bzM1bGtkb29hZGRiY2V2NnFkdmJ0MWNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23800080&color=%230000cc&color=%23cc8400" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["peliculas talleres"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=a201MzQ1cmFkdWhkYWJlcGN2cDFlbXNlNHNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=NnE5bzM1bGtkb29hZGRiY2V2NnFkdmJ0MWNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%230000cc&color=%23cc8400" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["eventos peliculas talleres"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=bGQxdGRqdDQxOWJiNzg1aTJuc3VvaWhtYTBAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=a201MzQ1cmFkdWhkYWJlcGN2cDFlbXNlNHNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=NnE5bzM1bGtkb29hZGRiY2V2NnFkdmJ0MWNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23cc0000&color=%230000cc&color=%23cc8400" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["charlas peliculas talleres telescopiadas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=NzZnOW04MGdjNWsya2VjY3RiYzFvczJpMWdAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=a201MzQ1cmFkdWhkYWJlcGN2cDFlbXNlNHNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=NnE5bzM1bGtkb29hZGRiY2V2NnFkdmJ0MWNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=ZzFpc2ZxZTVuZ2kxZ202bXAwNHJ2OHU4Z2dAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23800080&color=%230000cc&color=%23cc8400&color=%2300cc00" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["charlas peliculas telescopiadas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=NzZnOW04MGdjNWsya2VjY3RiYzFvczJpMWdAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=a201MzQ1cmFkdWhkYWJlcGN2cDFlbXNlNHNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=ZzFpc2ZxZTVuZ2kxZ202bXAwNHJ2OHU4Z2dAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23800080&color=%230000cc&color=%2300cc00" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["charlas telescopiadas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=NzZnOW04MGdjNWsya2VjY3RiYzFvczJpMWdAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=ZzFpc2ZxZTVuZ2kxZ202bXAwNHJ2OHU4Z2dAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23800080&color=%2300cc00" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["telescopiadas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=ZzFpc2ZxZTVuZ2kxZ202bXAwNHJ2OHU4Z2dAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%2300cc00" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["peliculas telescopiadas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=a201MzQ1cmFkdWhkYWJlcGN2cDFlbXNlNHNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=ZzFpc2ZxZTVuZ2kxZ202bXAwNHJ2OHU4Z2dAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%230000cc&color=%2300cc00" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["charlas talleres telescopiadas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=NzZnOW04MGdjNWsya2VjY3RiYzFvczJpMWdAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=NnE5bzM1bGtkb29hZGRiY2V2NnFkdmJ0MWNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=ZzFpc2ZxZTVuZ2kxZ202bXAwNHJ2OHU4Z2dAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23800080&color=%23cc8400&color=%2300cc00" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["talleres telescopiadas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=NnE5bzM1bGtkb29hZGRiY2V2NnFkdmJ0MWNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=ZzFpc2ZxZTVuZ2kxZ202bXAwNHJ2OHU4Z2dAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23cc8400&color=%2300cc00" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["peliculas talleres telescopiadas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=a201MzQ1cmFkdWhkYWJlcGN2cDFlbXNlNHNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=NnE5bzM1bGtkb29hZGRiY2V2NnFkdmJ0MWNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%230000cc&color=%23cc8400" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["charlas eventos talleres telescopiadas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=NzZnOW04MGdjNWsya2VjY3RiYzFvczJpMWdAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=bGQxdGRqdDQxOWJiNzg1aTJuc3VvaWhtYTBAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=NnE5bzM1bGtkb29hZGRiY2V2NnFkdmJ0MWNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=ZzFpc2ZxZTVuZ2kxZ202bXAwNHJ2OHU4Z2dAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23800080&color=%23cc0000&color=%23cc8400&color=%2300cc00" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["charlas eventos telescopiadas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=NzZnOW04MGdjNWsya2VjY3RiYzFvczJpMWdAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=bGQxdGRqdDQxOWJiNzg1aTJuc3VvaWhtYTBAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=ZzFpc2ZxZTVuZ2kxZ202bXAwNHJ2OHU4Z2dAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23800080&color=%23cc0000&color=%2300cc00" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["eventos telescopiadas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=bGQxdGRqdDQxOWJiNzg1aTJuc3VvaWhtYTBAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=ZzFpc2ZxZTVuZ2kxZ202bXAwNHJ2OHU4Z2dAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23cc0000&color=%2300cc00" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["eventos talleres telescopiadas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=bGQxdGRqdDQxOWJiNzg1aTJuc3VvaWhtYTBAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=NnE5bzM1bGtkb29hZGRiY2V2NnFkdmJ0MWNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=ZzFpc2ZxZTVuZ2kxZ202bXAwNHJ2OHU4Z2dAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23cc0000&color=%23cc8400&color=%2300cc00" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["charlas eventos peliculas telescopiadas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=NzZnOW04MGdjNWsya2VjY3RiYzFvczJpMWdAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=bGQxdGRqdDQxOWJiNzg1aTJuc3VvaWhtYTBAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=a201MzQ1cmFkdWhkYWJlcGN2cDFlbXNlNHNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=ZzFpc2ZxZTVuZ2kxZ202bXAwNHJ2OHU4Z2dAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23800080&color=%23cc0000&color=%230000cc&color=%2300cc00" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["eventos peliculas telescopiadas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=bGQxdGRqdDQxOWJiNzg1aTJuc3VvaWhtYTBAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=a201MzQ1cmFkdWhkYWJlcGN2cDFlbXNlNHNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=ZzFpc2ZxZTVuZ2kxZ202bXAwNHJ2OHU4Z2dAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23cc0000&color=%230000cc&color=%2300cc00" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'
        this.mapaCalendarios["eventos peliculas talleres telescopiadas"] = '<iframe src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23e6ecff&ctz=America%2FCosta_Rica&showTitle=0&showNav=1&showDate=1&showPrint=0&showTabs=1&showCalendars=0&showTz=0&src=bGQxdGRqdDQxOWJiNzg1aTJuc3VvaWhtYTBAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=a201MzQ1cmFkdWhkYWJlcGN2cDFlbXNlNHNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=NnE5bzM1bGtkb29hZGRiY2V2NnFkdmJ0MWNAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&src=ZzFpc2ZxZTVuZ2kxZ202bXAwNHJ2OHU4Z2dAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&color=%23cc0000&color=%230000cc&color=%23cc8400&color=%2300cc00" style="border-width:0" width="100%" height="600" frameborder="0" scrolling="no"></iframe>'     
    }

};

function cambiarCalendario() {
    let seleccionadorCalendario = new SeleccionadorCalendario();
    let checkboxesFiltros = document.getElementsByClassName("checkbox-filtro-calendario")
    let filtros = []
    for (let checkbox of checkboxesFiltros) {
        if (checkbox.checked) {
            filtros.push(checkbox.name)
        }
    }
    filtros.sort();
    let stringFiltros = ""
    for (let filtro of filtros) {
        if (filtro !== filtros[0]) {
            stringFiltros += ' '
        }
        stringFiltros += filtro;
    }
    let calendario = document.getElementById("calendario")
    console.log(calendario.innerHTML)
    calendario.innerHTML = seleccionadorCalendario.mapaCalendarios[stringFiltros];
}