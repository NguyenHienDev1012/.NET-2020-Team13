let elms = document.getElementsByClassName("icon-flow");
let margin_left = 0;
for (let elm of elms) {
    elm.addEventListener("click", function () {
        showSlides(this);
    });
}
setInterval(function () {
    // document.getElementById('s1').style.marginLeft = "-" + (margin_left + 20) + "%";

    margin_left -= 20;
    if (margin_left === -100) {
        margin_left = 0;
    }
    document.getElementById('s1').style.marginLeft = margin_left + "%";
}, 3000);

function showSlides(elm) {
    if (elm.getAttribute('id') === "icon-next") {
        if (margin_left !== -80) {
            margin_left -= 20;
        } else {
            margin_left = 0;
        }
    } else {
        if (margin_left !== 0) {
            margin_left += 20;
        } else {
            margin_left = -80;
        }
    }
    document.getElementById('s1').style.marginLeft = margin_left + "%";

}