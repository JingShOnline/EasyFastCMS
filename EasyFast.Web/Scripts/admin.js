
/**
 * 
 * @param {any} val
 * @param {any} row
 */
function FormatColumnName(val, row) {
    if (row.ColumnTypeEnum === 1) {
        return '<a href="/Admin/Column/Update/' + row.Id + '">' + val + '</a>';
    }
    if (row.ColumnTypeEnum === 2) {
        return '<a href="/Admin/Column/SingleUpdate/' + row.Id + '">' + val + '</a>';
    }
};

var clear;
$(function () {
    var i = 0;
    clear = setInterval(function () {
            if (i <= 10) {
                clearInterval(clear);
            }
            if ($(".panel")[0]) {
            $(".panel").remove();
            $(".window-shadow").remove();
            $(".window-mask").remove();
            clearInterval(clear);
            }
            i++;
        },
      5);
   
});


