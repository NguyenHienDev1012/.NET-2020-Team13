$(document).ready(function () {
    let flag = true;
    let page;
    $("#serach-form").submit(function () {
        flag = true;
        let value = $("#search").val();
        if (value === '') {
            flag = false;
        } else {
            page = 'timkiem?key=' + value;
            $(this).attr('action', page);
            flag = true;
        }
        return flag;
    })
});