(function () {
    var canvas = document.querySelector('.grass-canvas'),
        ctx = canvas.getContext('2d'),
        stack = [],
        w = window.innerWidth,
        h = window.innerHeight;

    var drawer = function () {
        ctx.clearRect(0, 0, w, h);
        stack.forEach(function (el) {
            el();
        })
        requestAnimationFrame(drawer);
    }

    var anim = function () {
        var x = 0, y = 0;
        var maxTall = Math.random() * (h / 4) + (h / 4);
        var maxSize = Math.random() * (h / 60) + 5;
        var speed = Math.random() * 1;
        var position = Math.random() * w - w / 2;
        var c = function (l, u) { return Math.round(Math.random() * (u || 255) + l || 0); }

        var color = 'rgb(' + c(125, 50) + ',' + c(225, 80) + ',' + c(80, 50) + ')';
        return function () {

            var deviation = Math.cos(x / 50) * Math.min(x / 4, 50),
                tall = Math.min(x / 2, maxTall),
                size = Math.min(x / 50, maxSize);
            x += speed;
            ctx.save();

            ctx.strokeWidth = 10;
            ctx.translate(w / 2 + position, h)
            ctx.fillStyle = color;

            ctx.beginPath();
            ctx.lineTo(-size, 0);
            ctx.quadraticCurveTo(-size, -tall / 2, deviation, -tall);
            ctx.quadraticCurveTo(size, -tall / 2, size, 0);
            //ctx.closePath();?
            ctx.fill();

            ctx.restore()
        }
    };
    for (var x = 0; x < (w / 7); x++) { stack.push(anim()); }

    canvas.width = w;
    canvas.height = h;

    window.addEventListener('resize', function () {
        canvas.style.width = window.innerWidth;
        canvas.height.height = window.innerHeight;
    }, false);

    drawer();
})();