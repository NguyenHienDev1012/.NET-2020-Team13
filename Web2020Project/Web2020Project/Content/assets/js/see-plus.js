$(document).ready(function () {
    $('.see-btn').click(function () {
        let parent = this.parentNode.parentNode;
        let child = parent.children.item(1);
        if (this.innerHTML.includes('Xem thêm')) {
            this.innerHTML = this.innerHTML.replace('Xem thêm', 'Thu gọn');
            child.style.height='100%';
        } else {
            this.innerHTML = this.innerHTML.replace('Thu gọn', 'Xem thêm');
            child.style.height='500px';
        }

    });
});